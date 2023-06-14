# Car Rental Application - WPF

This is a car rental application built using WPF (Windows Presentation Foundation) and C#. It allows users to manage employees, customers, available cars, and rentals in a car rental agency.

## Features

- **Employees**: Add, edit, and delete employee records including their personal information.
- **Customers**: Manage customer records including their details and contact information.
- **Cars**: View, add, update, and delete car details such as make, model, and availability.
- **Rentals**: Track and manage rental records including rental dates, customers, employees, and cars.

## Prerequisites

- Windows operating system
- Visual Studio installed
- MS SQL Server installed

## Installation and Configuration MSSQL
The application requires a database to store the data. Follow the below steps to setup database.
1. Download the ZIP archive of the project by clicking on the "Download ZIP" button.
2. Extract the contents of the ZIP archive to a desired location on your computer.
3. Run the script 'MalinowskyCarRental.sql'.
4. Set the connection string     
- Open 'Malinowsky-Car-Rental.sln'
- Go to Properties in Solution Explorer
- Go to Settings.settings
- Insert Name as 'connString', Type as (Connection String), Scope as Application and Value as Connection String of Database.
5. Build the solution by clicking on the "Build" menu and selecting "Build Solution".
6. Once the solution is built successfully, click on the "Start" button (green triangle) to run the application.

## Usage

Upon launching the application, you will be presented with a main window interface. The main window contains several buttons to navigate to different sections of the application:

- **Employees**: Clicking this button will open the employee management section where you can add, edit, or delete employee records.
- **Customers**: Clicking this button will open the customer management section where you can manage customer records.
- **Cars**: This button allows you to access the car management section where you can view and manage car details.
- **Rentals**: Clicking this button will take you to the rental management section where you can track and manage rental records.
- **Exit**: Use this button to close the application.

To perform specific actions within each section, follow the instructions provided on the respective screens. You can add, edit, and delete records as needed.

## Contributing

Contributions to this project are welcome. If you encounter any issues or have suggestions for improvement, please feel free to open an issue or submit a pull request.

## License

This project is licensed under the MIT License.

## Credits

This car rental application was developed by Justyna Malinowska and is based on the WPF framework and C# programming language.

---

Enjoy using the car rental application! If you have any questions, please don't hesitate to reach out.
