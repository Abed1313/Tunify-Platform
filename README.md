# Tunify Platform

Tunify Platform is a music streaming service that allows users to create and manage playlists, listen to songs, and explore artists and albums. The platform uses Entity Framework Core for data access and SQL Server as the database provider. This README provides an overview of the data models, relationships between entities, and how to set up and run the application.

## Description

Tunify Platform includes the following features:
- Users can subscribe to different subscription plans.
- Users can create playlists and add songs to their playlists.
- Songs are associated with artists and albums.
- Artists can have multiple albums and songs.
- Playlists can have multiple songs.

## The Tunify ERD Diagram
[Link](https://github.com/Abed1313/Tunify-Platform/blob/master/Tunify-Platform/assets/ERDTunify.PNG)

## Data Models and Relationships

The Tunify Platform consists of the following entities and their relationships:

### Subscriptions
- SubscriptionsID: Primary key
- SubscriptionType: Type of the subscription (e.g., Free, Basic, Standard, Premium, Family)
- Price: Price of the subscription
- Users: Collection of users subscribed to this subscription type

### Users
- UsersID: Primary key
- Username: Username of the user
- Email: Email address of the user
- JoinDate: Date the user joined the platform
- SubscriptionID: Foreign key to the Subscriptions table
- Subscriptions: Navigation property to the associated subscription
- Playlists: Collection of playlists created by the user

### Playlist
- PlaylistID: Primary key
- UserID: Foreign key to the Users table
- User: Navigation property to the associated user
- PlaylistName: Name of the playlist
- CreatedDate: Date the playlist was created
- PlaylistSongs: Collection of songs in the playlist

### Songs
- SongsID: Primary key
- Title: Title of the song
- ArtistID: Foreign key to the Artists table
- Artists: Navigation property to the associated artist
- AlbumID: Foreign key to the Albums table
- Albums: Navigation property to the associated album
- Duration: Duration of the song
- Genre: Genre of the song
- PlaylistSongs: Collection of playlists that include this song

### PlaylistSongs
- PlaylistSongsID: Primary key
- PlaylistID: Foreign key to the Playlist table
- Playlist: Navigation property to the associated playlist
- SongID: Foreign key to the Songs table
- Songs: Navigation property to the associated song

### Artists
- ArtistsID: Primary key
- Name: Name of the artist
- Bio: Biography of the artist
- Songs: Collection of songs by the artist
- Albums: Collection of albums by the artist

### Albums
- AlbumsID: Primary key
- AlbumName: Name of the album
- ReleaseDate: Release date of the album
- ArtistID: Foreign key to the Artists table
- Artists: Navigation property to the associated artist
- Songs: Collection of songs in the album

# Tunify Platform - Repo Integration

## Repository Design Pattern

## What is the Repository Design Pattern?
### The Repository Design Pattern is a well-known pattern in software engineering that provides an abstraction layer between the data access logic and the business logic of an application. In this pattern, the repository acts as an intermediary between the application's business logic and the data sources (like databases, web services, or external APIs). It encapsulates the logic required to access the data source, making it easier to manage, test, and maintain.

## Key Components:
### Repository Interface: This defines the standard set of operations (e.g., CRUD operations) that can be performed on a data entity. It helps in promoting loose coupling and better testability by allowing the business logic to depend on abstractions rather than concrete implementations.

### Repository Implementation: This is the concrete class that implements the repository interface. It contains the actual code to perform operations against the data source, such as querying a database or calling an external API.

### Data Context: In the case of Entity Framework Core, the data context (DbContext) manages the entity classes that map to the database tables and provides access to the underlying data.

## Benefits of the Repository Design Pattern
### Separation of Concerns: By separating the data access logic from the business logic, the Repository Pattern promotes a clear separation of concerns. This makes the codebase more modular and easier to maintain.

### Testability: The Repository Pattern enhances testability by allowing you to mock the repository interfaces during unit testing. This makes it easier to write tests that are isolated from the actual data source.

### Centralized Data Access Logic: All data access code is centralized in one place (the repository), which makes it easier to manage and update. For example, if you need to change the way data is fetched or saved, you can do so in one place without affecting the rest of the application.

### Flexibility and Adaptability: The pattern provides flexibility to change the underlying data storage mechanism without affecting the business logic. For instance, you can switch from a SQL database to a NoSQL database by just changing the repository implementation.

### Cleaner Code: By encapsulating data access code within repositories, the business logic remains clean and focused on what it is supposed to do, without being cluttered by data access concerns.

## Example in Tunify Platform

### In the Tunify Platform project, the Repository Pattern is used to abstract the data access logic for entities like Artists, Playlists, Songs, and Users. This ensures that the rest of the application remains agnostic to the specifics of how and where the data is stored, while also making it easier to extend or modify the data access layer in the future.

### In the Tunify Platform project, the Repository Pattern is used to abstract the data access logic for entities like Artists, Playlists, Songs, and Users. This ensures that the rest of the application remains agnostic to the specifics of how and where the data is stored, while also making it easier to extend or modify the data access layer in the future.

# Swagger UI Integration
## Overview
### Swagger UI has been integrated into this project to provide an interactive interface for developers and testers to explore and interact with the Tunify Platform API. Swagger UI allows you to see the API documentation, understand the endpoints, and execute requests directly from the browser without the need for third-party tools.

## Key Features of Swagger UI
### -Interactive API Documentation: Easily browse and test all the API endpoints with detailed information about request parameters and responses.
### -Live Request Testing: Make API requests directly from the browser and see live responses.
### -Customizable: The Swagger UI can be customized to suit the needs of your project, including setting custom paths, titles, and descriptions.

## How to Access and Use Swagger UI
### Start the Application.
### Open Swagger UI:
###     -Open your web browser.

### Explore the API:
### View and test all available API endpoints directly from the Swagger UI.


# Tunify Platform - User Authentication Service
### This repository includes the implementation of a user authentication service for the Tunify Platform, utilizing ASP.NET Core Identity for user management. The service is designed to handle user registration, login, and logout functionalities.

## Overview
### The project is structured around the following components:
## 1. IdentityUserService
### Location: Repositories/Services/IdentityUserService.cs
Purpose: This class implements the IUser interface to provide user management functionalities such as registration, login, and logout using ASP.NET Core Identity.
Key Methods:
Register: Registers a new user by creating an instance of ApplicationUser. Handles potential errors during registration and returns the newly created user's details.
LoginUser: Authenticates a user by validating their credentials and returns the user's details if the credentials are correct.
LogoutUser: Logs out the user by signing them out and returns their details.

## 2. IUser Interface
Location: Repositories/Interfaces/IUser.cs
Purpose: This interface defines the contract for user management operations. It ensures that the IdentityUserService implements the required methods for registering, logging in, and logging out users.
## 3. HomeController
Location: Controllers/HomeController.cs
Purpose: This API controller provides endpoints for user registration, login, and logout. It interacts with the IdentityUserService to perform these operations.
API Endpoints:
POST /api/home/register: Registers a new user.

Request Body: RegisterUserDTO containing UserName, Email, and Password.
Response: Returns the user details if successful, otherwise returns validation errors.
POST /api/home/login: Logs in a user.

Request Body: LoginDto containing Username and Password.
Response: Returns the user details if successful, otherwise returns an Unauthorized status.
POST /api/home/logout: Logs out a user.

Request Body: A string representing the Username.
Response: Returns the user details after successful logout.

## DTOs (Data Transfer Objects)
### RegisterUserDTO
Represents the data required to register a new user.
Fields:
UserName
Email
Password
### LoginDto
Represents the data required to log in a user.
Fields:
Username
Password
### UserDto
Represents the user details returned after registration, login, or logout.
Fields:
Id
UserName
## How to Use
### Registration:
Send a POST request to /api/home/register with the required user details.
Login:
Send a POST request to /api/home/login with the user's credentials.
Logout:
Send a POST request to /api/home/logout with the username to log out the user.
## Prerequisites
.NET 6.0 or higher
ASP.NET Core Identity
A configured database for Identity storage
## Installation
Clone the repository.
Restore dependencies by running dotnet restore.
Update your database connection string in the appsettings.json file.
Run the application using dotnet run.
