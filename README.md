[![.NET](https://github.com/iongritco/CleanArchitecture/actions/workflows/dotnet.yml/badge.svg)](https://github.com/iongritco/CleanArchitecture/actions/workflows/dotnet.yml)

# CleanArchitecture
A playground for experimenting projects with a Clean Architecture - DDD, CQRS, MediatR, Blazor, .NET 7, Entity Framework Core

# Setup
For the first time use, you need to create the database manually(name TodoData), the tables will be created automatically by setting the correct SQL connection string in appsettings files - both in REST and GRPC projects. 
Also, make sure that you're setting up as a start-up projects both REST, GRPC and Client.Blazor projects.
