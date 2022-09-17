# Tandem_Diabetes_BE_challenge

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
response 200
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
response 200
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
requestBody 
```
    { 
        “firstName”: “Matthew”, 
        “middleName”: “Decker”, 
        “lastName”: ”Lund”, 
        “phoneNumber”: “555-555-5555”, 
        “emailAddress”: “matt@awesomedomain.com” 
    }

```
response 201
```
{
  "userId": "df03d450-d8d1-4be4-b0bf-1336d5344bbf",
  "fullName": "Matthew Decker Lund",
  "phoneNumber": "555-555-5555",
  "emailAddress": "matt@awesomedomain.com"
}
```



## Integration Test Output:

![image](https://user-images.githubusercontent.com/75988502/190857746-f78a1197-1a1e-4f25-8c81-773b6e32c4e3.png)

