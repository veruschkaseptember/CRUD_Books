using CRUD_Books.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection for DbContext
builder.Services.AddDbContext<BookDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")  + ";TrustServerCertificate=True;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();


// using the AddDbContext method and providing the appropriate options, configuring dependency injection for the BookDbContext with a SQL Server database connection
//DI - allows objects to depend on abstractions rather than concrete implementations 
//helps with decoupling components and makes code more modular and testable 
// DbContext is a class provided by Entity Framework Core that represents a session with the database
// It is responsible for querying and saving data to the database.
// AddDbContext method is used to register the DbContext in the dependency injection container
//  part of the Services collection provided by the IServiceCollection interface
// BookDbContext is the specific DbContext class that we want to register
// represents the database context for the "Books" table
// UseSqlServer is a method provided by Entity Framework Core to configure the SQL Server database provider
// pecifies the connection string to connect to the SQL Server database
// GetConnectionString is a method that retrieves the connection string from the application's configuration
// TrustServerCertificate=True is an additional option added to the connection string
// allows the application to trust the server's SSL certificate when using a secure connection