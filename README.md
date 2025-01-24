# WebShop Application

WebShop Application is a demo project consisting of a **backend** implemented in .NET 8 Web API and a **frontend** implemented in Angular 19. Both applications are containerized using Docker and can be run together via Docker Compose.

## Technologies Used

### Backend WebShop.Api
- **.NET 8 Web API**
- RESTful API
- Dependency Injection
- Logging
- Docker

### Frontend WebShop.UI
- **Angular 19**
- Responsive UI
- Communication with backend API

### Containerization
- Docker & Docker Compose

---

## Getting Started

To run the project locally using Docker Compose, follow these steps:

### Prerequisites
1. Install **Docker** and **Docker Compose**:
   - [Docker Installation Guide](https://docs.docker.com/get-docker/)
   - Docker Compose is included with Docker Desktop.

2. Clone this repository
3. In the root folder of repository (where docker-compose file is placed) run the command:
    docker compose up --build
4. The frontend will be up and run on http://localhost:4200
5. The backend will be up and run on http://localhost:5085 and also on the same address provides API specification (swagger)
6. When you want to stop containers run the following command
   docker-compose down
 
