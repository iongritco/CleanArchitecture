[![.NET](https://github.com/iongritco/CleanArchitecture/actions/workflows/dotnet.yml/badge.svg)](https://github.com/iongritco/CleanArchitecture/actions/workflows/dotnet.yml)

# CleanArchitecture
A playground for experimenting projects with a Clean Architecture - DDD, CQRS, MediatR, Blazor, .NET 9, Entity Framework Core

## Setup
- To get started, just create the database TodoData and update the connection string in appsettings (both in ToDoApp.Server.REST and in ToDoApp.Server.GRPC) - the migration will be executed automatically on the first run.
- Set as startup the ToDoApp.Server.REST, ToDoApp.Server.GRPC and ToDoApp.Client.Blazor projects.
