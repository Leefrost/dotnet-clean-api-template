## About
A clean template based on ASP.NET CORE Web API, CQRS and Clean Architecture workflow. Allow you to create a simple API app without any pain regarding solution structure or dependencies.

Stack:
- .NET 5.0.x
- ASP .NET 5.0.x
- Entity Framework Core 5.0.x
- MediatR
- Automapper
- FluentValidation
- NUnit, FluentAssertions, Moq
- Serilog

TBD:
- Docker support
- Identity server support
- Respawn


## Getting started
To create a new app with this template, you are required to install this  [NuGet package](https://www.nuget.org/packages/Leefrost.Dotnet.Web.Api.ProjectTemplate/) and run `dotnet new clean-web-api -n "<Project name>"`.

If you are using IDE like VS or Rider, you can enable custom template support and will be able to create new projects with this template also.

### Steps to run from the console

1. Install the latest .NET SDK
2. Run `dotnet new --install Leefrost.Dotnet.Web.Api.ProjectTemplate` to install the project template
3. Create a folder for your solution and `cd` into it (the template will use it as project name)
4. Run `dotnet new clean-web-api -n "<Project name>"` to create a new project
5. Navigate to `source/<Project name>.Api` and run `dotnet run` to launch the project (ASP.NET Core Web API)
6. Open web browser https://localhost:5001/api to see the Open API specification

### Steps to run from VS/Rider

1. Install the latest .NET SDK
2. Run `dotnet new --install Leefrost.Dotnet.Web.Api.ProjectTemplate` to install the project template
3. Go to VS/Rider settings and check the "Show custom .NET templates" feature.
4. Restart IDE
5. Create a new project and filter all existed templates to find "ASP.NET Core Clean API".
6. Create it. IDE will automatically update all settings before running

## Project features

### Database Configuration
The template is configured to use an in-memory database by default. This ensures that all users will be able to run the solution without needing to set up additional infrastructure (e.g. SQL Server).

If you would like to use SQL Server, you will need to update `appsettings.json` as follows (or override the environment settings file). To run a project with existed DB, a connection string is required to be set:

```json
  "UseInMemoryDatabase": false
```

Verify that the CleanApiTemplateDb connection string within appsettings.json points to a valid SQL Server instance.

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

### Database Migrations
To use `dotnet-ef` for your migrations please add the following flags to your command (values assume you are executing from repository root)

- `--project source/<Project name>.Persistence.Database` (optional if it is a current folder)
- `--startup-project src/<Project name>.Api`
- `--output-dir Migrations`

For example, to add a new migration from the root folder:

`dotnet ef migrations add "CreateDb" --project source/<Project name>.Persistence.Database --startup-project src/<Project name>.Api --output-dir Migrations`

and

`dotnet ef database update --project source/<Project name>.Persistence.Database --startup-project src/<Project name>.Api`

### Logging

This template using Serilog to handle all logs inside. By default, the output is console or file. Serilog also supports tons of another formatting/destination sources with external dependencies (Elastic, Seq, etc.)

## Architecture overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types, and logic specific to the project domain field.

### Application
This layer contains all *application* logic. It is dependent on the domain layer but has no dependencies on any other layer or project. 

This layer defines interfaces that are implemented by all other layers (except Domain). For example, if the application needs to run some special functions (send a mail, etc.), a special interface will be created in the App project and implementation would be created within the infrastructure level.

### Infrastructure
This layer contains classes for accessing external resources such as file systems, web services, SMTP, and so on. These classes should be based on interfaces defined within the application layer.

### WebApi
Simple API project based on ASP .NET Core (5.0). This layer depends on both the Application and Infrastructure layers, however, the dependency on Infrastructure is only to support dependency injection. Therefore only Startup.cs should reference Infrastructure.

## Support
If you are having problems, please let us know by raising a new issue.

## License
This project is licensed with the MIT license.

## Changelog
* In future
