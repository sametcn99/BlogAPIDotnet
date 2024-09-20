# Notes for .NET WebAPI Project

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
