# CachingWithRedis

### Description

An introduction to caching in a Web Api using Redis, Postgres SQL as the database and containerization using Docker and Docker Compose.

### Dependencies

* Docker
* Microsoft.EntityFrameworkCore.Design - needed in order to run migrations
    * In order to run migrations, the database server needs to be changed to localhost in appsettings and the containers
    need to be up and running. You could also write code to run migrations when in development mode when the application starts.