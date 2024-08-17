# Continuum - Web Platform Backend

## Overview

This is a platform designed to allow clients to create and manage their own websites with a customizable setup. Built using .NET and MySQL, following clean architecture principles and implementing a service-repository pattern for scalable and maintainable development.

Architecture

Entities

The entities represent the core domain models of the application, including:

	•	User: Represents a user in the system.
	•	Client: Represents a client, associated with a user, and contains configuration for their website.
	•	Configuration: Stores settings like title, subtitle, and other page-specific information.
	•	ContentBlock: Represents blocks of content within a page.
	•	Page: Represents a page within a client’s website.
	•	MediaContent: Stores information about media (articles, videos, etc.).
	•	SocialMedia: Stores social media profiles associated with a client.

Services

Services implement business logic and interact with repositories. Each entity has an associated service interface and implementation, such as IUserService, ClientService, etc.

Repositories

Repositories provide data access logic and interact with the database via Entity Framework Core. Each entity has an associated repository interface and implementation, such as IUserRepository, ClientRepository, etc.

Controllers

Controllers handle HTTP requests and map them to the appropriate service methods. They serve as the entry point for the API, providing endpoints for CRUD operations.

API Endpoints

	•	User Endpoints:
	•	GET /api/users: Retrieve all users.
	•	GET /api/users/{id}: Retrieve a specific user by ID.
	•	POST /api/users: Create a new user.
	•	PUT /api/users/{id}: Update an existing user.
	•	DELETE /api/users/{id}: Delete a user.
	•	Client Endpoints:
	•	GET /api/clients: Retrieve all clients.
	•	GET /api/clients/{id}: Retrieve a specific client by ID.
	•	POST /api/clients: Create a new client.
	•	PUT /api/clients/{id}: Update an existing client.
	•	DELETE /api/clients/{id}: Delete a client.
	•	Configuration Endpoints:
	•	GET /api/configurations: Retrieve all configurations.
	•	GET /api/configurations/{id}: Retrieve a specific configuration by ID.
	•	POST /api/configurations: Create a new configuration.
	•	PUT /api/configurations/{id}: Update an existing configuration.
	•	DELETE /api/configurations/{id}: Delete a configuration.
	•	ContentBlock Endpoints:
	•	GET /api/contentblocks: Retrieve all content blocks.
	•	GET /api/contentblocks/{id}: Retrieve a specific content block by ID.
	•	POST /api/contentblocks: Create a new content block.
	•	PUT /api/contentblocks/{id}: Update an existing content block.
	•	DELETE /api/contentblocks/{id}: Delete a content block.
	•	Page Endpoints:
	•	GET /api/pages: Retrieve all pages.
	•	GET /api/pages/{id}: Retrieve a specific page by ID.
	•	POST /api/pages: Create a new page.
	•	PUT /api/pages/{id}: Update an existing page.
	•	DELETE /api/pages/{id}: Delete a page.
	•	MediaContent Endpoints:
	•	GET /api/mediacontents: Retrieve all media content.
	•	GET /api/mediacontents/{id}: Retrieve a specific media content by ID.
	•	POST /api/mediacontents: Create new media content.
	•	PUT /api/mediacontents/{id}: Update existing media content.
	•	DELETE /api/mediacontents/{id}: Delete media content.
	•	SocialMedia Endpoints:
	•	GET /api/socialmedia: Retrieve all social media profiles.
	•	GET /api/socialmedia/{id}: Retrieve a specific social media profile by ID.
	•	POST /api/socialmedia: Create a new social media profile.
	•	PUT /api/socialmedia/{id}: Update an existing social media profile.
	•	DELETE /api/socialmedia/{id}: Delete a social media profile.