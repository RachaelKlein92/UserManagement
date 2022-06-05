# UserManagement

# Database Setup
Create a database on your local MySQL Server called "usermanagement"

Then open the command line and navigate to the root of the UserManagement project i.e. "\UserManagement\UserManagement"

Ensure that you have the EntityFramework command line package installed.
You can do this by running the following command in command line "dotnet tool install --global dotnet-ef"

Now run the following command to deploy the migration scripts to your local database "dotnet ef database update"

# Note
The test specification didn't specify any method of assigning a role to users.
I have setup the application, so that the first user registered on the system will have an Admin role, the second user will have a Reporter role, and every user thereafter will have a User role.
