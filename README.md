# Event-Sourcing and CQRS

## Overview

<p align="center">
  <img src="https://github.com/RobertoFreireFerrazPassos/EventSourcing-and-Cqrs/blob/main/Images/project.png?raw=true">
</p>

CQRS and Event Sourcing

<p align="center">
  <img src="https://github.com/RobertoFreireFerrazPassos/EventSourcing-and-Cqrs/blob/main/Images/diagram.png?raw=true">
</p>


## Next steps:


## Steps to test:

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

Try use a quantity bigger than the value in the inventory. It must return false:
```json
{
  "items": [
    {
      "id": "8120d5a4-356e-4d62-abf9-aa02afa32147",
      "name": "Onion",
      "price": 0.2,
      "quantity": 20,
      "unit": 1
    }
  ]
}
```

Use a item (/Inventory/Use)
```json
{
  "items": [
    {
      "id": "8120d5a4-356e-4d62-abf9-aa02afa32147",
      "name": "Onion",
      "price": 0.2,
      "quantity": 4,
      "unit": 1
    },
    {
      "id": "3ee9b62c-8c51-4570-bb81-6bef95775b08",
      "name": "Garlic",
      "price": 0.2,
      "quantity": 1,
      "unit": 1
    }
  ]
}
```

The result will be:
```json
{
  "items": [
    {
      "id": "8120d5a4-356e-4d62-abf9-aa02afa32147",
      "name": "Onion",
      "price": 0.2,
      "quantity": 8,
      "unit": 1
    },
    {
      "id": "3ee9b62c-8c51-4570-bb81-6bef95775b08",
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
      "id": "8120d5a4-356e-4d62-abf9-aa02afa32147",
      "name": "Onion",
      "price": 0.2,
      "quantity": 4,
      "unit": 1
    },
    {
      "id": "3ee9b62c-8c51-4570-bb81-6bef95775b08",
      "name": "Garlic",
      "price": 0.2,
      "quantity": 1,
      "unit": 1
    }
  ]
}
```

The result will be:
```json
{
  "items": [
    {
      "id": "8120d5a4-356e-4d62-abf9-aa02afa32147",
      "name": "Onion",
      "price": 0.2,
      "quantity": 12,
      "unit": 1
    },
    {
      "id": "3ee9b62c-8c51-4570-bb81-6bef95775b08",
      "name": "Garlic",
      "price": 0.2,
      "quantity": 5,
      "unit": 1
    }
  ]
}
```

# References:

https://github.com/evgeniy-khist/postgresql-event-sourcing/tree/v2

https://www.jobsity.com/blog/getting-started-with-background-tasks-in-asp.net-core-webapi

https://medium.com/medialesson/run-and-manage-periodic-background-tasks-in-asp-net-core-6-with-c-578a31f4b7a3

https://www.c-sharpcorner.com/article/two-phase-commit-protocol-in-c-sharp/#:~:text=In%20this%20article%2C%20you%20will,phase%20commit%20protocol%20in%20C%23.&text=Two%20phase%20commit%20protocol%20is,single%20transaction%20or%20discrete%20transaction.

https://www.youtube.com/watch?v=YzOBrVlthMk&ab_channel=NickChapsas

https://henriquemauri.net/mediatr-no-net-6-0/

https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/handling-concurrency-with-the-entity-framework-in-an-asp-net-mvc-application

https://docs.microsoft.com/en-us/aspnet/web-forms/overview/data-access/editing-inserting-and-deleting-data/implementing-optimistic-concurrency-cs
