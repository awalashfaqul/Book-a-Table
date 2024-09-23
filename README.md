## API Documentation

### 1. Board API

#### a. Get all Boards:
**Endpoint**: `GET /api/boards`  
**Request**: No input needed  
**Response**:
```json
[
  {
    "boardID": 1,
    "boardNum": 5,
    "totalSeats": 4,
    "boardType": "Family"
  }
]
```
**HTTP Status**: `200 OK`

#### b. Create a new Board:
**Endpoint**: `POST /api/boards`  
**Request**:
```json
{
  "boardNum": 6,
  "totalSeats": 4,
  "boardType": "Conference"
}
```
**Response**:
```json
{
  "boardID": 2,
  "boardNum": 6,
  "totalSeats": 4,
  "boardType": "Conference"
}
```
**HTTP Status**: `201 Created`

#### c. Update a Board:
**Endpoint**: `PUT /api/boards/1`  
**Request**:
```json
{
  "boardID": 1,
  "boardNum": 7,
  "totalSeats": 6,
  "boardType": "Single"
}
```
**Response**:
```json
{
  "boardID": 1,
  "boardNum": 7,
  "totalSeats": 6,
  "boardType": "Single"
}
```
**HTTP Status**: `200 OK`

#### d. Delete a Board:
**Endpoint**: `DELETE /api/boards/2`  
**Request**: No input needed  
**Response**: `204 No Content`

---

### 2. Customer API

#### a. Get all Customers:
**Endpoint**: `GET /api/customers`  
**Request**: No input needed  
**Response**:
```json
[
  {
    "custID": 1,
    "custFirstname": "Jasim",
    "custLastname": "Uddin",
    "custPhone": "01911344607",
    "custEmail": "jasim.uddin@yahoo.com"
  }
]
```
**HTTP Status**: `200 OK`

#### b. Create a new Customer:
**Endpoint**: `POST /api/customers`  
**Request**:
```json
{
  "custFirstname": "Will",
  "custLastname": "Smith",
  "custPhone": "987654321",
  "custEmail": "will.smith@abc.com",
  "custStreet": "Main St",
  "custHousenum": "10",
  "custCity": "Vällingby",
  "custZipcode": "12345",
  "custState": "Stockholm"
}
```
**Response**:
```json
{
  "custID": 2,
  "custFirstname": "Will",
  "custLastname": "Smith",
  "custPhone": "987654321",
  "custEmail": "will.smith@abc.com"
}
```
**HTTP Status**: `201 Created`

#### c. Update a Customer:
**Endpoint**: `PUT /api/customers/1`  
**Request**:
```json
{
  "custID": 1,
  "custFirstname": "Johnathan",
  "custLastname": "Dahlen",
  "custPhone": "123456789",
  "custEmail": "johnathan@xyz.com"
}
```
**Response**:
```json
{
  "custID": 1,
  "custFirstname": "Johnathan",
  "custLastname": "Dahlen",
  "custPhone": "123456789",
  "custEmail": "johnathan@xyz.com"
}
```
**HTTP Status**: `200 OK`

#### d. Delete a Customer:
**Endpoint**: `DELETE /api/customers/2`  
**Request**: No input needed  
**Response**: `204 No Content`

---

### 3. Booking API

#### a. Get all Bookings:
**Endpoint**: `GET /api/bookings`  
**Request**: No input needed  
**Response**:
```json
[
  {
    "bookingID": 1,
    "custID": 1,
    "boardID": 2,
    "bookingDate": "2024-09-30",
    "bookingTime": "19:00",
    "numberOfPeople": 4
  }
]
```
**HTTP Status**: `200 OK`

#### b. Create a new Booking:
**Endpoint**: `POST /api/bookings`  
**Request**:
```json
{
  "custID": 2,
  "boardID": 1,
  "bookingDate": "2024-10-01",
  "bookingTime": "18:00",
  "numberOfPeople": 2
}
```
**Response**:
```json
{
  "bookingID": 2,
  "custID": 2,
  "boardID": 1,
  "bookingDate": "2024-10-01",
  "bookingTime": "18:00",
  "numberOfPeople": 2
}
```
**HTTP Status**: `201 Created`

#### c. Update a Booking:
**Endpoint**: `PUT /api/bookings/1`  
**Request**:
```json
{
  "bookingID": 1,
  "custID": 1,
  "boardID": 2,
  "bookingDate": "2024-10-02",
  "bookingTime": "20:00",
  "numberOfPeople": 3
}
```
**Response**:
```json
{
  "bookingID": 1,
  "custID": 1,
  "boardID": 2,
  "bookingDate": "2024-10-02",
  "bookingTime": "20:00",
  "numberOfPeople": 3
}
```
**HTTP Status**: `200 OK`

#### d. Delete a Booking:
**Endpoint**: `DELETE /api/bookings/2`  
**Request**: No input needed  
**Response**: `204 No Content`

---

### 4. Menu Item API

#### a. Get all Menu Items:
**Endpoint**: `GET /api/menuitems`  
**Request**: No input needed  
**Response**:
```json
[
  {
    "menuItemID": 1,
    "name": "Pizza",
    "price": 12.99,
    "isAvailable": true
  }
]
```
**HTTP Status**: `200 OK`

#### b. Create a new Menu Item:
**Endpoint**: `POST /api/menuitems`  
**Request**:
```json
{
  "name": "Pasta",
  "price": 10.99,
  "isAvailable": true
}
```
**Response**:
```json
{
  "menuItemID": 2,
  "name": "Pasta",
  "price": 10.99,
  "isAvailable": true
}
```
**HTTP Status**: `201 Created`

#### c. Update a Menu Item:
**Endpoint**: `PUT /api/menuitems/1`  
**Request**:
```json
{
  "menuItemID": 1,
  "name": "Pizza",
  "price": 14.99,
  "isAvailable": true
}
```
**Response**:
```json
{
  "menuItemID": 1,
  "name": "Pizza",
  "price": 14.99,
  "isAvailable": true
}
```
**HTTP Status**: `200 OK`

#### d. Delete a Menu Item:
**Endpoint**: `DELETE /api/menuitems/2`  
**Request**: No input needed  
**Response**: `204 No Content`

---

### Error Handling ###

The API responds with appropriate HTTP status codes for error handling:
- 400 Bad Request: When the request is malformed or invalid (e.g., ID mismatch during update).
- 404 Not Found: When the requested resource does not exist in the database.
