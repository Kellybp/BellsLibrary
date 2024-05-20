# BellsLibrary

BellsLibrary is an online library management system arbitrarily inspired by Bell's love of books in Beauty and the Beast. It features a web frontend application and a .NET backend.

## Features
### User Roles

    - Librarians can add, edit, and remove books, and mark books as returned.
    - Customers can browse books and check them out. (Work In Progress)

### Frontend Application

    - Sign Up/Login/Logout: Secure user authentication allowing role specification during sign-up. (Currently Commented Out)
    - Featured Books: Displays random books with their details like Title, Author, and Cover Image.
    - Book Filtering and Sorting: Users can filter and sort books by Title, Author, and Availability.
    - Book Details: Detailed view for each book including Publisher, Publication Date, Category, ISBN, and Page Count.
    - Search Functionality: Allows searching for books based on text partially contained in the book’s title.
    - Book Management: Librarians can manage the inventory of books through the frontend interface.
    - Book Checkout: Customers can check out books available for 5 days. (Work In Progress)

### Backend (.NET Web API)

    - ASP.NET Core Web API: Backend API built using .NET 8+.
    - User Authentication and Authorization: Implemented using ASP.NET Identity. (Work In Progress)
    - ORM with Code-First Migrations: Entity Framework Core for data access and migrations.
    - SQL Server Database: Includes essential tables such as Books with fields like Title, Author, etc.
    - API Documentation: Swagger UI/OpenAPI for documenting all API endpoints.

## Additional Features

    - Seed Data: Using Bogus for .NET to seed the database with fictional book data.

## Technologies Used

    - Frontend: Bootstrap/FluentUI
    - Backend: ASP.NET Core 8+
    - Database: SQL Server / SQL Server Express
    - Authentication: ASP.NET Identity
    - API Documentation: Swagger UI
    - Data Seeding: Bogus for .NET

## Setup and Installation

   To use this sample application, follow these steps:

1. Clone the repository.
2. Open the solution in Visual Studio or your preferred IDE.
3. Set up API project:
    - Under `BellsLibrary/BellsLibrary.API.MVC`, update the database connection string in the `appsettings.json` file to point to your desired database.
    ```
    "ConnectionStrings": {
        "BellsLibrary": "<add your connection string>"
    }
    ```
    - Build the solution to restore NuGet packages and compile the code.
    - Run the database migrations to create the necessary tables and seed initial data.
    - Start the application `BellsLibrary/BellsLibrary.API.MVC`. This is a ASP.NET MVC Core Web API project. It will open up a swagger page where you can test the API endpoints.
4. Set up Blazor project:
    - Under `BellsLibrary/BellsLibrary.UI`, build the solution to restore NuGet packages and compile the code.
    - Make sure to update the API Url in appsettings.json file to point to the API project.
    ```
    "Api": {
        "Url": "https://localhost:7055"
    }
    ```
    - Under `BellsLibrary/BellsLibrary.UI`, update the database connection string in the `appsettings.json` file to point to your desired database.
    ```
    "ConnectionStrings": {
        "BellsLibraryContextConnection": "<add your connection string>"
    }
    ```
    - Start the application `BellsLibrary/BellsLibrary.UI`. This is a Blazor Server Web App project. It will open up a web page where you can interact with the application.
