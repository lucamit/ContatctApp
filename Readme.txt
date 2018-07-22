Technology used: MVC 4,EF6,SQL Server

Project Structure:

Contacts.Data.Model : This is a class library project which contains Models for the application.
Contacts.Data.Access : This is a class library project which contains Model mapping to Tables and have resposibility to interact with Data base.
Contacts.Queries : This is a class library project which contains business logic.
Contacts.Api.Common : This poeject contains Api related  classes if required.
ContactsApp : This is the MVC app web site for contact features.
ContactsApp.Tests This is a  unit test project to add unit tests.


Deployment:
Update the connection string "AppDbContext" to point to the database.
Cpmpile the project an run,EF will create the required database.


