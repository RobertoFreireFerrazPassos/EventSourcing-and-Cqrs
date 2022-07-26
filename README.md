# Event-Sourcing and CQRS

This project uses:

- Docker orchestrator
- MediatR for CQRS
- DDD
- Entity Framework code first approach using migration
- Sql Server using SQL Server Management Studio (SSMS)
- Postgresql using PgAdmin
- RabbitMQ - MassTransit
- Event-Sourcing 
- Outbox Pattern

## Overview

<p align="center">
  <img src="https://github.com/RobertoFreireFerrazPassos/EventSourcing-and-Cqrs/blob/main/Images/project.png?raw=true">
</p>

### Kitchen architecture

#### CQRS and Event Sourcing

<p align="center">
  <img src="https://github.com/RobertoFreireFerrazPassos/EventSourcing-and-Cqrs/blob/main/Images/diagram.png?raw=true">
</p>

#### Database Schema

<p align="center">
  <img src="https://github.com/RobertoFreireFerrazPassos/EventSourcing-and-Cqrs/blob/main/Images/kitchenschema.png?raw=true">
</p>

## Set up enviroment:

<details>
<summary style="font-size:14px">RabbitMQ</summary>
<p>

To access RabbitMQ: http://localhost:15672/ username and password: guest / guest

</p></details>

### Set up Databases

Run Docker Compose up to create database server

<details>
<summary style="font-size:14px">SqlServer database</summary>
<p>

look at docker compose file for SqlServer authentication

- ServerName: localhost
- login: sa

</p></details>

<details>
<summary style="font-size:14px">PostgreSQL database using PgAdmin</summary>
<p>

PgAdmin for manage postgreSQL:
http://localhost:16543/

look at docker compose file for PgAdmin authentication

Click in Add new server

```
Server name: postgres-db
Host Name: postgres-db
Maintenance database: Kitchen
Port: 5432
Username: simha
Password: Postgres2019!
```

</p></details>

<details>
<summary style="font-size:14px">Update database using migrations</summary>
<p>

In Visual Studio, open NuGet Package Manager Console from Tools -> NuGet Package Manager -> Package Manager Console and enter the following command:
```
add-migration Inventory (already done)
update-database --verbose
```
NOTE: Must be...
Using project 'InventoryStorage\Infrastructure\Inventory.DataAccess'.
Using startup project 'InventoryStorage\Presentation\Inventory.Api'.

```
add-migration Kitchen (already done)
update-database --verbose
```
NOTE: Must be...
Using project 'Kitchen\Infrastructure\Kitchen.DataAccess'.
Using startup project 'Kitchen\Presentation\Kitchen.Api'.

</p></details>

<details>
<summary style="font-size:14px">Run applications</summary>
<p>

Set multiple start up projects

Inventory Api: http://localhost:3000/swagger/index.html

Kitchen Api: http://localhost:3001/swagger/index.html

Receipt Api: http://localhost:3002/swagger/index.html


</p></details>

## Steps to test:

<details>
<summary style="font-size:14px">Inventory application</summary>
<p>

Add new item (/Inventory/Update):
```json
{
  "items": [
    {
      "name": "Onion",
      "price": 0.10,
      "quantity": 12,
      "unit": 1
    }
  ]
}
```

Get the id of saved items (/Inventory/Get) and update items:
```json
{
  "items": [
    {
      "id": "{{id}}",
      "name": "Onion",
      "price": 0.20,
      "quantity": 12,
      "unit": 1
    },
    {
      "name": "Garlic",
      "price": 0.20,
      "quantity": 5,
      "unit": 1
    }
  ]
}
```

Try use a item (/Inventory/Use) with quantity bigger than the value in the inventory. It will return false:
```json
{
  "items": [
    {
      "id": "{{id}}",
      "quantity": 20
    }
  ]
}
```

Use a item:
```json
{
  "items": [
    {
      "id": "{{id}}",
      "quantity": 4
    },
    {
      "id": "{{id}}",
      "quantity": 1
    }
  ]
}
```

The result will be:
```json
{
  "items": [
    {
      "id": "{{id}}",
      "name": "Onion",
      "price": 0.2,
      "quantity": 8,
      "unit": 1
    },
    {
      "id": "{{id}}",
      "name": "Garlic",
      "price": 0.2,
      "quantity": 4,
      "unit": 1
    }
  ]
}
```

You can return it (/Inventory/Return):
```json
{
  "items": [
    {
      "id": "{{id}}",
      "quantity": 4
    },
    {
      "id": "{{id}}",
      "quantity": 1
    }
  ]
}
```

The result will be:
```json
{
  "items": [
    {
      "id": "{{id}}",
      "name": "Onion",
      "price": 0.2,
      "quantity": 12,
      "unit": 1
    },
    {
      "id": "{{id}}",
      "name": "Garlic",
      "price": 0.2,
      "quantity": 5,
      "unit": 1
    }
  ]
}
```

</p></details>

<details>
<summary style="font-size:14px">Kitchen application</summary>
<p>

Get Menu

Make a order:
```json
{
  "table": 2,
  "items": [
    {
      "name": "Soup",
      "quantity": 2
    }
  ]
}
```

Reserve a order using OrderId

</p></details>

<details>
<summary style="font-size:14px">Receipts application</summary>
<p>

See Receipt

Expected result:
```json
[
  {
    "id": "03add627-f742-4ceb-b344-d3ee068fdbe8",
    "messageType": "OrderCreatedCommand",
    "timestamp": "2022-08-28T17:37:12.15547",
    "aggregateId": "d236a7ef-c917-457c-aa5f-346847f35173",
    "data": "{\"Items\": [{\"Name\": \"Soup\", \"Quantity\": 2}], \"Table\": 2}"
  },
  {
    "id": "4366945d-41c1-459b-91b2-de2cb0b9fbf2",
    "messageType": "OrderReservedCommand",
    "timestamp": "2022-08-28T17:38:18.321107",
    "aggregateId": "d236a7ef-c917-457c-aa5f-346847f35173",
    "data": "{\"OrderId\": \"ab5e8495-464c-41bb-95d4-6465da67927f\"}"
  }
]
```

</p></details>

# References:

<details>
<summary style="font-size:14px">Reference links</summary>
<p>

https://www.jobsity.com/blog/getting-started-with-background-tasks-in-asp.net-core-webapi

https://medium.com/medialesson/run-and-manage-periodic-background-tasks-in-asp-net-core-6-with-c-578a31f4b7a3

https://www.c-sharpcorner.com/article/two-phase-commit-protocol-in-c-sharp/#:~:text=In%20this%20article%2C%20you%20will,phase%20commit%20protocol%20in%20C%23.&text=Two%20phase%20commit%20protocol%20is,single%20transaction%20or%20discrete%20transaction.

IHttpClientFactory:

https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests

Project:

https://github.com/evgeniy-khist/postgresql-event-sourcing/tree/v2

Mediatr:

https://henriquemauri.net/mediatr-no-net-6-0/

https://www.youtube.com/watch?v=YzOBrVlthMk&ab_channel=NickChapsas

EntityFramework

https://www.entityframeworktutorial.net/efcore/entity-framework-core-console-application.aspx

https://www.npgsql.org/efcore/mapping/json.html?tabs=data-annotations%2Cpoco

https://www.macoratti.net/20/07/efc_seed1.htm

Optimistic Concurrency:

https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/handling-concurrency-with-the-entity-framework-in-an-asp-net-mvc-application


</p></details>

