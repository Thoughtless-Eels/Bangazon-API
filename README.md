# Bangazon API sprint.
# The Thoughtless Eels

Overall Summary:
Working with the C# language and Asp.Net as our web application framework, the Thoughtless Eels are working to create a backend system that will allow other Developers the ability to add, search and at times delete the information from our company, Bangazon. These developers will have accesss to a myriad of tables from: Employeess, Training Programs, Computers, Products, Customers and these Customer's Active Orders. You will make your requests through PostMan and will check the Database (SQLite) for any new updates.

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
