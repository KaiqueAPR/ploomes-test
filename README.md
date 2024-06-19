# Ploomes Test

API URL: [ploomestestkaique.azurewebsites.net](https://ploomestestkaique.azurewebsites.net/)

Swagger URL: [ploomestestkaique.azurewebsites.net](https://ploomestestkaique.azurewebsites.net/swagger)

# Description:
This API aims to provide a CRUD for the Person entity. The API allows Create, Get All Persons, Get Person by ID, Update Person by ID, and Delete Person by ID. The backend (C#) and the database (SQL Server) are deployed on Azure.

# Requests:

## *Get By Id*

Request:
```
curl --location 'https://localhost:7278/api/persons/2'
```

Response:
```
{
    "id": 2,
    "name": "Kaique Araujo",
    "document": "55544411122",
    "email": "kaiquepinho2010@hotmail.com",
    "phone": "13999999999",
    "address": "Street Test, Number 1",
    "state": "Sao Paulo",
    "zipCode": "11111111",
    "country": "Brazil"
}
```

## *Create Person*

Request:
```
curl --location 'https://localhost:7278/api/persons' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Name": "Kaique",
    "Document": "55544411122",
    "Email": "Kaique2010@hotmail.com",
    "Phone": "13999999999",
    "Address": "Street Test, Number 1",
    "State": "Sao Paulo",
    "ZipCode": "11111111",
    "Country": "Brazil" 
}'
```

Response:
```
{
    "id": 1,
    "name": "Kaique",
    "document": "55544411122",
    "email": "Kaique2010@hotmail.com",
    "phone": "13999999999",
    "address": "Street Test, Number 1",
    "state": "Sao Paulo",
    "zipCode": "11111111",
    "country": "Brazil"
}
```

## *Get All*

Request:
```
curl --location 'https://localhost:7278/api/persons'
```

Response:
```
    {
        "id": 1,
        "name": "Kaique",
        "document": "55544411122",
        "email": "Kaique2010@hotmail.com",
        "phone": "13999999999",
        "address": "Street Test, Number 1",
        "state": "Sao Paulo",
        "zipCode": "11111111",
        "country": "Brazil"
    }
```

## *Delete By Id*

Request:
```
curl --location --request DELETE 'https://localhost:7278/api/persons/3'
```

Response:
```
```

## *Update By Id*

Request:
```
curl --location --request PUT 'https://localhost:7278/api/persons/1' \
--header 'Content-Type: application/json' \
--data-raw '{
    "Name": "Kaique Araujo Pinholato Ribeiro",
    "Document": "55544411133",
    "Email": "kaiquepinho2010@hotmail.com",
    "Phone": "13999999999",
    "Address": "Street Test, Number 1",
    "State": "Sao Paulo",
    "ZipCode": "11111111",
    "Country": "Brazil" 
}'
```

Response:
```
{
    "message": "The Person with ID equals to 1 was successfully changed!"
}
```
