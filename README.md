# Cinema allocations bounded context workshop

## Requirements

### Java

Java 8 or higher
Maven
Lombok plugin

### C#

.net Core 2.1

## Exercise

### lab 1

Start on main branch by implementing the tests `TicketBoothShould` by doing outside-in TDD. We already setup most scaffolding with an aenemic Domain Model to help you. You can find the stubs for the MovieScreening state at `Stubs/`. In Stubs you can create your own examples by following the json schema that is already there. It all comes down to the `showId` that is being used in the tests.

We use the following naive first design of our model to implement with outside-in TDD:

![Proposed Model](proposed-model.jpg)

the result can be find at lab1end

### lab 2

We have added two more test to `TicketBoothShould` for you to implement. In this lab you will focus on implementing the adjacent seating rule. We have added a new Stub for you to use which you can checkout in `/Stubs/README.MD`. The model has not changed!

The result can be found in lab2end

### lab 3

In lab 3 you will start implementing a ORM model that splits the database model from our domain model. We do this with the ports and adapters aka Hexagonal architecture. There is a new project/folder called CinemaAllocationsInfra were we need to add our code.

#### Java

With Java we will use spring boot. You need to use the test called `MovieScreeningRepositoryIntegrationTest` that can test if your JPA model work. Then you need to implement `JPAMovieScreeningRepository` and create a unit test yourself to test your mapping from your JPA model to Domain model.