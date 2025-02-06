
# Gestion des Tâches (Task Management System)

Welcome to the **Gestion des Tâches** project! This is a .NET 8.0 backend application designed to manage tasks, projects, and resources efficiently. The project follows a **clean architecture** and **CQRS (Command Query Responsibility Segregation)** pattern, ensuring separation of concerns, scalability, and maintainability.

---

## 🛠️ **Project Structure**

The project is organized into multiple layers, each with a specific responsibility. Below is an overview of the key components:

### **1. Data Layer (`gestion_taches.Data`)**
- **Context**: Contains the `gestionTachesContext` for database interactions.
- **Migrations**: Includes database migration files
- **Repository**: Contains the `GenericRepository.cs` for generic CRUD operations.
- **Project File**: `gestion_taches.Data.csproj`

### **2. Domain Layer (`gestion_taches.Domain`)**
- **Commands**: Contains commands for CQRS operations:
  - `AddGenericCommand.cs`
  - `PutGenericCommand.cs`
  - `RemoveGenericCommand.cs`
- **Dto**: Data Transfer Objects (DTOs) for entities:
  - `ProjectRessourcesDto.cs`
  - `RessourcesDto.cs`
- **Queries**: Contains queries for CQRS:
  - `GetGenericQuery.cs`
  - `GetListGenericQuery.cs`
- **Handlers**: Command and query handlers for CQRS:
  - `AddGenericHandler.cs`
  - `GetGenericHandler.cs`
  - `GetListGenericHandler.cs`
  - `PutGenericHandler.cs`
  - `RemoveGenericHandler.cs`
- **Interfaces**: Contains `IGenericRepository.cs` for repository abstraction.
- **Models**: Entity models for the domain:
  - `Project.cs`
  - `Ressources.cs`
- **Project File**: `gestion_taches.Domain.csproj`

### **3. Infrastructure Layer (`gestion_taches.infra`)**
- **Dependency Injection**: Contains `DependencyContainer.cs` for IoC configuration.
- **Project File**: `gestion_taches.infra.csproj`

### **4. API Layer (`gestion_taches`)**
- **Controllers**: Contains API controllers for managing projects and resources:
  - `ProjectControlleur.cs`
  - `RessourcesControlleur.cs`
- **Properties**: Includes `launchSettings.json` for runtime configurations.
- **Mapper**: Contains `Class.cs` for AutoMapper configurations.
- **Startup Files**: `Program.cs` for application configuration.
- **App Settings**: Configuration files for different environments:
  - `appsettings.Development.json`
  - `appsettings.json`
- **Project File**: `gestion_taches.Api.csproj`
- **HTTP Requests**: Includes `gestion_taches.http` for testing API endpoints.

### **5. Root Files**
- **Solution File**: `gestion_taches.sln`
- **IDE Files**: Configuration files for Visual Studio (`.vs`) and JetBrains Rider (`.idea`).
- **Docker Support**: Includes `Dockerfile` for containerization.
- **CI/CD**: Includes `.gitlab-ci.yml` for GitLab CI/CD pipeline configuration.

---

## 🚀 **Getting Started**

Follow these steps to set up the project locally:

### **Prerequisites**
- .NET 8.0 SDK
- Docker (optional, for containerization)

### **Steps**
1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/gestion_taches.git
   cd gestion_taches
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Run the application**:
   ```bash
   dotnet run --project gestion_taches
   ```

4. **Access the API**:
   - Open your browser or API client (e.g., Postman).
   - Navigate to `http://localhost:5000` (or the specified port).

5. **Docker Setup (optional)**:
   - Build the Docker image:
     ```bash
     docker build -t gestion-taches .
     ```
   - Run the container:
     ```bash
     docker run -p 5000:80 gestion-taches
     ```

---

## 🛠️ **Technologies Used**
- **.NET 8.0**
- **CQRS Architecture**
- **Entity Framework Core**
- **AutoMapper**
- **Docker**
- **GitLab CI/CD**

---

## 🧩 **CQRS Architecture**

The project is built using the **CQRS (Command Query Responsibility Segregation)** pattern, which separates the read and write operations for better scalability and maintainability. Here's how CQRS is implemented:

### **Commands**
- **AddGenericCommand.cs**: Handles the creation of new entities.
- **PutGenericCommand.cs**: Handles the updating of existing entities.
- **RemoveGenericCommand.cs**: Handles the deletion of entities.

### **Queries**
- **GetGenericQuery.cs**: Retrieves a single entity by its ID.
- **GetListGenericQuery.cs**: Retrieves a list of entities.

### **Handlers**
- **AddGenericHandler.cs**: Executes the logic for adding new entities.
- **GetGenericHandler.cs**: Executes the logic for retrieving a single entity.
- **GetListGenericHandler.cs**: Executes the logic for retrieving a list of entities.
- **PutGenericHandler.cs**: Executes the logic for updating entities.
- **RemoveGenericHandler.cs**: Executes the logic for deleting entities.

This separation ensures that the application's read and write operations are independent, making it easier to optimize and scale.

---

## 🤝 **Contributing**

Contributions are welcome! If you'd like to contribute, please follow these steps:

1. Fork the repository.
2. Create a new branch:
   ```bash
   git checkout -b feature/YourFeature
   ```
3. Make your changes and commit them:
   ```bash
   git commit -m 'Add some feature'
   ```
4. Push to the branch:
   ```bash
   git push origin feature/YourFeature
   ```
5. Open a pull request.

---

## 👨‍💻 **Author**

**Rayen Ameur**  

