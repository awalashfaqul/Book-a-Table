using Book_a_Table.Data; 
using Microsoft.EntityFrameworkCore; 

/* Creating a WebApplication builder that will set up services, 
configurations, and the application host for dependency injection. */
var builder = WebApplication.CreateBuilder(args); 


// Adding services to the container:

/* Adding support for discovering endpoints in the API, 
enabling automatic generation of endpoint metadata for Swagger. */
builder.Services.AddEndpointsApiExplorer(); 

/* Adding and configuring Swagger, which will generate API 
documentation and allow testing the API directly in the browser. */
builder.Services.AddSwaggerGen(); 

/* Registering the application's database context (`AppDbContext`) 
with dependency injection and configures it to use SQL Server. The 
connection string "DefaultConnection" is retrieved from appsettings.json 
or other configuration sources. */
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

/* Registering the controllers in the project so that they can handle 
incoming HTTP requests (API endpoints). */
builder.Services.AddControllers(); 

/* Building the WebApplication with the services and configuration defined 
in the builder. This app instance is used to configure middleware and run 
the application. */
var app = builder.Build(); 


// Now, configuring the HTTP request pipeline...
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger(); /* If the app is running in development mode, enable 
                         Swagger middleware to generate API documentation. */ 
    app.UseSwaggerUI(); /* Enables the Swagger UI, an interactive interface 
                           for testing the API. */ 
}

/* Enforcing HTTPS by redirecting all HTTP requests to HTTPS to ensure secure 
communication. */
app.UseHttpsRedirection(); 

/* Enabling authorization middleware to verify if the user is allowed to access 
certain resources, ensuring protected endpoints are secure. */
app.UseAuthorization(); 

/* Maps incoming HTTP requests to the corresponding controller actions based on 
routing attributes defined in the controllers. */
app.MapControllers(); 

/* Starts the application and listens for incoming HTTP requests, making the API 
functional. */
app.Run(); 