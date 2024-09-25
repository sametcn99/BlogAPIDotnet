# Notes for .NET WebAPI Project

## Resources I Utilized/Utilizing

### Microsoft Docs

- [Tutorial: Create a web API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio)
- [Tutorial: Create a minimal API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-8.0&tabs=visual-studio-code)
- [Entity Framework Core Docs](https://learn.microsoft.com/en-us/ef/core/)
- [Choose between controller-based APIs and minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/apis?view=aspnetcore-8.0)
- [.NET CLI overview](https://learn.microsoft.com/en-us/dotnet/core/tools/)
- [Design the infrastructure persistence layer](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)
- [Implementing the Repository and Unit of Work Patterns in an ASP.NET MVC Application (9 of 10)](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)
- [Introduction to Identity on ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0&tabs=net-cli)

### GitHub Repositories

- [adiazwise/CustomerAPI](https://github.com/adiazwise/CustomerAPI)
- [teddysmithdev/FinShark](https://github.com/teddysmithdev/FinShark)

### YouTube Tutorials

- [Introduction to ASP.NET Core MVC (.NET 8) / DotNetMastery](https://www.youtube.com/watch?v=AopeJjkcRvU)
- [ASP.NET Web API .NET 8 Tutorial 2024 / Teddy Smith - YouTube Playlist](https://www.youtube.com/playlist?list=PL82C6-O4XrHfrGOCPmKmwTO7M0avXyQKc)

### Blog Posts

- [How to Build a WEB API ASP.NET Core 6 (Part 1) / Dev.to Post](https://dev.to/learnwithandres/how-to-build-a-web-api-aspnet-core-6-2doc)

### Other

- Large Language Models (LLMs) 😇

## How to Initialize SQL Server in .NET WebAPI

1. **Install Required NuGet Packages**:

   Run the following commands:

   ```bash
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   ```

2. **Configure the Connection String**:

   Add your connection string to `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=<YourDatabaseName>;Trusted_Connection=True;"
     }
   }
   ```

3. **Create a DbContext Class**:

   Create a class that inherits from `DbContext` and configure it to use SQL Server.

4. **Define Your Models**:

   Ensure that your models are defined for the database.

5. **Configure DbContext in `Startup.cs`**:

   In the `Startup.cs` file, configure the `DbContext` to use the connection string from `appsettings.json`.

6. **Use DbContext in Your Application**:

   Once the context is configured, you can interact with the database. For example, in a controller:

   ```csharp
   public class SampleController : ControllerBase
   {
       private readonly ApplicationDbContext _context;

       public SampleController(ApplicationDbContext context)
       {
           _context = context;
       }

       public IActionResult GetData()
       {
           var data = _context.YourEntities.ToList();
           return Ok(data);
       }
   }
   ```

7. Init Migrations

   ```bash
   dotnet ef migration init
   dotnet ef database update
   ```

## Service Configuration

Create `ServiceConfiguration.cs` under the `Services/Configuration` folder and use it between the `app` and `builder` variables in `Program.cs`. Your `ServiceConfiguration` class and `Program.cs` should look like this:

- ServiceConfiguration.cs

```csharp
using Microsoft.EntityFrameworkCore;
using Application.Data;

namespace Application.Services.Configuration
{
    public class ServiceConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<AppContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddControllers();
        }
    }
}

```

- Program.cs

```csharp
using Application.Services.Configuration;

var builder = WebApplication.CreateBuilder(args); // creates a new WebApplication instance.
ServiceConfiguration.Configure(builder.Services, builder.Configuration); // configures services for the application.

var app = builder.Build(); // creates the application.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers(); // maps the controllers.
app.UseHttpsRedirection(); // redirects HTTP requests to HTTPS.

app.Run(); // runs the application.
```

## Creating Controllers as Async Tasks in ASP.NET Web API

### Understanding Async/Await

Before diving into the benefits of creating controllers as async tasks, let's briefly recap what async/await is.

- **Async**: This keyword marks a method as asynchronous, indicating that it can run independently without blocking the current thread.
- **Await**: This keyword is used within an async method to pause the method's execution until a particular task completes.

## Mappers

A **Mapper** is a design pattern used to transform data from one format to another. It’s commonly applied when transferring data between different layers of an application, such as from a database to the business logic layer or from the business logic layer to the presentation layer.

### Why Use a Mapper?

- **Separation of Concerns**: Mappers help separate data transformation logic from business logic, making the codebase cleaner and easier to maintain.
- **Reusability**: Mappers can be reused across different parts of the application, reducing code duplication.
- **Testability**: By isolating data transformation, mappers make it easier to write unit tests.
- **Consistency**: Ensures consistent data transformation across the application.

## DTOs (Data Transfer Objects)

A **DTO** is a design pattern used to transfer data between different parts of an application, especially between the client and server or between various layers. DTOs are simple objects that contain no business logic but only data. They are often used to encapsulate data and transfer it over the network or between layers of the application.

## Application Context

In software development, the term **application context** can refer to different things based on the context. Generally, it defines the environment or scope in which an application runs and manages its components and resources.

### Why Use an Application Context?

- **Resource Management**: Centralizes the management of resources like database connections, configuration settings, and external services.
- **Dependency Injection**: Helps with injecting dependencies into application components through a managed way.
- **Lifecycle Management**: Manages the lifecycle of components, ensuring proper initialization and cleanup.
- **Configuration**: Provides a centralized configuration location, making it easier to manage and modify settings.

## Repository Pattern

![Repository Pattern Diagram](https://asp.net/media/2578149/Windows-Live-Writer_8c4963ba1fa3_CE3B_Repository_pattern_diagram_1df790d3-bdf2-4c11-9098-946ddd9cd884.png)

The repository pattern is a popular architectural pattern used in software development to abstract data access logic and improve the maintainability and testability of applications. In the context of .NET Web API, the repository pattern offers several key advantages:

### Key Advantages

- **Separation of Concerns**: By separating data access logic from the business logic, the repository pattern promotes a clean separation of concerns. This makes the codebase more organized, easier to understand, and easier to maintain.
- **Improved Testability**: With the repository pattern, you can easily create mock or stub repositories for testing purposes. This allows you to isolate the business logic from the underlying data store and write more focused unit tests.
- **Data Access Abstraction**: Repositories provide an abstraction layer over the data access technology (e.g., Entity Framework, ADO.NET). This makes it easier to switch to a different data access technology in the future without significantly impacting the rest of the application.
- **Enhanced Maintainability**: By centralizing data access logic in repositories, you can make changes to the data access layer without affecting the business logic. This simplifies maintenance and reduces the risk of introducing bugs.
- **Improved Code Reusability**: Repositories can be reused across different parts of the application, reducing the amount of duplicate code.

In summary, the repository pattern is a valuable tool for building well-structured and maintainable .NET Web API applications. By promoting separation of concerns, improving testability, and providing data access abstraction, the repository pattern helps to create more robust and scalable software.
