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
