create database onestop
use onestop


-- FinanceAccountant Table
CREATE TABLE FinanceAccountants (
UserID INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Name NVARCHAR(255),
    Designation NVARCHAR(255)
);
--drop TABLE FinanceAccountants

-- Student Table
CREATE TABLE Students (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Name NVARCHAR(255),
    RollNumber NVARCHAR(50),
    Degree NVARCHAR(50),
    Batch NVARCHAR(50),
	Campus NVARCHAR(50),
	Status NVARCHAR(50),
    DegreeStatus NVARCHAR(50)
    
);
--drop TABLE Students

-- FinancialRecords Table
CREATE TABLE FinancialRecords (
    RecordID INT PRIMARY KEY IDENTITY(1,1) ,
    DegreeFee INT,
    CourseFee INT,
    Funds INT,
	UserID INT,
	FOREIGN KEY (UserID) REFERENCES Students(UserID)
);
--drop TABLE FinancialRecords

-- StudentAcademicRecord Table
CREATE TABLE StudentAcademicRecords (
    RecordID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT,
    CGPA FLOAT,
    CreditHours FLOAT,
    FOREIGN KEY (UserID) REFERENCES Students(UserID)
);
--drop TABLE StudentAcademicRecords

-- Courses associated with a StudentAcademicRecord
CREATE TABLE Courses (
    CourseID INT PRIMARY KEY IDENTITY(1,1),
    RecordID INT,
    CourseName NVARCHAR(255),
    Grade NVARCHAR(5),
    FOREIGN KEY (RecordID) REFERENCES StudentAcademicRecords(RecordID)
);

-- ComplaintForm Table
CREATE TABLE ComplaintForm (
    ComplaintID INT PRIMARY KEY IDENTITY(1,1),
    Date DATETIME,
    Status NVARCHAR(255),
    Complaint NVARCHAR(1000)
);

-- DegreeIssuanceForm Table
CREATE TABLE DegreeIssuanceForms (
    FormID INT PRIMARY KEY IDENTITY(1,1),
    RequestDate DATETIME,
    CurrentStatus NVARCHAR(255)
);

-- Transcript Table
CREATE TABLE Transcript (
    TranscriptID INT PRIMARY KEY IDENTITY(1,1),
    Date NVARCHAR(50),
    GPA FLOAT,
    UserID INT,
    FOREIGN KEY (UserID) REFERENCES Students(UserID)
);

-- Degrees Table
CREATE TABLE Degree (
    DegreeID INT PRIMARY KEY IDENTITY(1,1),
    DateOfIssuance DATETIME,
    GraduatingCGPA FLOAT,
    Signature NVARCHAR(255),
    UserID INT,
    FOREIGN KEY (UserID) REFERENCES Students(UserID)
);

-- DegreeRequest Table
CREATE TABLE DegreeRequests (
    Token UNIQUEIDENTIFIER DEFAULT NEWID(),
    DateReceived DATETIME,
    Status NVARCHAR(255),
    AdminApproved BIT,
    FYPApproved BIT,
    FinanceApproved BIT,
	UserID INT FOREIGN KEY REFERENCES Students(UserID),
	PRIMARY KEY (Token)
);

-- Admin Table
CREATE TABLE Admins (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Name NVARCHAR(255),
    Designation NVARCHAR(255)
);

-- StudentComplaint Table
CREATE TABLE StudentComplaints (
    ComplaintID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT,
    Status NVARCHAR(255),
    Type NVARCHAR(255),
    Date DATETIME,
    ComplaintText NVARCHAR(1000),
    FOREIGN KEY (StudentID) REFERENCES Students(UserID)
);


-- Notification Table
CREATE TABLE Notifications (
    NotificationID INT PRIMARY KEY IDENTITY(1,1),
    ReceiverID INT,
	Text NVARCHAR(100),
    Date DATETIME,
    FOREIGN KEY (ReceiverID) REFERENCES Students(UserID)
);

-- FYPDeptMember Table
CREATE TABLE FYPDeptMembers (
	UserID INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Name NVARCHAR(255)
);

-- Director Table
CREATE TABLE Directors (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Email NVARCHAR(255) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    Address NVARCHAR(255),
    Name NVARCHAR(255),
    DateOfJoining DATETIME,
    DateOfRetirement DATETIME
);

-- FYP Table
CREATE TABLE FYP (
    FYPID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255),
    Domain NVARCHAR(255),
    Supervisor NVARCHAR(255),
    Grade NVARCHAR(5),
    StudentID INT,
    FOREIGN KEY (StudentID) REFERENCES Students(UserID)
);

