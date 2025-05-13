using System.Security.Claims;
using EventManagement.Server.Data;
using EventManagement.Server.Enums;
using EventManagement.Server.Middlewares;
using EventManagement.Server.Options;
using EventManagement.Server.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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



// Authorization Policies
var roleClaim = appOptions?.Auth0RoleClaim;

builder.Services.AddAuthorizationBuilder()
    .AddPolicy(nameof(Policies.RequireAdminRole), policy =>
        policy.RequireClaim(roleClaim, nameof(Role.admin)))
    .AddPolicy(nameof(Policies.RequireUserRole), policy =>
        policy.RequireClaim(roleClaim, nameof(Role.user)))
    .AddPolicy(nameof(Policies.RequireAnyRole), policy =>
        policy.RequireClaim(roleClaim, nameof(Role.admin), nameof(Role.user)));

// Register Services in DI Container
builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<AuthMiddleware>();

app.MapControllers();

app.Run();