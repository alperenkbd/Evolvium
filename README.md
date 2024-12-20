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

Evolvium is an advanced student automation project designed to streamline academic management processes, including tracking student progress, automating grade calculations, and generating detailed reports. This application showcases my expertise in software development, from conceptual design to implementation, focusing on both technical excellence and user-centric solutions.

Built on the .NET framework, the project adopts the MVVM (Model-View-ViewModel) architectural pattern to ensure maintainability and scalability. The front-end is developed using XAML, leveraging its declarative syntax to create a dynamic and responsive user interface. The application integrates seamlessly with RESTful APIs for real-time data exchange, showcasing my skills in API design and consumption, as well as asynchronous programming with HttpClient.

Evolvium includes sophisticated navigation and dependency management systems. I implemented a custom NavigationService to enhance modularity and flexibility, and utilized a ServiceProvider for efficient dependency injection. These approaches demonstrate my ability to apply design principles such as separation of concerns and reusable components.

The back-end architecture emphasizes dynamic data fetching and error handling, ensuring a robust user experience even under adverse conditions. By leveraging ObservableCollection for real-time data updates, I combined client-side efficiency with server-side data accuracy. Additionally, my use of Git for version control highlights my ability to manage collaborative development and ensure code reliability.

This project reflects my strengths in problem-solving, technical architecture, and full-stack development. It is a testament to my ability to deliver efficient, scalable, and user-friendly solutions tailored to complex requirements. I am confident that my technical expertise and attention to detail make me a valuable asset to any team looking for a dedicated and innovative software developer.



## Images from App

### Images from Public Directory

### Image 1
![Image 1](https://github.com/alperenkbd/Evolvium/blob/master/Evolvium/Public/1.png)

### Image 2
![Image 2](https://github.com/alperenkbd/Evolvium/blob/master/Evolvium/Public/2.png)

### Image 3
![Image 3](https://github.com/alperenkbd/Evolvium/blob/master/Evolvium/Public/3.png)

### Image 4
![Image 4](https://github.com/alperenkbd/Evolvium/blob/master/Evolvium/Public/4.png)

### Image 5
![Image 5](https://github.com/alperenkbd/Evolvium/blob/master/Evolvium/Public/5.png)

### Image 6
![Image 6](https://github.com/alperenkbd/Evolvium/blob/master/Evolvium/Public/6.png)

### Image 7
![Image 7](https://github.com/alperenkbd/Evolvium/blob/master/Evolvium/Public/7.png)

### Image 8
![Image 8](https://github.com/alperenkbd/Evolvium/blob/master/Evolvium/Public/8.png)

### Image 9
![Image 9](https://github.com/alperenkbd/Evolvium/blob/master/Evolvium/Public/9.png)

### Image 10
![Image 10](https://github.com/alperenkbd/Evolvium/blob/master/Evolvium/Public/10.png)

### Image 11
![Image 11](https://github.com/alperenkbd/Evolvium/blob/master/Evolvium/Public/11.png)

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
