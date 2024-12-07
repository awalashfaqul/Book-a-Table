# Book-a-Table API

## Description

The **Book-a-Table API** is a backend solution for managing the essential operations of a restaurant, providing functionality for handling tables, customers, bookings, and menu items. It allows administrators to efficiently perform CRUD operations through RESTful endpoints, ensuring smooth database interactions with the Code-First approach.

## Features

- Manage restaurant **tables**, **customers**, **bookings**, and **menu items**.
- CRUD operations for all entities.
- Ensures data consistency and availability.
- Integrated **Swagger UI** for API documentation and testing.
- Compatible with **Postman** for manual request validation.

---

## Technology Stack

- **.NET 8**: Framework for building the backend API.
- **Entity Framework Core**: ORM for database management with a Code-First methodology.
- **SQL Server**: Database for persistent data storage.
- **Swagger**: API documentation and testing interface.

---

## Database Design

The database consists of the following key entities:

### **Table**
Table entity is for tracking the details about restaurant tables, such as:
  - Table number
  - Seating capacity

### **Customers**
Customer entity is for to store customer data, including:
  - Name
  - Contact information

### **Bookings**
Booking entity is designed to record booking information:
  - Associated customer and table
  - Date and time of the booking
  - Party size

### **Menu Items**
Menu entity beholds the details about menu items:
  - Item name
  - Price
  - Availability status

---

## API Endpoints

### **Table Management**
- **POST /api/Table/CREATE:Table**: Create a new table.
- **GET /api/Table/READ_All_Tables**: Retrieve all tables.
- **GET /api/tables/READ_Table_By_Id**: Get a specific table by ID.
- **PUT /api/tables/UPDATE_Table**: Update table details.
- **DELETE /api/tables/DELETE_Table**: Delete a table by ID.

### **Customer Management**
- **POST /api/Customer/CREATE_Customer**: Create a new customer.
- **GET /api/Customer/READ_All_Customers**: Retrieve all customers.
- **GET /api/Customer/READ_Customer_By_Id**: Get a specific customer by ID.
- **PUT /api/Customer/UPDATE_Customer**: Update customer details.
- **DELETE /api/Customer/DELETE_Customer**: Delete a customer by ID.

### **Booking Management**
- **POST /api/Booking/CREATE_Booking**: Create a new booking after verifying table availability.
- **GET /api/Booking/READ_All_Bookings**: Retrieve all bookings.
- **GET /api/Booking/READ_Booking_By_Id**: Get a specific booking by ID.
- **PUT /api/Booking/UPDATE_Booking**: Update booking details.
- **DELETE /api/Booking/DELETE_Booking**: Delete a booking by ID.

### **Menu Item Management**
- **POST /api/MenuItem/CREATE_MenuItem**: Add a new menu item.
- **GET /api/MenuItem/READ_All_MenuItems**: Retrieve all menu items.
- **GET /api/MenuItem/READ_MenuItem_By_Id**: Get a specific menu item by ID.
- **PUT /api/MenuItem/UPDATE_MenuItem**: Update menu item details.
- **DELETE /api/MenuItem/DELETE_MenuItem**: Delete a menu item by ID.

---

## Getting Started

### **Prerequisites**
- **.NET 8 SDK**
- **SQL Server**
- **Postman** (optional, for testing)

### **Installation**
1. To clone the repository:
   ```bash
   git clone https://github.com/your-repo/book-a-table.git
   cd book-a-table
   ```
2. To restore dependencies:
   ```bash
   dotnet restore
   ```
3. To set up the database:
   - Update the `appsettings.json` with your SQL Server connection string.
   - Run migrations:
     ```bash
     dotnet ef database update
     ```

4. To start the application:
   ```bash
   dotnet run
   ```

5. To access Swagger UI:
   - Navigate to `http://localhost:<port>/swagger` in your browser.

---

## API Testing

- **Swagger UI**: Built-in documentation and testing tool.
- **Postman**: Use the endpoints listed above to manually send HTTP requests and validate responses.

---

## License

This project is open-source and available for customization under the [MIT License](LICENSE).