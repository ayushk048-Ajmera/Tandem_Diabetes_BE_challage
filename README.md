# Tandem Diabetes BE Challenge



The GET endpoint should allow for retrieval by email address. The GET endpoint does not need to allow for retrieval by 
any other properties. Though we asked for the create endpoint to take first, middle, and last names separately; we’d 
like the GET endpoint to just-in-time convert the name into a single field like this: 

```
{ 
 “userId”: “54c4e684-0a6a-449d-b445-61ddd12ffd3d”, 
 “name”: “Matthew Decker Lund”, 
 “phoneNumber”: “555-555-5555”, 
 “emailAddress”: “matt@awesomedomain.com” 
} 

```

## APIs List
Get all Users
```
GET /api/users
```
Response 200
```
[
    { 
        “userId”: “54c4e684-0a6a-449d-b445-61ddd12ffd3d”, 
        “name”: “Matthew Decker Lund”, 
        “phoneNumber”: “555-555-5555”, 
        “emailAddress”: “matt@awesomedomain.com” 
    },
    { 
        “userId”: “54c4e684-0a6a-449d-b445-61ddd12ffd3d”, 
        “name”: “Matthew Decker Lund”, 
        “phoneNumber”: “555-555-5555”, 
        “emailAddress”: “matt@awesomedomain.com” 
    }, 
]
```

Get User By Email Address
```
GET /api/users?email="ayush@xyt.com"
```
Response 200
```
    { 
        “userId”: “54c4e684-0a6a-449d-b445-61ddd12ffd3d”, 
        “name”: “Matthew Decker Lund”, 
        “phoneNumber”: “555-555-5555”, 
        “emailAddress”: “matt@awesomedomain.com” 
    }

```


Create User
```
POST /api/users
```
Request body 
```
    { 
        “firstName”: “Matthew”, 
        “middleName”: “Decker”, 
        “lastName”: ”Lund”, 
        “phoneNumber”: “555-555-5555”, 
        “emailAddress”: “matt@awesomedomain.com” 
    }

```
Response 201
```
{
  "userId": "df03d450-d8d1-4be4-b0bf-1336d5344bbf",
  "fullName": "Matthew Decker Lund",
  "phoneNumber": "555-555-5555",
  "emailAddress": "matt@awesomedomain.com"
}
```

for additional Responses : https://localhost:7076/swagger/index.html

## Health check endpoint
https://localhost:7076/health

## Docker

Run following command on terminal to run Docker container
```
> docker build -t tandemimage .
```
```
> docker run -d -p 8080:80 --name tandem  tandemimage
```



## Integration Tests:


![image](https://user-images.githubusercontent.com/75988502/190861310-10fd2a8a-6fb6-4927-a803-20f37b816f65.png)

