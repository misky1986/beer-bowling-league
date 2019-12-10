# Beer Bowling League

The following application is mainly created because my friends and I plays beer bowling once a year and we are quite competetive about it.
Therefore I thought that i might aswell create and application so we are able to:
* We tend to have the same problems every year setting up a tournament
* Keep track of statictics for the current tournamnet but also all time stats

In this way it is not up to discussion who has won the most time or made the most hit of all time.

I am also doing this because i love to solve problems and learn new technologies.

## Architecture
I aim for creating an architecture that is modern which makes makes it possible to use technologies like Docker and Kubernetes.

The application would be build up by microservices that should only have one responsebility and decoubled from the rest of the system.
I plan to introduce a message broker that should handle event based communication between the microserives.

Below I have drawn my basic idea of how the architecture of the application would look like.

```
INSERT PICTURE
```

## Technologies and Frameworks
Docker
Kubernetes
.Net Core 3.1.100
etc.

## Blog
My blog https://misky1986.github.io/misky-blog/ will be updated as I progress with the application. 

## References
https://docs.microsoft.com/en-us/dotnet/architecture/microservices/