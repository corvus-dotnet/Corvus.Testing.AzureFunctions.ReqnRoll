# Corvus.Testing.AzureFunctions.ReqnRoll

[![Build Status](https://dev.azure.com/endjin-labs/Corvus.Testing.AzureFunctions.ReqnRoll/_apis/build/status/corvus-dotnet.Corvus.Testing.AzureFunctions.ReqnRoll?branchName=main)](https://dev.azure.com/endjin-labs/Corvus.Testing.AzureFunctions.ReqnRoll/_build/latest?definitionId=4&branchName=main)
[![GitHub license](https://img.shields.io/badge/License-Apache%202-blue.svg)](https://raw.githubusercontent.com/corvus-dotnet/Corvus.Testing.AzureFunctions.ReqnRoll/main/LICENSE)

A comprehensive testing framework for Azure Functions that integrates with ReqnRoll (formerly SpecFlow) to enable behavior-driven development (BDD) testing of Azure Functions projects.

## 🚀 Features

- ✅ **Programmatically start and stop Azure Functions instances** for testing
- ✅ **Support for both In-Process and Isolated Azure Functions models**
- ✅ **ReqnRoll/SpecFlow integration** with step definitions and hooks
- ✅ **Port management and conflict resolution** for parallel test execution
- ✅ **Environment variable configuration** for test scenarios
- ✅ **Process output capture and logging** for debugging
- ✅ **Graceful shutdown with fallback force termination**
- ✅ **Cross-platform support** (Windows, macOS, Linux)

## 📦 Packages

| Package | Description | NuGet |
|---------|-------------|-------|
| `Corvus.Testing.AzureFunctions` | Core functionality for managing Azure Functions instances | [![NuGet](https://img.shields.io/nuget/v/Corvus.Testing.AzureFunctions.svg)](https://www.nuget.org/packages/Corvus.Testing.AzureFunctions/) |
| `Corvus.Testing.AzureFunctions.ReqnRoll` | ReqnRoll integration for BDD testing | [![NuGet](https://img.shields.io/nuget/v/Corvus.Testing.AzureFunctions.ReqnRoll.svg)](https://www.nuget.org/packages/Corvus.Testing.AzureFunctions.ReqnRoll/) |

## 🏃 Quick Start

### Installation

```bash
# Core functionality
dotnet add package Corvus.Testing.AzureFunctions

# ReqnRoll integration
dotnet add package Corvus.Testing.AzureFunctions.ReqnRoll
```

### Basic Usage

```csharp
using Microsoft.Extensions.Logging;
using Corvus.Testing.AzureFunctions;

// Create a logger
var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
var logger = loggerFactory.CreateLogger<FunctionsController>();

// Create and start a functions instance
var controller = new FunctionsController(logger);
await controller.StartFunctionsInstanceAsync(
    path: "MyFunctionApp",     // Function project path
    port: 7071,                // Port to run on
    runtime: "net8.0"         // Runtime version
);

// Your tests here...
using var client = new HttpClient();
var response = await client.GetAsync("http://localhost:7071/api/MyFunction");

// Cleanup
await controller.TeardownFunctionsAsync();
```

### ReqnRoll Integration

```gherkin
@functionsTest
Feature: My Azure Function
    As a developer
    I want to test my Azure Function
    So that I can ensure it works correctly

Scenario: Function returns expected response
    Given I start a functions instance for the local project 'MyFunctionApp' on port 7071
    When I send a GET request to 'http://localhost:7071/api/MyFunction?name=World'
    Then I receive a 200 response code
    And the response body contains the text 'Hello, World!'
```

## 📚 Documentation

For comprehensive documentation, examples, and best practices, see:

**[📖 Complete Documentation](DOCUMENTATION.md)**

The documentation covers:
- 🏗️ **Architecture and Core Components**
- 🎯 **Usage Patterns** (per-test, per-feature, multiple apps)
- ⚙️ **Configuration Management**
- 📝 **Detailed Examples** with both unit tests and ReqnRoll scenarios
- 🔧 **Best Practices** for performance and reliability
- 🐛 **Troubleshooting Guide** for common issues

## 🎯 Use Cases

### Integration Testing
Test your Azure Functions in realistic environments with external dependencies like databases, service bus, and APIs.

### BDD Testing with ReqnRoll
Write human-readable specifications that automatically test your functions using Gherkin syntax.

### Microservices Testing
Test multiple Azure Function apps simultaneously to validate complex distributed scenarios.

### CI/CD Pipeline Testing
Automate function testing in build pipelines with reliable startup, execution, and teardown.

## 🔧 Requirements

- .NET 8.0 or later
- Azure Functions Core Tools v4
- Visual Studio 2022 or VS Code with C# extension

## 🤝 Contributing

We welcome contributions! Please see our [contributing guidelines](CONTRIBUTING.md) for details on:
- Code style and conventions
- Testing requirements
- Documentation standards
- Pull request process

## 📄 License

This project is licensed under the [Apache 2.0 License](LICENSE).

## 🙏 Acknowledgments

This project is maintained by [endjin](https://endjin.com/) and builds upon the excellent work of the Azure Functions and ReqnRoll communities.

---

*For questions, issues, or feature requests, please [open an issue](https://github.com/corvus-dotnet/Corvus.Testing.AzureFunctions.ReqnRoll/issues) on GitHub.*