# publishers-web-client
## Publishers’ Web Service and Library Members’ Web Application

This is a Visual Studio solution containing 11 projects. The goal of this project is to demonstrate the following:

1. Creating and launching WebAPI service, creating a client MVC web application which uses the WebAPI Service
2. Using Mongo DB with D# (even with ASP.NET Identity, so all the data is saved only in MongoDB database, no SQL server database used)
3. Using Domain Centric Architecture (Onion Architecture)
4. Using SOLID principles, Dependency Injection and IoC containers
5. Using Test Driven Development

The WebAPI web service provides information about publishers’ books and this information is accessible through its RestFul API. The web application could be used by universities to access the publishers’ data and provides membership for library members, using Mongo Db for storing user account information (ASP.NET Identity with Mongo DB). The book demands will be stored in the Web Application database.
It has mainly two parts:

1. Publishers Web API which is ASP.NET WebAPI project. It has a web application to host it in IIS (WebHost)
2. Library members' web application which is an ASP.NET MVC 5 web application.

**Functional Specifications:**

Creating the web application and web service to implement the following functional requirements.
1.	Publishers keep data about their books in a query-able Mongo DB database (could be cloud hosted). So assuming the data is already in the db. How they add this data is not yet implemented. The web application queries this data to support book searches. The web service allows querying of this data.
2.	University libraries will be able to allow their members to register, login, and check their previous demands using a web application.
3.	The web application would also allow to search the publishers’ data and would let members place demands for books with their libraries.

**Non Functional Specifications:**

1.	Web service architecture. The components should be loosely coupled and should operate fairly independently (using Dependency Injection and IoC containers)
2.	Web application would allow users to register, authenticate and maintain their list of book demands.

**Prerequisites:**

The following prerequisites should be installed on the system in order to run the web service and web application properly:
1. MongoDB >= v3.2.8
2. Visual Studio 2015
3. Nuget Package Manager

**Steps to Prepare:**

1. MongoDB server should be running and configured to use default port (27017]. In the root folder of the project, a file named "MongoDB Launch.bat" is available. Make sure MongoDb is installed and its bin directory is in the path environment variable. Double click the "MongoDB Launch.bat" file and it will launch mongod server with proper dbpath and port.
2. In the root folder, there is a folder named DB Setup. Inside that folder double click the file mongo_import.bat to import the data to your server. It will drop the database named PublishersAPI if exists and creates it and imports the collections.
3. In the root folder, open the project folder and double click on the Publishers solution to open it in Visual Studio 2015.
4. Make sure no nuget package is missing and then start the solution. The start projects are already configured. The web service's WebHost project will run and then the client Web application will start.
5. The username and password for web application's Admin account: username is rhabiblv@gmail.com and password is 123_Abcdefg

