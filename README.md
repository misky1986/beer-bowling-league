# Beer Bowling League

The following application is mainly created because my friends and I plays beer bowling once a year and we are quite competetive about it.
Therefore I thought that i might aswell create and application so we are able to:
* We tend to have the same problems every year setting up a tournament
* Keep track of statictics for the current tournamnet but also all time stats

In this way it is not up to discussion who has won the most time or made the most hit of all time.

I am also doing this because i love to solve problems and learn new technologies.

## Architecture
I'am  aiming at creating an architecture that uses some of the modern framework and technologies because I like to play around with new frameworks and hopefully i learn from it.

The application will be consist of multiple microservices that will communicate via http, possibly by a message broker, but that I have not decided yet.
Every microservice should only have one responsebility and one responsebility. Furthermore every microservice will also have their own database, in order to be fully decoupled.
I am aware that this will increase the complexity once data is queryed in the application because data now needs to be found across multiple microservices, and therefore multiple databases.

Below I have drawn my basic idea of how the architecture of the application would look like.

```
INSERT PICTURE
```

### Microservice structure

All the micro-services will be constructed as shown below

<p align="center">
  <img src="images/micro-service.png" />
</p>

They will all communicate via http to and from the micro-service.

Desribe the logical layers.

How to use Automapper

## Technologies and Frameworks
Docker
Kubernetes
.Net Core 3.1.100
etc.

## Blog
My blog https://misky1986.github.io/misky-blog/ will be updated as I progress with the application. 

## References
https://docs.microsoft.com/en-us/dotnet/architecture/microservices/
