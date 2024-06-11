# Degree-Issuance-System
One Stop Degree Issuance System. Project @ Software Engineering

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Project Architecture](#project-architecture)
- [Installation and Setup](#installation-and-setup)
- [Requirements](#requirements)
- [Documentation](#documentation)
- [UI Screenshots](#ui-screenshots)
- [Contributing](#contributing)
- [Authors](#authors)
- [License](#license)

## Introduction

The One Stop Degree Issuance System is designed for FAST Islamabad campus to manage all degree-related needs in one place. This system allows students to submit degree requests, track their progress, and receive feedback from the One Stop Team. It also enables One Stop Admins to efficiently manage student requests for degrees and transcripts, verify student eligibility, and issue digital degrees and transcripts. It streamlines the process by involving necessary departments like FYP, Finance, and Admin.

## Features

The system includes several key features, each with specific user stories and acceptance criteria. Highlights include:

1. **Admin Dashboard**: Centralized dashboard for overseeing degree issuance activities.
2. **Token Generation:** Generate unique tokens for each student request for easy tracking and management.
3. **Manage Student Requests**: Manage and process degree and transcript issuance requests. View and filter pending, processed, and new requests.
4. **Manage Student Complaints**: Respond to and resolve student complaints.
5. **Generate and Issue Degree Certificates**: Digital degrees for approved graduates.
6. **Student Academic Record Access**: View and update student academic records.
7. **Generate and Issue Student Transcripts**: Comprehensive academic records for graduates.
8. **Objection Alerts**: Inform students of any objections from relevant departments.
9. **Student Profile Verification**: Verify student information and eligibility for degree issuance.
10. **Batch Processing**: Perform bulk actions on requests during peak times.
11. **Reporting and Analytics**: Generate reports on degree and request statistics.

## Project Architecture

The One Stop Degree Issuance System is built with a three-tier layered architecture:

1. **Presentation Layer**: Implements the user interface using ASP.NET, HTML, CSS, and Bootstrap.
2. **Business Logic Layer**: Contains the logic to implement the software's functional requirements using C#.
3. **Database Layer**: Manages data storage using SQL Relational Database.

This structure allows for easier implementation, scalability, and maintenance, with lower coupling between layers, making it easier to work on separate layers simultaneously.

## Installation and Setup

To set up the Degree Issuance System on your local machine, follow these steps:

1. Clone the repository to your local machine:
   ```bash
   git clone https://github.com/Vaneeza-7/Degree-Issuance-System.git
   ```

2. Set up the database by executing the SQL scripts provided in the `updated.sql` file.

3. Open the project in Visual Studio or your preferred IDE.

4. Configure the database connection string in the application's configuration file.

5. Build and run the application.

## Requirements

- .NET Framework (version 4.7.2)
- Visual Studio (version 17.0.6)
- SQL Server (version 19.0.2019)
  
## Documentation

The repository includes all necessary documentation, sprint charts, reports, and Software Requirements Specification (SRS) to help you understand the project and its development process. These documents can be found in the `iteration docs` folder and `SRS` folder.

## UI Screenshots
![homePage](https://github.com/Vaneeza-7/Degree-Issuance-System/blob/main/Screenshots/homePage.png)
![ComplaintForm](https://github.com/Vaneeza-7/Degree-Issuance-System/blob/main/Screenshots/complaintform.png)
![degreeRequest](https://github.com/Vaneeza-7/Degree-Issuance-System/blob/main/Screenshots/degreeRequest.png)
![notification](https://github.com/Vaneeza-7/Degree-Issuance-System/blob/main/Screenshots/notifications.png)
![academicRecords](https://github.com/Vaneeza-7/Degree-Issuance-System/blob/main/Screenshots/academic_records.png)
![reports](https://github.com/Vaneeza-7/Degree-Issuance-System/blob/main/Screenshots/report.png)
![activityTracking](https://github.com/Vaneeza-7/Degree-Issuance-System/blob/main/Screenshots/trackActivity.png)
![manage_requests](https://github.com/Vaneeza-7/Degree-Issuance-System/blob/main/Screenshots/manage_requests.png)
![transcript](https://github.com/Vaneeza-7/Degree-Issuance-System/blob/main/Screenshots/transcript_generated.png)
![login](https://github.com/Vaneeza-7/Degree-Issuance-System/blob/main/Screenshots/login.png)

## Contributing

Contributions to the project are welcome. Follow these guidelines to contribute:

1. Fork the repository.
2. Create a new branch for your feature or bug fix:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. Make your changes and commit them:
   ```bash
   git commit -m "Add your commit message here"
   ```
4. Push your changes to your forked repository:
   ```bash
   git push origin feature/your-feature-name
   ```
5. Open a pull request detailing your changes and their benefits.

Ensure your code adheres to the existing coding style and include appropriate tests for your changes.

## Authors
- [Vaneeza](https://github.com/Vaneeza-7)
- [Momina Khalid](https://github.com/MominaKhalid15)
- [Fizza Mumtaz](https://github.com/FizzaMumtaz)

## License

This project is licensed under the [MIT License](LICENSE).