-- Reports Table
CREATE TABLE Report (
    ReportID INT PRIMARY KEY IDENTITY(1,1),
    Date DATETIME,
    NumberOfRequests INT
);


----INSERTION

USE onestop
INSERT INTO FinanceAccountants (Email, Password, Address, Name, Designation)
VALUES ('accountant@example.com', 'securePassword', '123 Finance Road', 'John Doe', 'Chief Financial Officer');

INSERT INTO Students (Email, Password, Address, Name, RollNumber, Degree, Batch, Campus, Status, DegreeStatus)
VALUES ('student@example.com', 'studentPassword', '456 Student Drive', 'Alice Johnson', 'S10001', 'Computer Science', '2023', 'Main', 'Active', 'Enrolled');

INSERT INTO FinancialRecords (DegreeFee, CourseFee, Funds, UserID)
VALUES (5000, 1500, 1000, 1); -- Assuming '1' is a valid UserID from Students table

INSERT INTO StudentAcademicRecords (UserID, CGPA, CreditHours)
VALUES (1, 3.5, 120); -- Assuming '1' is the UserID from the Students table

INSERT INTO Courses (RecordID, CourseName, Grade)
VALUES (1, 'Introduction to Computer Science', 'A'); -- Assuming '1' is a valid RecordID

INSERT INTO ComplaintForm (Date, Status, Complaint)
VALUES (GETDATE(), 'Open', 'Issue with course registration.');

INSERT INTO DegreeIssuanceForms (RequestDate, CurrentStatus)
VALUES (GETDATE(), 'Pending Review');

INSERT INTO Transcript (Date, GPA, UserID)
VALUES ('2023-09', 3.4, 1); -- Assuming '1' is a valid UserID


INSERT INTO Degree (DateOfIssuance, GraduatingCGPA, Signature, UserID)
VALUES ('2023-05-01', 3.6, 'John Smith', 1); -- Assuming '1' is a valid UserID


INSERT INTO DegreeRequests (DateReceived, Status, AdminApproved, FYPApproved, FinanceApproved, UserID)
VALUES (GETDATE(), 'Pending', 0, 0, 0, 1); -- Assuming '1' is a valid UserID


INSERT INTO Admins (Email, Password, Address, Name, Designation)
VALUES ('admin@example.com', 'adminPassword', '789 Admin Blvd', 'Bob Smith', 'Administrator');


INSERT INTO StudentComplaints (StudentID, Status, Type, Date, ComplaintText)
VALUES (1, 'Unresolved', 'Academic', GETDATE(), 'Complaint regarding final grade.');


INSERT INTO Notifications (ReceiverID, Text, Date)
VALUES (1, 'Your request has been processed', GETDATE());


INSERT INTO FYPDeptMembers (Email, Password, Address, Name)
VALUES ('fypmember@example.com', 'fypPassword', '123 FYP Lane', 'Clara Oswald');


INSERT INTO Directors (Email, Password, Address, Name, DateOfJoining, DateOfRetirement)
VALUES ('director@example.com', 'directorPassword', '321 Director Road', 'Steven Moffat', '2018-01-01', '2028-01-01');


INSERT INTO FYP (Title, Domain, Supervisor, Grade, StudentID)
VALUES ('Capstone Project', 'Software Engineering', 'Dr. Who', 'A', 1);


INSERT INTO Report (Date, NumberOfRequests)
VALUES (GETDATE(), 10);


-- Select all data from the FinanceAccountants table
SELECT * FROM FinanceAccountants;

-- Select all data from the Students table
SELECT * FROM Students;

-- Select all data from the FinancialRecords table
SELECT * FROM FinancialRecords;

-- Select all data from the StudentAcademicRecords table
SELECT * FROM StudentAcademicRecords;

-- Select all data from the Courses table
SELECT * FROM Courses;

-- Select all data from the ComplaintForm table
SELECT * FROM ComplaintForm;

-- Select all data from the DegreeIssuanceForms table
SELECT * FROM DegreeIssuanceForms;

-- Select all data from the Transcript table
SELECT * FROM Transcript;

-- Select all data from the Degree table
SELECT * FROM Degree;

-- Select all data from the DegreeRequests table
SELECT * FROM DegreeRequests;

-- Select all data from the Admins table
SELECT * FROM Admins;

