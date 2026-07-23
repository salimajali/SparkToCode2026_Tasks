

CREATE DATABASE CompanyDB;
GO

USE CompanyDB;
GO



CREATE TABLE Department
(
    Dname             NVARCHAR(50) NOT NULL,
    Dnumber           INT NOT NULL,
    NumberOfEmployees INT NOT NULL
        CONSTRAINT DF_Department_NumberOfEmployees DEFAULT (0),
    Mgr_ssn           CHAR(9) NOT NULL,
    Mgr_start_date    DATE NOT NULL,

    CONSTRAINT PK_Department PRIMARY KEY (Dnumber),
    CONSTRAINT UQ_Department_Name UNIQUE (Dname),
    CONSTRAINT UQ_Department_Manager UNIQUE (Mgr_ssn),
    CONSTRAINT CK_Department_Number CHECK (Dnumber > 0),
    CONSTRAINT CK_Department_Employees CHECK (NumberOfEmployees >= 0)
);
GO



CREATE TABLE Employee
(
    Ssn        CHAR(9) NOT NULL,
    Fname      NVARCHAR(30) NOT NULL,
    Minit      NCHAR(1) NULL,
    Lname      NVARCHAR(30) NOT NULL,
    Address    NVARCHAR(150) NOT NULL,
    Sex        CHAR(1) NOT NULL,
    Bdate      DATE NOT NULL,
    Salary     DECIMAL(10,2) NOT NULL
        CONSTRAINT DF_Employee_Salary DEFAULT (1000.00),
    Dno        INT NOT NULL,
    Super_ssn  CHAR(9) NULL,

    CONSTRAINT PK_Employee PRIMARY KEY (Ssn),
    CONSTRAINT CK_Employee_Salary CHECK (Salary > 0),
    CONSTRAINT CK_Employee_Sex CHECK (Sex IN ('M', 'F')),


    CONSTRAINT FK_Employee_Department
        FOREIGN KEY (Dno) REFERENCES Department(Dnumber),


    CONSTRAINT FK_Employee_Supervisor
        FOREIGN KEY (Super_ssn) REFERENCES Employee(Ssn)
);
GO


ALTER TABLE Department
ADD CONSTRAINT FK_Department_Manager
    FOREIGN KEY (Mgr_ssn) REFERENCES Employee(Ssn);
GO



CREATE TABLE Dept_Locations
(
    Dnumber   INT NOT NULL,
    Dlocation NVARCHAR(50) NOT NULL,

    CONSTRAINT PK_Dept_Locations
        PRIMARY KEY (Dnumber, Dlocation),

    CONSTRAINT FK_DeptLocations_Department
        FOREIGN KEY (Dnumber) REFERENCES Department(Dnumber)
);
GO


CREATE TABLE Project
(
    Pname     NVARCHAR(50) NOT NULL,
    Pnumber   INT NOT NULL,
    Plocation NVARCHAR(50) NOT NULL,
    Dnum      INT NOT NULL,

    CONSTRAINT PK_Project PRIMARY KEY (Pnumber),
    CONSTRAINT UQ_Project_Name UNIQUE (Pname),
    CONSTRAINT CK_Project_Number CHECK (Pnumber > 0),


    CONSTRAINT FK_Project_Department
        FOREIGN KEY (Dnum) REFERENCES Department(Dnumber)
);
GO


CREATE TABLE Works_On
(
    Essn  CHAR(9) NOT NULL,
    Pno   INT NOT NULL,
    Hours DECIMAL(5,2) NOT NULL
        CONSTRAINT DF_WorksOn_Hours DEFAULT (0),

    CONSTRAINT PK_Works_On PRIMARY KEY (Essn, Pno),
    CONSTRAINT CK_WorksOn_Hours CHECK (Hours >= 0 AND Hours <= 168),

    CONSTRAINT FK_WorksOn_Employee
        FOREIGN KEY (Essn) REFERENCES Employee(Ssn),

    CONSTRAINT FK_WorksOn_Project
        FOREIGN KEY (Pno) REFERENCES Project(Pnumber)
);
GO



