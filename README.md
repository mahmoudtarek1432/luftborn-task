Hello there Luftborn Team!! (or anyone who comes across this repo :) )

First of all, thank you for inviting me to this task, I've had a blast going through it. (even though I'm currently on vacation⛵🐚)

Ahem... welcome to my UNHOLY Amalgamation of design patterns and over engineering built on a single CRUD domain Entity. 😂

The Project Hosts 2 Services:
- Auth Service
- User Service

while the Auth Service implements a really simplistic Auth flow, just your good old jwt token login and register flow, It focuses on DDD cleanliness and used 
the REPR simple interfacing using FastEndpoints lib and specifications for querying the database.
( if anyone's interested, I've got a PKCE auth flow implementation using Angular and browser service worker to prevent DNS posioning attacks )

The User Service on the other hand leans more towards an Event driven approach with the classic ASP MVC controllers, Mediator pattern and event dispatching,
Commands, domain events for handling external context's updates, event sources etc..

some of the Design Patterns used (either implemented by me or used by external/core libraries):
- Observer (RXJS)
- Factory (HTTP interceptors)
- Intercepting filter (angular guards)
- Pipline design pattern (custom error handlers and just everything imported in ASP .net 😂)
- CQRS
- Event sourcing (document database was used for it)
- fuctional chaining
- Dependency Injection
- Repository
- unit of work (yes EF counts as a unit of work, no need for extra layeers of abstraction)
- Command bus (the event handlers)
- Specification
- and the DDD concepts basically

Please feel free to reach on linked in or the repo's issues if you had any questions. have a good day ahead!!