-- Select all data from the StudentComplaints table
SELECT * FROM StudentComplaints;

-- Select all data from the Notifications table
SELECT * FROM Notifications;

-- Select all data from the FYPDeptMembers table
SELECT * FROM FYPDeptMembers;

-- Select all data from the Directors table
SELECT * FROM Directors;

-- Select all data from the FYP table
SELECT * FROM FYP;

-- Select all data from the Report table
SELECT * FROM Report;


INSERT INTO Students (Email, Password, Address, Name, RollNumber, Degree, Batch, Campus, Status, DegreeStatus)
VALUES 
('student2@example.com', 'password2', '457 Student Drive', 'Bob Brown', 'S10002', 'Mathematics', '2022', 'Main', 'Active', 'Enrolled'),
('student3@example.com', 'password3', '458 Student Drive', 'Clara Smith', 'S10003', 'Physics', '2022', 'Main', 'Active', 'Enrolled'),
('student4@example.com', 'password4', '459 Student Drive', 'Dave Wilson', 'S10004', 'Chemistry', '2023', 'Main', 'Active', 'Enrolled'),
('student5@example.com', 'password5', '460 Student Drive', 'Ella Martinez', 'S10005', 'Biology', '2023', 'Main', 'Active', 'Enrolled'),
('student6@example.com', 'password6', '461 Student Drive', 'Franklyn Jose', 'S10006', 'English', '2024', 'Main', 'Active', 'Enrolled');

-- Insert additional DegreeRequests
INSERT INTO DegreeRequests (DateReceived, Status, AdminApproved, FYPApproved, FinanceApproved, UserID)
VALUES 
(GETDATE(), 'Pending', 0, 0, 0, 2),
(GETDATE(), 'Pending', 0, 0, 0, 3),
(GETDATE(), 'Pending', 0, 0, 0, 4),
(GETDATE(), 'Pending', 0, 0, 0, 5),
(GETDATE(), 'Pending', 0, 0, 0, 6);

INSERT INTO FinanceAccountants (Email, Password, Address, Name, Designation)
VALUES 
('accountant2@example.com', 'securePassword2', '124 Finance Road', 'Jane Doe', 'Financial Analyst'),
('accountant3@example.com', 'securePassword3', '125 Finance Road', 'Alice Brown', 'Senior Accountant'),
('accountant4@example.com', 'securePassword4', '126 Finance Road', 'Bob White', 'Accountant'),
('accountant5@example.com', 'securePassword5', '127 Finance Road', 'Eve Black', 'Treasurer'),
('accountant6@example.com', 'securePassword6', '128 Finance Road', 'Victor Green', 'Finance Officer');


-- Assuming UserIDs from 2 to 6 are valid
INSERT INTO FinancialRecords (DegreeFee, CourseFee, Funds, UserID)
VALUES 
(6000, 2000, 1500, 2),
(5000, 2500, 1200, 3),
(4500, 1800, 1000, 4),
(5200, 1900, 1600, 5),
(5500, 2100, 1300, 6);


-- Assuming UserIDs from 2 to 6 are valid
INSERT INTO StudentAcademicRecords (UserID, CGPA, CreditHours)
VALUES 
(2, 3.8, 125),
(3, 3.9, 130),
(4, 3.6, 120),
(5, 3.7, 115),
(6, 3.85, 128);


-- Assuming RecordIDs from 2 to 6 are valid
INSERT INTO Courses (RecordID, CourseName, Grade)
VALUES 
(2, 'Data Structures', 'A'),
(3, 'Algorithms', 'B'),
(4, 'Machine Learning', 'A'),
(5, 'Database Systems', 'B'),
(6, 'Operating Systems', 'A');

INSERT INTO ComplaintForm (Date, Status, Complaint)
VALUES 
(GETDATE(), 'Open', 'Login issue encountered.'),
(GETDATE(), 'Resolved', 'Access denied error on module 3.'),
(GETDATE(), 'Pending', 'Feedback form not submitting.'),
(GETDATE(), 'Open', 'Profile update failure.'),
(GETDATE(), 'Closed', 'Email notifications not being sent.');

INSERT INTO DegreeIssuanceForms (RequestDate, CurrentStatus)
VALUES 
(GETDATE(), 'Processing'),
(GETDATE(), 'Approved'),
(GETDATE(), 'Rejected'),
(GETDATE(), 'Pending Review'),
(GETDATE(), 'Completed');

