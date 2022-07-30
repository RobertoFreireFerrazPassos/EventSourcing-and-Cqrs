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

1 - Implement CQRS

https://www.youtube.com/watch?v=YzOBrVlthMk&ab_channel=NickChapsas

https://henriquemauri.net/mediatr-no-net-6-0/

Implement two phase commit between both databases (Event Store and Read)

https://www.c-sharpcorner.com/article/two-phase-commit-protocol-in-c-sharp/#:~:text=In%20this%20article%2C%20you%20will,phase%20commit%20protocol%20in%20C%23.&text=Two%20phase%20commit%20protocol%20is,single%20transaction%20or%20discrete%20transaction.


2 - Cretate Event Store Database

use read-write connection string

3 - Cretate Read Database

use readonly connection string

4 - Create Oubox Handler with background tasks

https://www.jobsity.com/blog/getting-started-with-background-tasks-in-asp.net-core-webapi

https://medium.com/medialesson/run-and-manage-periodic-background-tasks-in-asp-net-core-6-with-c-578a31f4b7a3

5 - Add Kafka

6 - Add Order Notification

console app wich display the order when is complete 


## Steps to test:



# References:

https://github.com/evgeniy-khist/postgresql-event-sourcing/tree/v2