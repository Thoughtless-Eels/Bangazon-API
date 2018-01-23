DELETE FROM EmployeeTraining;
DELETE FROM EmployeeComputer;
DELETE FROM ProductOrder;
DELETE FROM TrainingProgram;
DELETE FROM Computer;
DELETE FROM Employee;
DELETE FROM Department;
DELETE FROM CurrentOrder;
DELETE FROM Product;
DELETE FROM PaymentType;
DELETE FROM Customer;

DROP TABLE IF EXISTS EmployeeTraining;
DROP TABLE IF EXISTS TrainingProgram;
DROP TABLE IF EXISTS EmployeeComputer;
DROP TABLE IF EXISTS Computer;
DROP TABLE IF EXISTS Department;
DROP TABLE IF EXISTS Employee;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS ProductType;
DROP TABLE IF EXISTS CurrentOrder;
DROP TABLE IF EXISTS PaymentType;
DROP TABLE IF EXISTS Product;
DROP TABLE IF EXISTS ProductOrder;

CREATE TABLE `TrainingProgram` (
	`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`Name`  TEXT NOT NULL,
	`StartDate` TEXT NOT NULL,
	`EndDate` TEXT NOT NULL,
	`MaxAttendees` INTEGER NOT NULL
);

CREATE TABLE `Computer` (
	`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`PurchasedOn` TEXT NOT NULL,
	`DecommissionedOn` TEXT,
	`Malfunctioned` INTEGER NOT NULL,
	`Available` INTEGER NOT NULL
);

CREATE TABLE `Department` (
	`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`Name` TEXT NOT NULL,
	`Budget` INTEGER NOT NULL
);

CREATE TABLE `Customer` (
	`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`FirstName` TEXT NOT NULL,
	`LastName` TEXT NOT NULL,
	`CreatedOn` TEXT NOT NULL,
	`DaysInactive` INTEGER NOT NULL
);

CREATE TABLE `ProductType` (
	`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`Category` TEXT NOT NULL
);

CREATE TABLE `Employee` (
	`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`Name` TEXT NOT NULL,
	`Supervisor` INTEGER NOT NULL,
	`DepartmentID` INTEGER NOT NULL,
	FOREIGN KEY(`DepartmentID`) REFERENCES `Department`(`Id`)
);

CREATE TABLE `EmployeeTraining` (
	`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`EmployeeID` INTEGER NOT NULL,
	`TrainingProgramID` INTEGER NOT NULL,
	FOREIGN KEY(`EmployeeID`) REFERENCES `Employee`(`Id`),
	FOREIGN KEY(`TrainingProgramID`) REFERENCES `TrainingProgram`(`Id`)
);	

CREATE TABLE `EmployeeComputer` (
	`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`EmployeeID` INTEGER NOT NULL,
	`ComputerID` INTEGER NOT NULL,
	`StartDate` TEXT,
	`EndDate` TEXT, 
	FOREIGN KEY(`EmployeeID`) REFERENCES `Employee`(`Id`),
	FOREIGN KEY(`ComputerID`) REFERENCES `Computer`(`Id`)
);

CREATE TABLE `PaymentType` (
	`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`Name` TEXT NOT NULL,
	`AccountNumber` INTEGER NOT NULL,
	`CustomerID` INTEGER NOT NULL,
	FOREIGN KEY(`CustomerID`) REFERENCES `Customer`(`Id`)
);

CREATE TABLE `Product` (
	`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`Name` TEXT NOT NULL,
	`Price` INTEGER NOT NULL,
	`Quantity` INTEGER NOT NULL,
	`Description` TEXT NOT NULL,
	`CustomerID` INTEGER NOT NULL,
	`PaymentTypeID` INTEGER NOT NULL,
	FOREIGN KEY(`CustomerID`) REFERENCES `Customer`(`Id`),
	FOREIGN KEY(`PaymentTypeID`) REFERENCES `PaymentType`(`Id`)
);

CREATE TABLE `CurrentOrder` (
	`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`CustomerID` INTEGER NOT NULL,
	`PaymentTypeID` INTEGER,
	FOREIGN KEY(`CustomerID`) REFERENCES `Customer`(`Id`),
	FOREIGN KEY(`PaymentTypeID`) REFERENCES `PaymentType`(`Id`)
);

CREATE TABLE `ProductOrder` (
	`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`CurrentOrderID` INTEGER NOT NULL,
	`ProductID` INTEGER NOT NULL,
	FOREIGN KEY(`CurrentOrderID`) REFERENCES `CurrentOrder`(`Id`),
	FOREIGN KEY(`ProductID`) REFERENCES `Product`(`Id`)
);	

INSERT INTO TrainingProgram
VALUES (null, 'SQL Training', '2/5/18', '3/2/18', 25);

INSERT INTO TrainingProgram
VALUES (null, 'C# Training', '3/5/18', '3/30/18', 25);

INSERT INTO Computer
VALUES (null, '1/15/17', null, 0, 0);

INSERT INTO Computer
VALUES (null, '1/15/18', null, 0, 1);

INSERT INTO Department
VALUES (null, 'Marketing', 250000);

