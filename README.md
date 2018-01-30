# Bangazon API sprint.
# The Thoughtless Eels

Overall Summary:

Working with the C# language and Asp.Net as our web application framework, the Thoughtless Eels are working to create a backend system that will allow other Developers the ability to add, search and at times delete the information from our company, Bangazon. These developers will have access to a myriad of tables from: Employees, Training Programs, Computers, Products, Customers and these Customer's Active Orders. You will make your requests through PostMan and will check the Database (SQLite) for any new updates.

# Steps to install the Bangazon API
There are a few programs and commands that need to run before we can jump in to the application. First we need to install these core technologies:
1. SQLite
1. Postman
1. Visual Studio Code
1. ASP.net

### Install SQLite:
- Download Node.js, we need this to install npm:
  [Node.js](https://nodejs.org/en/)
- With terminal, type: `sudo npm install npm -g` 

Now that we have NPM, we can install our packages:
- For Mac users, use the following command in your terminal: `npm install sqlite` 
- For Windows users: Follow this link and Download the latest version - [SQLite](https://www.sqlite.org/download.html)

### Install other dependencies
To open the source code, we recommend [Visual Studio Code](https://code.visualstudio.com/Download)
We will also install .net to use this app: [.net core](https://www.microsoft.com/net/learn/get-started/macos)
  
### Git started with git
First type `git init` in the directory you choose for the repo's download.
To pull down the repo, use the following command: `git clone https:github.com/Thoughtless-Eels/thoughtless-eels.git` 

### Create an environment variable to source for your database. 
Create a line in your .zshrc file that looks like this. 
Example `export EelDB="/**YourDirectoryPathHere**/Eel.db"`

### How to Run:
After cloning the repo and setting your environment variable, restore dependencies and apply the migration.
```
dotnet restore 
dotnet ef database update
dotnet run
```
At this point your database tables will be created but there will be no data in the tables. Using your preferred method, seed the database with info, starting with tables that have NO FOREIGN KEYS.


## Using the API

```
Example:
You can get a list of all the customers by making a GET call to: (http://localhost:5000/api/customer)
```

## Steps for Testing the API
Open Postman
Open SQL Browser. Use this command in the terminal: `open bangazon.db`

## Department

**GET Department** 
You can access a list of all Departments by running a Get call to (http://localhost:5000/api/Department)

**GET Single Department** 
You can get the information on a single Department by running a Get call to (http://localhost:5000/api/Department/{DepartmentID}).

> Note: You need to have a Departments unique ID number to get the correct information for a single Department.

**PUT** You can update the info on a specific Department by running a Put call to (http://localhost:5000/api/Department/{DepartmentID}).

> You must Put the entire changed object, which will include the DepartmentID, Name, Budget.
	
```
	Example:
        {		
        "DepartmentId": 1,
        "Name":"Sales",
        "Budget":"$50 Mill"
        }

```
**POST** You can post a new Department by running a Post call to (http://localhost:5000/api/Department)
```
	Example:
        {		
        "Name":"Sales",
        "Budget":"$50 Mill",
        }
```

## Product

In the Product, you will be able to **GET**, **POST**, **PUT**, **DELETE** product data in the database.

**GET** will give access to the entire list of products
* Open Postman 
* Select GET
* URL: http://localhost:5000/api/product

**GET** will give access to a single product by ID
* Open Postman 
* Select GET
* URL: http://localhost:5000/api/product/{productID}

**POST** will allow you to add a product
* Open Postman 
* Select POST
* URL: http://localhost:5000/api/product

```
Example:
        { 
	    "ProductId": 1,
        "name": "book",
        "price": 2.00,
        "quantity": 1,
        "Description": "C# 7.0 in a Nutshell"
        "CustomerId": 3,
        "ProductTypeId": 8
        }
```

**PUT** will allow you to update a specific product by ID
* Open Postman 
* Select PUT
* URL: http://localhost:5000/api/product/{productID}

```
	Example for using PUT:
		{ 
	    "ProductId": 1,
	    "name": "book",
	    "price": 2.00,
	    "quantity": 1,
	    "Description": "C# 7.0 in a Nutshell"
	    "CustomerId": 3,
	    "ProductTypeId": 8
		}
```

**DELETE** will allow you to delete a specific product by ID
* Open Postman 
* Select DELETE
* URL: http://localhost:5000/api/product/{productID}


 ## Computers

**GET Computers** 
You can access a list of all computers by running a Get call to (http://localhost:5000/api/computer)

**GET Single Computer** 
You can get the information on a single computer by running a Get call to (http://localhost:5000/api/computer/{computerID}).
> Note: You need to have a computers unique ID number to get the correct information for a single computer.


**PUT** You can update the info on a specific computer by running a Put call to (http://localhost:5000/api/computer/{computerID}).
```
   Example:
       {      
        “ComputerId”:“1",
        “Name”:“Mac Pro Computer”,
        “PurchasedOn”:“yyyy-mm-dd",
        “DecomissionedOn”:“yyyy-mm-dd",
        “Malfunction”: 0,
        “Available “: 1
       }
```
**POST** You can post a new computer by running a Post call to (http://localhost:5000/api/computer)
```
   Example:
       {      
        “ComputerId”:“1",
        “Name”:“Mac Pro Computer”,
        “PurchasedOn”:“yyyy-mm-dd",
        “DecomissionedOn”:“yyyy-mm-dd",
        “Malfunction”: 0,
        “Available “: 1
       }
```

## Customers

**GET**
You can access a list of all customers by running a Get call to (http://localhost:5000/api/customer)

**GET** a single:
You can get the information on a single customer by running a Get call to (http://localhost:5000/api/customer/{customerID}).

**PUT**
You can update the info on a specific customer by running a Put call to (http://localhost:5000/api/customer/{customerID}).

```
     Example:
        {
        "CustomerId": 1,        
        "FirstName":"Kevin",
        "LastName":"Miller",
        "CreatedOn":"yyyy-mm-dd",
        "DaysInactive": 0
        }
```


**POST**
You can post a new customer by running a Post call to (http://localhost:5000/api/customer)

```
     Example:
        {        
        "FirstName":"Kevin",
        "LastName":"Miller",
        "CreatedOn":"yyyy-mm-dd",
        "DaysInactive": 0
        }
```

## Training Program

**GET TrainingProgram** 
You can access a list of all training programs by running a Get call to (http://localhost:5000/api/TrainingProgram)

**GET Single Training Program** 
You can get the information on a single training program by running a Get call to (http://localhost:5000/api/TrainingProgram/{TrainingProgramId}).
> Note: You need to have the training program id number to get the correct information for a single training program.

**PUT** You can update the info on a specific training program by running a Put call to (http://localhost:5000/api/TrainingProgram/{TrainingProgramId}).
> You must pass in the entire changed object, which will include the training program name, start date, end date and max attendees. 
    
```
    Example:
        {       
        "TrainingProgramId": 2,
        “TrainingProgramName”: ”C# Training”,
        “StartDate”:”yyyy-mm-dd”,
        “EndDate”:”yyyy-mm-dd”,
        “MaxAttendees”: 25
        }
```
**POST** You can post a new training program by running a Post call to (http://localhost:5000/api/TrainingProgram)
```
    Example:
        {       
        “TrainingProgramName”: ”C# Training”,
        “StartDate”:”yyyy-mm-dd”,
        “EndDate”:”yyyy-mm-dd”,
        “MaxAttendees”: 25
        }
```
**DELETE** 
>Note: A training program should only be able to be deleted if the start date is in the future. If the training program has already begun, an error should be thrown if the delete method is attempted.
You can delete a single training program by running a Delete call to (http://localhost:5000/api/TrainingProgram/{TrainingProgramId})

## Employees

**GET Employees** 
You can access a list of all employees by running a Get call to (http://localhost:5000/api/employee)

**GET Single Employee** 
You can get the information on a single employee by running a Get call to (http://localhost:5000/api/employee/{employeeID}).
> Note: You need to have an employee's unique ID number to get the correct information for a single employee.

**PUT** You can update the info on a specific employee by running a Put call to (http://localhost:5000/api/employee/{employeeID}).
> You must Put the entire changed object, which will include the employeeID, Name, Supervisor,DepartmentId
    

    Example:
        {       

        "EmployeeId": 1,
        "Name":"Jacob Lee",
        "Supervisor":"Roger Smith",
        "DepartmentId": 2,
        }

**POST** You can post a new employee by running a Post call to (http://localhost:5000/api/employee)

    Example:
        {       
        "Name":"Jacob Lee",
        "Supervisor":"Roger Smith",
        "DepartmentId": 2,
        }



# ERD

![ERD](https://i.imgur.com/ShSf7Fg.png)

# Authors:
Project Manager: Hannah Hall

Contributers:
- Garrett Ward 
- John Dulaney 
- Lissa Goforth
- Courtney Seward

# License:
This project is licensed under the MIT License - see the LICENSE.md file for detail.
