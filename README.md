## API Documentation

### 1. Board API

#### a. Get all Boards:
**Endpoint**: `GET /api/boards`  
**Request**: No input needed  
**Response**:
```json
[
  {
    "boardID": 6,
    "boardNum": 6,
    "totalSeats": 8,
    "boardType": "Conference"
  },
  {
    "boardID": 7,
    "boardNum": 5,
    "totalSeats": 4,
    "boardType": "Family"
  },
  {
    "boardID": 8,
    "boardNum": 3,
    "totalSeats": 2,
    "boardType": "Single"
  },
  {
    "boardID": 9,
    "boardNum": 4,
    "totalSeats": 5,
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
  "totalSeats": 8,
  "boardType": "Conference"
}
```
**Response**:
```json
{
  "boardID": 6,
  "boardNum": 6,
  "totalSeats": 8,
  "boardType": "Conference"
}
```
**HTTP Status**: `201 Created`

**Request**:
```json
{
  "boardNum": 5,
  "totalSeats": 4,
  "boardType": "Family"
}```

**Response**:
```json
{
  "boardID": 7,
  "boardNum": 5,
  "totalSeats": 4,
  "boardType": "Family"
}```

**HTTP Status**: `201 Created`

**Request**:
```json
{
  "boardNum": 3,
  "totalSeats": 2,
  "boardType": "Single"
}
```
**Response**:
```json
{
  "boardID": 8,
  "boardNum": 3,
  "totalSeats": 2,
  "boardType": "Single"
}
```
**HTTP Status**: `201 Created`

**Request**:
```json
{
  "boardNum": 4,
  "totalSeats": 5,
  "boardType": "Family"
}
```
**Response**:
```json
{
  "boardID": 9,
  "boardNum": 4,
  "totalSeats": 5,
  "boardType": "Family"
}
```
**HTTP Status**: `201 Created`

#### c. Get a Boards with ID:
**Endpoint**: `GET /api/boards/8`  
**Request**: No input needed  
**Response**:
```json
{
  "boardID": 8,
  "boardNum": 3,
  "totalSeats": 2,
  "boardType": "Single"
}
```
**HTTP Status**: `200 OK`

#### d. Update a Board:
**Endpoint**: `PUT /api/boards/6`  
**Request**:
```json
{
    "boardID": 6,
    "boardNum": 6,
    "totalSeats": 6,
    "boardType": "Conference"
}
```
**Response**:
```json
curl -X 'PUT' \
  'http://localhost:5044/api/Board/6' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
    "boardID": 6,
    "boardNum": 6,
    "totalSeats": 6,
    "boardType": "Conference"
}'
```
**HTTP Status**: `200 OK`

#### e. Delete a Board with ID:
**Endpoint**: `DELETE /api/boards/2`  
**Request**: No input needed  
**Response**: `204`

---

### 2. Customer API

