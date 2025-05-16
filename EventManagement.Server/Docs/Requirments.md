# Backend
## Authentication
- Login, Signup, Logout (Forgot Password not required for now) 
- There should be 2 Roles (Admin, User)

## Authorization [Roles and Permissions]

### Admin
- Admin can Create, Read, Update, and Delete events.

### User
- User Can (Read their booked events, Read all available events, Book, Cancel) events.

## Event Management API
- Create Event
- Read Event
  - Admin can read all events they created
  - User can read all available events
  - User can read his booked events
  - Read Specific Event
- Update Event
- Delete Event

### Event Attributes
- Event Name
- Event Description
- Event Category
- Event Date
- Event Price
- Event image
- Event Venue
- Available tickets
- Event Status (Open, Closed, Completed, Cancelled)
- Event Created By (Admin ID)
- Event Created At
- Event Updated At

## Booking API
 - User can book an event
 - User can cancel a booked event
 - User can choose number of tickets
 - admin can see all bookings
 - admin can see all bookings for a specific event

### Booking Attributes
- User ID
- Event ID
- Number of Tickets
- Booking Status (Booked)