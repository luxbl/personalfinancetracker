# Personal Finance Tracker

## Overview
The Personal Finance Tracker is a web-based application designed to help individuals manage and track their finances efficiently. The application provides users with tools to track income, expenses, visualize financial data, and generate reports, helping them gain better control over their financial health.

## Table of Contents

* Features
* Technologies Used
* Installation
* Usage
* API Endpoints
* Project Structure
* Contributing
  
## Features
## Core Features
* **Dashboard:** Overview of finances, including income, expenses, and savings with visual charts (bar, pie, line graphs).
* **Expense and Income Tracking:** Forms to input details for expenses and income sources.
* **Reports and Visualizations:** Generate visual representations of spending patterns, budget management, and financial health.
* **Authentication:** User registration, login, and password management.
* **Data Security:** Secure handling of user data with hashed passwords and encrypted sensitive information.
## Stretch Goals
* **Budget Goals:** Allow users to set financial goals for savings and spending limits.
* **Recurring Transactions:** Automate regular income and expense entries (e.g., monthly rent, salary).
* **Mobile Optimization:** Provide a responsive interface for mobile users.
## Technologies Used
## Front-End
* HTML/CSS: Structuring and styling of the application.
* JavaScript/TypeScript: Dynamic interactions and form validations.
* Bootstrap/Tailwind CSS: CSS frameworks for responsive design.
## Back-End
* C# .NET Core: The main backend framework.
* ASP.NET Core: Web API development.
* Entity Framework Core: ORM (Object Relational Mapping) for database management.
## Database
* SQL Server: Storing user data, transactions, and other relevant information.
## Others
* Swagger: API documentation and testing.
* JWT (JSON Web Tokens): User authentication and session management.
## Installation
## Prerequisites
* .NET SDK (version X.X or higher)
* SQL Server
* Node.js and npm/yarn (for frontend development)
## Steps to Run Locally
1. Clone the repository:
git clone https://github.com/your-username/personalfinancetracker.git
2. Navigate into the project directory:cd personalfinancetracker
## Usage
* **Registration:** Users can create an account by providing their details and creating a secure password.
* **Login:** Users log in with their credentials and can start tracking their finances.
* **Dashboard:** Provides a real-time overview of the user’s financial health.
* **Transactions:** Add, update, or delete income/expense records. View reports by category, date, or source.
## API Endpoints
**Authentication**
* POST /api/auth/register: Register a new user.
* POST /api/auth/login: Login an existing user.
## Users
* GET /api/users/{id}: Fetch user profile.
* PUT /api/users/{id}: Update user profile.
## Transactions
* GET /api/transactions: Retrieve all transactions for a user.
* POST /api/transactions: Add a new transaction (income/expense).
* PUT /api/transactions/{id}: Update a transaction.
* DELETE /api/transactions/{id}: Delete a transaction.
Contributing
Contributions are welcome! Please follow these steps:


