# AccessHub

AccessHub is a modern Role-Based Access Control (RBAC) system built with .NET 8.0, implemented as a Blazor Server application with interactive components for efficient access management.

## 🚀 Features

- **Interactive UI**: Built with Blazor Server components for a responsive user experience
- **Permission Management**: Comprehensive permission handling through dedicated services and repositories
- **Secure by Default**: Implements HTTPS redirection and HSTS for enhanced security
- **Logging**: Built-in console and debug logging with configurable log levels
- **Anti-forgery Protection**: Integrated anti-forgery measures for form submissions

## 🛠️ Prerequisites

- .NET 8.0 SDK
- Visual Studio 2022 or Visual Studio Code
- A modern web browser

## 📦 Installation

1. Clone the repository:
   ```bash
   git clone [your-repository-url]
   cd AccessHub
   ```

2. Open the solution in Visual Studio:
   ```
   AccessHub.sln
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

## 🏗️ Project Structure

- `AccessHub/` - Main project directory
  - `Components/` - Blazor components and pages
  - `Models/` - Domain models
  - `Services/` - Business logic services
  - `Repositories/` - Data access layer
  - `Utils/` - Utility classes and helpers
  - `wwwroot/` - Static files (CSS, JS, etc.)
  - `Program.cs` - Application startup and configuration

## 🔧 Configuration

1. Development settings can be configured in `appsettings.Development.json`
2. Production settings should be configured in `appsettings.json`
3. Logging levels can be adjusted in `Program.cs`

## 🚦 Usage

1. Start the application:
   ```bash
   dotnet run
   ```

2. Access the web interface:
   ```
   https://localhost:xxxx
   ```
   (The exact port will be displayed in the console when you run the application)

## 🔐 Security Features

- HTTPS redirection enabled by default
- HSTS (HTTP Strict Transport Security) in production
- Anti-forgery token validation
- Secure cookie handling

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🆘 Support

For support and questions, please open an issue in the repository.

---
Built with ❤️ using .NET 8.0 and Blazor Server 