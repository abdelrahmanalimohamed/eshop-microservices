# .NET 8 Microservices: DDD, CQRS, Vertical/Clean Architecture

## Overview
This repository documents my learning journey through the "**.NET 8 Microservices: DDD, CQRS, Vertical/Clean Architecture**" course. The course focuses on building highly scalable and maintainable microservices using .NET 8 and best practices like Domain-Driven Design (DDD), Command Query Responsibility Segregation (CQRS), and Clean Architecture. It also covers advanced concepts like inter-service communication, caching, message brokers, and reverse proxies.

## What I learning
### Core Topics:
- **ASP.NET Core 8 Web API Development**
  - Minimal APIs and new features in .NET 8 and C# 12.
  - Vertical Slice Architecture with feature folders.
  - CQRS implementation using MediatR.
  - CQRS validation pipelines using FluentValidation and custom behaviors.

- **Database and Data Handling**
  - PostgreSQL database connection and containerization.
  - Marten library for transactional document DB on PostgreSQL.
  - Redis for distributed caching with Basketdb.
  - Entity Framework Core for relational database (SQL Server).
    - Code-first approach.
    - Auto-migrations on startup.
    - DDD entity configurations.

- **Domain-Driven Design (DDD)**
  - Tactical DDD concepts like Entities, Value Objects, Aggregates, and Aggregate Roots.

### Communication Between Microservices:
- **gRPC**
  - High-performance inter-service communication between Basket and Discount microservices.

- **Message Brokers**
  - RabbitMQ for asynchronous messaging.
  - MassTransit as an abstraction over RabbitMQ.
  - Publish/Subscribe with RabbitMQ topic exchange model.

### Advanced Architecture Patterns:
- **Proxy, Decorator, and Cache-aside Design Patterns**
- **API Gateways with YARP**
  - Gateway Routing Pattern.
  - Route, cluster, path, and transform configurations.
  - Rate limiting with FixedWindowLimiter.

### Cross-Cutting Concerns:
- Logging, global exception handling, and health checks.

### Deployment and Containerization:
- Dockerfile and docker-compose for multi-container setups.

## Repository Structure
```
.
├── BasketService
├── DiscountService
├── OrderingService
├── API Gateway (YARP)
├── Docker
│   ├── docker-compose.yml
│   ├── BasketService.Dockerfile
│   ├── DiscountService.Dockerfile
│   └── OrderingService.Dockerfile
├── SharedKernel
├── README.md
```

## Technologies Used
- **Programming Languages**: C#, .NET 8
- **Frameworks**: ASP.NET Core 8, MediatR, FluentValidation, Entity Framework Core
- **Databases**: PostgreSQL, Redis, SQL Server
- **Libraries and Tools**:
  - MassTransit, RabbitMQ
  - Marten
  - Mapster
  - YARP (Reverse Proxy)
  - Docker, Docker Compose

## Key Features Implemented
1. **Basket Microservice**
   - Implements Redis for distributed caching.
   - gRPC communication with Discount Service.
   - Publishes checkout events to RabbitMQ.

2. **Discount Microservice**
   - Provides gRPC services consumed by the Basket Service.

3. **Ordering Microservice**
   - Processes RabbitMQ events published by the Basket Service.

4. **API Gateway**
   - Configured with YARP for routing and rate-limiting.

## Getting Started
### Prerequisites
- .NET 8 SDK
- Docker and Docker Compose
- PostgreSQL
- Redis
- RabbitMQ

### Running the Application
1. Clone the repository:
   ```bash
   git clone <https://github.com/abdelrahmanalimohamed/eshop-microservices.git>
   cd <repo-folder>
   ```

2. Start the services using Docker Compose:
   ```bash
   docker-compose up --build
   ```

3. Access the services via the API Gateway:
   ```
   http://localhost:<gateway-port>
   ```

4. Explore the APIs using tools like Postman or Swagger.

## Future Enhancements
- Implement additional microservices.
- Add monitoring and observability tools like Prometheus and Grafana.
- Experiment with Azure/AWS deployment.

## Credits
- This repository is based on the ["[.NET 8 Microservices: DDD, CQRS, Vertical/Clean Architecture](https://www.udemy.com/course/microservices-architecture-and-implementation-on-dotnet/)"] course.

Feel free to explore, provide feedback, or fork this repository to start your own learning journey!


