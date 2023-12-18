### E-Commerce Project

### Project Structure

Contains following projects;

- Domain
- Shared
- Infrastructure
- Application
- WebAPI
- Admin Blazor Server

#### Domain

#### Shared

#### Infrastructure

#### Application

#### WebAPI

#### Admin Blazor Server

### Database

SQL Server is being used currently and could be swapped with any other database if you wish easily through Entity
Framework Core.

Migration resets should not be happening after first product release.

#### Role and Permissions

Role and permissions has many to many relationship and the link table is not an existing entity.
EF Core shadow table is being used to create the link table and support the relationship.
For other many to many relationships, this may not be the case and you may need to create the link table as an entity.

#### Database Migration Rules

#### Database Structure and Schema




