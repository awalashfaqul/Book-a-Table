# Restaurant Booking API: Book-a-Table

## Project Overview

This project is a backend API designed to streamline the operations of a restaurant by allowing administrators to manage essential data such as bookings, tables, customers, and menu items. The system provides CRUD (Create, Read, Update, Delete) functionality via RESTful API endpoints and ensures smooth, efficient database operations using the Code-First approach.

## Core Technologies

- **.NET 8**: Core framework for building the API.
- **Entity Framework Core**: Utilized for database management through a Code-First approach.
- **SQL Server**: Relational database to store restaurant data.
- **Swagger**: Used for generating API documentation and making it easier to test the API endpoints.
- **Postman**: For manually testing and verifying the API functionalities.

## Database Structure

The system consists of the following key tables, each serving a specific purpose within the restaurant management workflow:

- **Tables**: Contains details about restaurant tables, including their number and seating capacity.
- **Customers**: Stores customer information such as names and contact details.
- **Bookings**: Links customers to restaurant tables, recording the booking date, time, and party size.
- **MenuItems**: Stores the restaurant's menu items, along with their names, prices, and availability status.

## API Endpoints Overview

### Table

- **POST /api/Table/CREATE:Table**: Adds a new table to the system.
- **GET /api/Table/READ_All_Tables**: Fetches a list of all tables in the restaurant.
- **GET /api/tables/READ_Table_By_Id**: Retrieves details for a specific table using its ID.
- **PUT /api/tables/UPDATE_Table**: Updates the details of an existing table.
- **DELETE /api/tables/DELETE_Table**: Deletes a specific table from the system.

### Customer

- **POST /api/Customer/CREATE_Customer**: Creates a new customer record.
- **GET /api/Customer/READ_All_Customers**: Returns a list of all registered customers.
- **GET /api/Customer/READ_Customer_By_Id**: Fetches details for a specific customer using their ID.
- **PUT /api/Customer/UPDATE_Customer**: Updates an existing customer’s details.
- **DELETE /api/Customer/DELETE_Customer**: Removes a customer from the system.

### Booking

- **POST /api/Booking/CREATE_Booking**: Creates a new booking, verifying table availability before completing the action.
- **GET /api/Booking/READ_All_Bookings**: Retrieves all booking records.
- **GET /api/Booking/READ_Booking_By_Id**: Fetches details of a specific booking by its ID.
- **PUT /api/Booking/UPDATE_Booking**: Updates the details of an existing booking.
- **DELETE /api/Booking/DELETE Booking**: Deletes a booking by its ID.

### Menu Management

- **POST /api/Menuitem/CREATE_MenuItem**: Adds a new item to the restaurant’s menu.
- **GET /api/MenuItem/READ_All_Menuitems**: Retrieves all available menu items.
- **GET /api/Menuitem/READ_MenuItem_By_Id**: Fetches details of a specific menu item using its ID.
- **PUT /api/Menuitem/UPDATE_MenuItem**: Updates the details of an existing menu item.
- **DELETE /api/Menuitem/DELETE_MenuItem**: Removes a specific item from the menu.

## API Documentation & Testing

- **Swagger**: The API comes integrated with Swagger for seamless API documentation and quick testing. This can be accessed via `/swagger` to explore the available endpoints.
- **Postman**: Postman can be used to test the API calls manually by sending various requests to the listed endpoints and verifying the responses.

---

This API simplifies the management of day-to-day restaurant operations and provides a scalable foundation for future enhancements.