INSERT INTO Department
VALUES (null, 'Human Resources', 170000);

INSERT INTO Customer
VALUES (null, 'John', 'Arnold', '5/12/17', 13);

INSERT INTO Customer
VALUES (null, 'Jenn', 'Jackson', '5/12/17', 4);

INSERT INTO ProductType
VALUES (null, 'Decor');

INSERT INTO ProductType
VALUES (null, 'Cosmetics');


INSERT INTO Employee
	SELECT null,
			"Kimmy Bird",
			1,
			d.Id
	FROM Department d WHERE d.Name = "Marketing";
	
INSERT INTO Employee
	SELECT null,
			"Leah Duvic",
			1,
			d.Id
	FROM Department d WHERE d.Name = "Human Resources";
	
INSERT INTO Employee
	SELECT null,
			"Jason Figueroa",
			0,
			d.Id
	FROM Department d WHERE d.Name = "Marketing";
	
INSERT INTO Employee
	SELECT null,
			"Courtney Seward",
			0,
			d.Id
	FROM Department d WHERE d.Name = "Marketing";
	
INSERT INTO Employee
	SELECT null,
			"Steve Brownlee",
			0,
			d.Id
	FROM Department d WHERE d.Name = "Human Resources";
	
INSERT INTO Employee
	SELECT null,
			"Tyler Bowman",
			0,
			d.Id
	FROM Department d WHERE d.Name = "Human Resources";
	
INSERT INTO EmployeeTraining
	SELECT null,
			e.Id,
			t.Id
	FROM Employee e, TrainingProgram t WHERE e.Name = 'Jason Figueroa' AND t.Name = 'SQL Training';
	
INSERT INTO EmployeeTraining
	SELECT null,
			e.Id,
			t.Id
	FROM Employee e, TrainingProgram t WHERE e.Name = 'Steve Brownlee' AND t.Name = 'C# Training';	

INSERT INTO EmployeeTraining
	SELECT null,
			e.Id,
			t.Id
	FROM Employee e, TrainingProgram t WHERE e.Name = 'Courtney Seward' AND t.Name = 'C# Training';	
	
INSERT INTO EmployeeTraining
	SELECT null,
			e.Id,
			t.Id
	FROM Employee e, TrainingProgram t WHERE e.Name = 'Tyler Bowman' AND t.Name = 'SQL Training';

INSERT INTO EmployeeComputer
	SELECT null,
			e.Id,
			c.Id,
			null,
			null
	FROM Employee e, Computer c WHERE e.Name = 'Kimmy Bird' AND c.PurchasedOn = '1/15/18';

INSERT INTO PaymentType
	SELECT null,
			'Visa',
			1234567891122334,
			c.Id
	FROM Customer c WHERE c.FirstName = 'Jenn';

INSERT INTO PaymentType
	SELECT null,
			'Mastercard',
			1234567891234567,
			c.Id
	FROM Customer c WHERE c.FirstName = 'Jenn';

INSERT INTO PaymentType
	SELECT null,
			'Amex',
			1111222233334444,
			c.Id
	FROM Customer c WHERE c.FirstName = 'Jenn';

INSERT INTO PaymentType
	SELECT null,
			'Amex',
			9998887776665554,
			c.Id
	FROM Customer c WHERE c.FirstName = 'John';

INSERT INTO PaymentType
	SELECT null,
			'Visa',
			9876543211234567,
			c.Id
	FROM Customer c WHERE c.FirstName = 'John';

INSERT INTO PaymentType
	SELECT null,
			'Mastercard',
			1234123412341234,
			c.Id
	FROM Customer c WHERE c.FirstName = 'John';

INSERT INTO Product
	SELECT null,
			'Bath Bomb',
			6.99,
			15,
			'Eucalyptus and Aloe bath bomb',
			c.Id,
			pt.Id
	FROM Customer c, ProductType pt WHERE c.FirstName = 'Jenn' AND pt.Category = 'Cosmetics';

INSERT INTO Product
	SELECT null,
			'Painting',
			67.99,
			15,
			'Painting of cat',
			c.Id,
			pt.Id
	FROM Customer c, ProductType pt WHERE c.FirstName = 'John' AND pt.Category = 'Decor';

INSERT INTO CurrentOrder
	SELECT null,
			c.Id,
			pt.Id
	FROM Customer c, PaymentType pt WHERE c.FirstName = 'Jenn' AND pt.AccountNumber = 1111222233334444;

INSERT INTO CurrentOrder
	SELECT null,
			c.Id,
			pt.Id
	FROM Customer c, PaymentType pt WHERE c.FirstName = 'John' AND pt.AccountNumber = 1234123412341234;

INSERT INTO ProductOrder
	SELECT null,
			co.Id,
			p.Id
	FROM CurrentOrder co, Product p WHERE co.CustomerId = 1 AND p.Name = 'Bath Bomb';

INSERT INTO ProductOrder
	SELECT null,
			co.Id,
			p.Id
	FROM CurrentOrder co, Product p WHERE co.CustomerId = 2 AND p.Name = 'Painting';
		