CREATE TABLE Dependent
(
    Essn           CHAR(9) NOT NULL,
    Dependent_name NVARCHAR(50) NOT NULL,
    Sex            CHAR(1) NOT NULL,
    Bdate          DATE NOT NULL,
    Relationship   NVARCHAR(30) NOT NULL,

    CONSTRAINT PK_Dependent
        PRIMARY KEY (Essn, Dependent_name),

    CONSTRAINT CK_Dependent_Sex
        CHECK (Sex IN ('M', 'F')),

    CONSTRAINT FK_Dependent_Employee
        FOREIGN KEY (Essn) REFERENCES Employee(Ssn)
);
GO




ALTER TABLE Department NOCHECK CONSTRAINT FK_Department_Manager;
ALTER TABLE Employee NOCHECK CONSTRAINT FK_Employee_Supervisor;
GO


INSERT INTO Department
    (Dname, Dnumber, NumberOfEmployees, Mgr_ssn, Mgr_start_date)
VALUES
    ('Headquarters',    1, 1, '888665555', '2022-01-01'),
    ('Administration',  4, 2, '987654321', '2023-03-15'),
    ('Research',        5, 2, '333445555', '2024-02-01');
GO



INSERT INTO Employee
    (Ssn, Fname, Minit, Lname, Address, Sex, Bdate, Salary, Dno, Super_ssn)
VALUES
    ('888665555', 'James',    'E', 'Borg',    'Muscat, Oman', 'M', '1970-11-10', 4500.00, 1, NULL),
    ('333445555', 'Franklin', 'T', 'Wong',    'Muscat, Oman', 'M', '1980-12-08', 3500.00, 5, '888665555'),
    ('123456789', 'John',     'B', 'Smith',   'Seeb, Oman',   'M', '1992-01-09', 2200.00, 5, '333445555'),
    ('987654321', 'Jennifer', 'S', 'Wallace', 'Bawshar, Oman','F', '1985-06-20', 3300.00, 4, '888665555'),
    ('999887777', 'Alicia',   'J', 'Zelaya',  'Muscat, Oman', 'F', '1994-07-19', 2100.00, 4, '987654321');
GO


ALTER TABLE Employee
WITH CHECK CHECK CONSTRAINT FK_Employee_Supervisor;

ALTER TABLE Department
WITH CHECK CHECK CONSTRAINT FK_Department_Manager;
GO


INSERT INTO Project
    (Pname, Pnumber, Plocation, Dnum)
VALUES
    ('ProductX',        1,  'Sohar',   5),
    ('ProductY',        2,  'Salalah', 5),
    ('Computerization', 10, 'Muscat',  4),
    ('Reorganization',  20, 'Muscat',  1);
GO



INSERT INTO Works_On
    (Essn, Pno, Hours)
VALUES
    ('123456789', 1,  32.50),
    ('333445555', 2,  10.00),
    ('999887777', 10, 20.00);
GO



INSERT INTO Dependent
    (Essn, Dependent_name, Sex, Bdate, Relationship)
VALUES
    ('123456789', 'Alice',    'F', '2018-04-05', 'Daughter'),
    ('333445555', 'Theodore', 'M', '2014-10-25', 'Son');
GO


UPDATE Employee
SET Salary = Salary * 1.10
WHERE Ssn = '123456789';
GO


UPDATE Department
SET Dname = 'Corporate Administration'
WHERE Dnumber = 4;
GO


UPDATE Project
SET Plocation = 'Muscat'
WHERE Pnumber = 1;
GO


UPDATE Works_On
SET Hours = 35.00
WHERE Essn = '123456789'
  AND Pno = 1;
GO


UPDATE Dependent
SET Relationship = 'Child'
WHERE Essn = '123456789'
  AND Dependent_name = 'Alice';
GO



DELETE FROM Works_On
WHERE Essn = '999887777'
  AND Pno = 10;
GO

DELETE FROM Employee
WHERE Ssn = '999887777';
GO



SELECT * FROM Department;
SELECT * FROM Employee;
SELECT * FROM Dept_Locations;
SELECT * FROM Project;
SELECT * FROM Works_On;
SELECT * FROM Dependent;
GO
