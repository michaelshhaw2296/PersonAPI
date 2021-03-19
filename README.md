# PersonAPI
Allows management of people - giving the ability to view, add, delete and updating of people

## Tech stack
.Net core Web API using EF. Currently using instore memory database

## Testing API 
Use Postman to connect to the api. Run Solution locally and point postman requests to https://localhost:44399/app/people

### GetAllPeople
GET
https://localhost:44399/app/people
For Pagination
https://localhost:44399/app/people/?pageSize=2&pageNumber=1 - be 2 returned from the first page
In response headers, pagination details are returned which can be utilised by front end
![image](https://user-images.githubusercontent.com/52508037/111777200-e30c8b00-88aa-11eb-98cd-46165c9ff0bc.png)


### Get Single Person by id
GET
https://localhost:44399/app/people/{id} - eg: https://localhost:44399/app/people/1

### Add New Person
POST
In body, add JSON structure
{
    "firstName": "Add",
    "lastName": "Test",
    "age": 24,
    "email": "addtest@email.com",
    "address": "Test Address"
}

### Delete Person by Id
DELETE
https://localhost:44399/app/people/{id} eg: https://localhost:44399/app/people/1

### Update Person
PUT
https://localhost:44399/app/people/
In request body, add JSON structure
{
    "personId": 2,
    "firstName": "PUT",
    "lastName": "Test",
    "age": 24,
    "email": "addtest@email.com",
    "address": "Test Address"
}
