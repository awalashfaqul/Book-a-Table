using Book_a_Table.Data;
using Book_a_Table.Data.Repositories;
using Book_a_Table.Data.Repositories.IRepositories;
using Book_a_Table.Services;
using Book_a_Table.Services.IServices;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args); 


// Adding services to the container:

builder.Services.AddDbContext<BookATableDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen(); 

builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<ITableService, TableService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();

builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();

var app = builder.Build(); 


// Now, configuring the HTTP request pipeline...
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
}


app.UseHttpsRedirection(); 

app.UseAuthorization(); 

app.MapControllers(); 

app.Run(); 