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