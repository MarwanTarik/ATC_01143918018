using System.Security.Claims;
using EventManagement.Server.Data;
using EventManagement.Server.Enums;
using EventManagement.Server.Middlewares;
using EventManagement.Server.Options;
using EventManagement.Server.Repositories;
using EventManagement.Server.Repositories.Booking;
using EventManagement.Server.Repositories.Events;
using EventManagement.Server.Repositories.EventTags;
using EventManagement.Server.Repositories.Images;
using EventManagement.Server.Repositories.Tags;
using EventManagement.Server.Repositories.Users;
using EventManagement.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// App configurations
builder.Services.Configure<ApplicationOptions>(
    builder.Configuration.GetSection(ApplicationOptions.Application));

var appOptions =  builder
    .Configuration
    .GetSection(ApplicationOptions.Application)
    .Get<ApplicationOptions>();


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// DB Configuration
builder.Services.Configure<DbOptions>(
    builder.Configuration.GetSection(DbOptions.Db));

builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
{
    var dbOptions = serviceProvider.GetRequiredService<IOptions<DbOptions>>().Value;
    options.UseNpgsql(dbOptions.ConnectionString);
});

// Auth0 Configuration
builder.Services.Configure<AuthOptions>(
    builder.Configuration.GetSection(AuthOptions.Auth));

var auth0Options = builder.Configuration.GetSection(AuthOptions.Auth).Get<AuthOptions>();

var domain = $"https://{auth0Options?.Domain}/";

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = domain;
        options.Audience = auth0Options?.Audience;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = ClaimTypes.NameIdentifier
        };
    });



// Authorization PoliciesEnum
var roleClaim = appOptions?.Auth0RoleClaim;

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(nameof(PoliciesEnum.RequireAdminRole), policy =>
        policy.RequireClaim(roleClaim, nameof(RolesEnum.admin)))
    .AddPolicy(nameof(PoliciesEnum.RequireUserRole), policy =>
        policy.RequireClaim(roleClaim, nameof(RolesEnum.user)))
    .AddPolicy(nameof(PoliciesEnum.RequireAnyRole), policy =>
        policy.RequireClaim(roleClaim, nameof(RolesEnum.admin), nameof(RolesEnum.user)));

// Register Services in DI Container
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IEventsRepository, EventsRepository>();
builder.Services.AddScoped<IEventTagsRepository, EventTagsRepository>();
builder.Services.AddScoped<IImagesRepository, ImagesRepository>();
builder.Services.AddScoped<ITagsRepository, TagsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<EventsService>();
builder.Services.AddScoped<TagsService>();
builder.Services.AddScoped<UsersService>();

builder.Services.AddProblemDetails();
builder.Services.AddSingleton<IExceptionHandler, GlobalExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseExceptionHandler();
app.UseStatusCodePages();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<AuthMiddleware>();

app.MapControllers();

app.Run();