-- Assuming UserIDs from 2 to 6 are valid
INSERT INTO Transcript (Date, GPA, UserID)
VALUES 
('2023-10', 3.6, 2),
('2023-11', 3.9, 3),
('2023-12', 3.5, 4),
('2024-01', 3.4, 5),
('2024-02', 3.8, 6);

-- Assuming UserIDs from 2 to 6 are valid
--INSERT INTO Degree (DateOfIssuance, GraduatingCGPA, Signature, UserID)
--VALUES 
--('2024-05-01', 3.7, 'Alice Brown', 2),
--('2024-06-01', 3.9, 'Clara Smith', 3),
---('2024-07-01', 3.5, 'Dave Wilson', 4),
--('2024-08-01', 3.4, 'Ella Martinez', 5),
--('2024-09-01', 3.8, 'Franklyn Jose', 6);

-- Assuming UserIDs from 2 to 6 are valid
INSERT INTO DegreeRequests (DateReceived, Status, AdminApproved, FYPApproved, FinanceApproved, UserID)
VALUES 
(GETDATE(), 'Pending', 0, 0, 0, 2),
(GETDATE(), 'Pending', 0, 0, 0, 3),
(GETDATE(), 'Rejected', 1, 1, 0, 4),
(GETDATE(), 'Pending', 0, 0, 0, 5),
(GETDATE(), 'Pending', 0, 0, 0, 6);

update DegreeRequests
SET Status = 'Approved', AdminApproved=1, FYPApproved=1, FinanceApproved=1
where UserID=1

INSERT INTO Admins (Email, Password, Address, Name, Designation)
VALUES 
('admin2@example.com', 'password7', '790 Admin Blvd', 'Charlie Brown', 'Deputy Administrator'),
('admin3@example.com', 'password8', '791 Admin Blvd', 'Diana Prince', 'Assistant Administrator'),
('admin4@example.com', 'password9', '792 Admin Blvd', 'Edward Nygma', 'Administrative Officer'),
('admin5@example.com', 'password10', '793 Admin Blvd', 'Fiona Gallagher', 'Chief of Staff'),
('admin6@example.com', 'password11', '794 Admin Blvd', 'George Jetson', 'IT Administrator');

-- Assuming StudentIDs from 2 to 6 are valid
INSERT INTO StudentComplaints (StudentID, Status, Type, Date, ComplaintText)
VALUES 
(2, 'Open', 'Technical', GETDATE(), 'Issue with Wi-Fi connectivity.'),
(3, 'Resolved', 'Service', GETDATE(), 'Cafeteria services are unsatisfactory.'),
(4, 'Pending', 'Academic', GETDATE(), 'Discrepancy in grade posting.'),
(5, 'Open', 'Facility', GETDATE(), 'Gym equipment is outdated.'),
(6, 'Closed', 'Technical', GETDATE(), 'Laptop loan process was cumbersome.');

select* from DegreeRequests

----	UPDATE TABLES
alter table DegreeRequests
add AdminComments VARCHAR(100)

alter table DegreeRequests
add FYPComments VARCHAR(100)

alter table DegreeRequests
add FinanceComments VARCHAR(100)

select* from DegreeRequests

----	UPDATE ON 5/5/2024
alter table StudentComplaints
add AdminComments VARCHAR(300)

GO
CREATE TRIGGER trg_UpdateStatusAfterInsert
ON DegreeRequests
AFTER INSERT
AS
BEGIN
    -- Update Status to "Approved" if all three approvals are 1
    UPDATE DegreeRequests
    SET Status = 'Approved'
    FROM DegreeRequests dr
    INNER JOIN inserted i
    ON dr.Token = i.Token  -- Using Token as the joining key
    WHERE i.AdminApproved = 1
    AND i.FYPApproved = 1
    AND i.FinanceApproved = 1;
END

GO
CREATE TRIGGER trg_UpdateStatusAfterUpdate
ON DegreeRequests
AFTER UPDATE
AS
BEGIN
    -- Update Status to "Approved" if all three approvals are 1
    UPDATE DegreeRequests
    SET Status = 'Approved'
    FROM DegreeRequests dr
    INNER JOIN inserted i
    ON dr.Token = i.Token  -- Using Token as the joining key
    WHERE i.AdminApproved = 1
    AND i.FYPApproved = 1
    AND i.FinanceApproved = 1
    AND i.Status <> 'Approved'; -- Prevent unnecessary updates
END

-- select* from StudentAcademicRecords r inner join Courses c on r.RecordID=c.RecordID