#### a. Get all Customers:
**Endpoint**: `GET /api/customers`  
**Request**: No input needed  
**Response**:
```json
[
  {
    "custID": 2,
    "custFirstname": "string",
    "custLastname": "string",
    "custPhone": "string",
    "custEmail": "string",
    "custStreet": "string",
    "custHousenum": "string",
    "custCity": "string",
    "custZipcode": "string",
    "custState": "string"
  },
  {
    "custID": 3,
    "custFirstname": "Will",
    "custLastname": "Smith",
    "custPhone": "987654321",
    "custEmail": "will.smith@abc.com",
    "custStreet": "Main St",
    "custHousenum": "10",
    "custCity": "Vällingby",
    "custZipcode": "12345",
    "custState": "Stockholm"
  },
  {
    "custID": 4,
    "custFirstname": "Eva",
    "custLastname": "Swedberg",
    "custPhone": "987654456",
    "custEmail": "eva.swedberg@abc.com",
    "custStreet": "St. Eriksplan",
    "custHousenum": "72",
    "custCity": "Stockholm",
    "custZipcode": "11324",
    "custState": "Stockholm"
  },
  {
    "custID": 5,
    "custFirstname": "Janet",
    "custLastname": "Jakobson",
    "custPhone": "987652367",
    "custEmail": "janet.jakobsson@xyz.se",
    "custStreet": "Eriksgatan",
    "custHousenum": "62",
    "custCity": "Stockholm",
    "custZipcode": "11324",
    "custState": "Stockholm"
  },
  {
    "custID": 6,
    "custFirstname": "Jasim",
    "custLastname": "Uddinsson",
    "custPhone": "876523679",
    "custEmail": "jasim.uddinsson@xyz.se",
    "custStreet": "Fleminggatan",
    "custHousenum": "62",
    "custCity": "Stockholm",
    "custZipcode": "11325",
    "custState": "Stockholm"
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
  "custID": 3,
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
**HTTP Status**: `201 Created`

**Request**:
```json
{
  "custFirstname": "Eva",
  "custLastname": "Swedberg",
  "custPhone": "987654456",
  "custEmail": "eva.swedberg@abc.com",
  "custStreet": "St. Eriksplan",
  "custHousenum": "72",
  "custCity": "Stockholm",
  "custZipcode": "11324",
  "custState": "Stockholm"
}
```
**Response**:
```json
{
  "custID": 4,
  "custFirstname": "Eva",
  "custLastname": "Swedberg",
  "custPhone": "987654456",
  "custEmail": "eva.swedberg@abc.com",
  "custStreet": "St. Eriksplan",
  "custHousenum": "72",
  "custCity": "Stockholm",
  "custZipcode": "11324",
  "custState": "Stockholm"
}
```
**HTTP Status**: `201 Created`

**Request**:
```json
{
  "custFirstname": "Janet",
  "custLastname": "Jakobson",
  "custPhone": "987652367",
  "custEmail": "janet.jakobsson@xyz.se",
  "custStreet": "Eriksgatan",
  "custHousenum": "62",
  "custCity": "Stockholm",
  "custZipcode": "11324",
  "custState": "Stockholm"
}
```
**Response**:
```json
{
  "custID": 5,
  "custFirstname": "Janet",
  "custLastname": "Jakobson",
  "custPhone": "987652367",
  "custEmail": "janet.jakobsson@xyz.se",
  "custStreet": "Eriksgatan",
  "custHousenum": "62",
  "custCity": "Stockholm",
  "custZipcode": "11324",
  "custState": "Stockholm"
}
```
**HTTP Status**: `201 Created`

**Request**:
```json
{
  "custFirstname": "Jasim",
  "custLastname": "Uddinsson",
  "custPhone": "876523679",
  "custEmail": "jasim.uddinsson@xyz.se",
  "custStreet": "Fleminggatan",
  "custHousenum": "62",
  "custCity": "Stockholm",
  "custZipcode": "11325",
  "custState": "Stockholm"
}
```
**Response**:
```json
{
  "custID": 6,
  "custFirstname": "Jasim",
  "custLastname": "Uddinsson",
  "custPhone": "876523679",
  "custEmail": "jasim.uddinsson@xyz.se",
  "custStreet": "Fleminggatan",
  "custHousenum": "62",
  "custCity": "Stockholm",
  "custZipcode": "11325",
  "custState": "Stockholm"
}
```
**HTTP Status**: `201 Created`

#### a. Get a Customer by ID:
**Endpoint**: `GET /api/customers/6`  
**Request**: No input needed  
**Response**:
```json
[
  {
    "custID": 6,
    "custFirstname": "Jasim",
    "custLastname": "Uddinsson",
    "custPhone": "876523679",
    "custEmail": "jasim.uddinsson@xyz.se",
    "custStreet": "Fleminggatan",
    "custHousenum": "62",
    "custCity": "Stockholm",
    "custZipcode": "11325",
    "custState": "Stockholm"
  }
]
```
**HTTP Status**: `200 OK`

#### c. Update a Customer:
**Endpoint**: `PUT /api/customers/1`  
**Request**:
```json
{
  "custID": 5,
  "custFirstname": "Janet",
  "custLastname": "Jakobson",
  "custPhone": "907052360",
  "custEmail": "janet.jakobsson@xyz.se",
  "custStreet": "Eriksgatan",
  "custHousenum": "32",
  "custCity": "Stockholm",
  "custZipcode": "11324",
  "custState": "Stockholm"
}
```
**Response**:
```json
{
  "custID": 5,
  "custFirstname": "Janet",
  "custLastname": "Jakobson",
  "custPhone": "907052360",
  "custEmail": "janet.jakobsson@xyz.se",
  "custStreet": "Eriksgatan",
  "custHousenum": "32",
  "custCity": "Stockholm",
  "custZipcode": "11324",
  "custState": "Stockholm"
}
```
**HTTP Status**: `204 Updated`

#### d. Delete a Customer with ID:
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
