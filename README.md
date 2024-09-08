# Customer Feedback Management Web Application



A web application built with ASP.NET Core MVC to manage customer feedback submissions and provide an admin dashboard to view and manage the feedback.



## Table of Contents



- [Overview](#overview)

- [Features](#features)

- [Getting Started](#getting-started)

  - [Prerequisites](#prerequisites)

  - [Installation](#installation)

  - [Running the Application](#running-the-application)

- [Usage](#usage)

  - [Feedback Submission](#feedback-submission)

  - [Admin Dashboard](#admin-dashboard)

- [Technologies Used](#technologies-used)

- [Contributing](#contributing)

- [License](#license)

- [Contact](#contact)



## Overview



This web application allows customers to submit feedback via a form, which is stored in a database. The admin dashboard provides a way to view and manage all submitted feedback.



## Features



- **Feedback Submission:** Customers can submit feedback using a form.

- **Admin Dashboard:** Admins can view and delete feedback entries.

- **Validation:** Server-side and client-side validation for user inputs.

- **Basic Feedback Management:** Ability to view and delete feedback entries from the admin dashboard.



## Getting Started



### Prerequisites



- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

- [Visual Studio 2022](https://visualstudio.microsoft.com/) or any preferred C# IDE.

- [SQL Server LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-2017-express-localdb) or another SQL Server instance for the database.



### Installation



1. **Clone the Repository:**



   ```bash

   git clone https://github.com/yourusername/customer-feedback-app.git

   cd customer-feedback-app

    Install Dependencies:

    Open the solution in Visual Studio and restore NuGet packages by right-clicking on the solution in the Solution Explorer and selecting Restore NuGet Packages.

    Set Up the Database:
        Open the Package Manager Console in Visual Studio.
        Run the following commands to create the database:

    bash
    Always show details

    Update-Database

Running the Application

    Start the Application:
        In Visual Studio, press F5 or click the Run button to start the application.
        The application will launch in your default web browser.

    Access the Application:
        Feedback Submission Form: Navigate to /Feedback/Index to submit feedback.
        Admin Dashboard: Navigate to /Admin/Index to view and manage feedback.

Usage
Feedback Submission

    Go to the Feedback Submission page to fill out the form.
    Enter your Name, Email, select Feedback Type, and provide a Message.
    Click Submit Feedback to save the feedback in the database.

Admin Dashboard

    Access the Admin Dashboard to view all submitted feedback.
    Use the Delete button next to each entry to remove feedback from the database.

Technologies Used

    ASP.NET Core MVC - Web framework
    Entity Framework Core - ORM for database access
    SQL Server - Database for storing feedback
    HTML/CSS - Frontend development
    JavaScript - Client-side validation
    Bootstrap (optional) - Styling and layout

Contributing

Contributions are welcome! Please follow these steps:

    Fork the repository.
    Create a new branch (git checkout -b feature/your-feature).
    Make your changes.
    Commit your changes (git commit -m 'Add some feature').
    Push to the branch (git push origin feature/your-feature).
    Open a Pull Request.

License

This project is licensed under the MIT License - see the LICENSE file for details.
Contact

    Your Name - sjr.dev@proton.me
    GitHub - [https://github.com/yourusername """](https://github.com/Sammy-John)
