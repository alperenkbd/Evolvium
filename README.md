# Evolvium: Student Automation Project

## Detailed Design and Analysis Document

### Contents

1. [Introduction](#introduction)
2. [Analysis of Project](#analysis-of-project)
    - [User Interface Design](#user-interface-design)
    - [Business Logic](#business-logic)
    - [API](#api)
    - [Data Storage](#data-storage)
3. [Logical Design](#logical-design)
4. [State Invariants](#state-invariants)
5. [Data Design](#data-design)
6. [Tools](#tools)

---

### Introduction

This project aims to follow students’ progress, calculate grades automatically, and create reports for summaries. The project consists of seven screens: Login, Dashboard, Student Management, Course Management, Module Management, Assessment Management, and Grades/Results Screens. This document explains how the project is designed, the relationship between screens, their functionalities, and the project’s layers.

---

### Analysis of Project

#### User Interface Design

- Design emphasizes user-friendly navigation and a clear layout.

#### Business Logic

1. **Navigation Logic**
    - Utilizes a `NavigationService` class for smooth navigation.
    - Pages are dynamically identified using reflection.
    - Includes a `NavigateTo` method to pass parameters between pages.

2. **ViewModel and Command Logic**
    - `ModulesViewModel` manages module-related interactions.
    - Commands:
        - `LoadModulesCommand`: Fetches data asynchronously.
        - `EditCommand`: Navigates to the editing page with module details.

3. **Data Handling Logic**
    - Uses `HttpClient` to interact with the REST API.
    - Implements robust error handling.

4. **Parameter Passing**
    - Ensures dynamic page binding and context sharing.

5. **Dependency Management**
    - Employs a `ServiceProvider` for dependency injection.

6. **Command Triggering**
    - Commands are bound to UI actions.

#### API

- The application integrates with a REST API hosted locally.
- Endpoint: `/api/Modules`
- Supports CRUD operations.
- Implements asynchronous programming for smooth API interaction.

#### Data Storage

- Relies on API for data fetching; no local storage.
- Uses `ObservableCollection<Module>` for dynamic updates.
- Requires active network connection for functionality.

---

### Logical Design

- Based on the MVVM pattern:
    - **Model**: Represents data structures (e.g., `Module` objects).
    - **ViewModel**: Manages business logic and state.
    - **View**: UI components bound to the ViewModel.
- Navigation handled by `NavigationService` for decoupled logic.
- Commands and data binding ensure dynamic user interaction.

---

### State Invariants

- Ensures consistency between `ModulesViewModel` and API data.
- Validates parameters for navigation and command execution.
- Handles errors gracefully to maintain a stable user experience.

---

### Data Design

- Defines `Module` objects with attributes such as `ModuleId`, `Name`, and `Description`.
- Uses `ObservableCollection` for real-time UI updates.
- Validates data before integration into the application.
- Incorporates robust error handling for a seamless user experience.

---

### Tools

- **.NET Framework**: Core platform for application logic.
- **XAML**: Handles UI design with declarative syntax.
- **HttpClient**: Manages REST API communication.
- **NavigationService**: Custom service for navigation logic.
- **Visual Studio**: IDE for development and debugging.
- **Git**: Version control for tracking changes and collaboration.

---
