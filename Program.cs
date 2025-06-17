using System.Text;
using Book_a_Table.Data;
using Book_a_Table.Data.Repositories;
using Book_a_Table.Data.Repositories.IRepositories;
using Book_a_Table.Services;
using Book_a_Table.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Azure.Communication.Email;
// For Google authentication
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Book_a_Table.Services.EmailService;

var builder = WebApplication.CreateBuilder(args); 


// Adding services to the container:
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BookATableDbContext>(options => 
    options.UseSqlServer(connectionString));


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


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<BookATableDbContext>()
    .AddDefaultTokenProviders();

// Adding authentication and authorization
/*builder.Services.AddAuthentication(options => 
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
})
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Google:ClientId"];
    options.ClientSecret = builder.Configuration["Google:ClientSecret"];
});*/

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

// Configuring Azure Communication Email service
builder.Services.AddScoped(options =>
{
    var azureEmailServiceConectionString = builder.Configuration["AzureEmailServiceConnectionString"];

    return new EmailClient(azureEmailServiceConectionString);
});

builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();


// Now, configuring the HTTP request pipeline...
if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
}


app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();