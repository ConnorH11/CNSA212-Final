# CNSA212-Final
We’re creating a user interface for the NRC data. (CY22.xlsx Download CY22.xlsx)

You may complete this project on a team or solo. Regardless of your choice, please communicate that choice to me by the end of Tuesday. I will randomly assign teams for those wishing to do the work on a team.

Infrastructure
I will create a SQL Server environment in the lab, but you can work locally as well as long as your stuff lives in the lab in the end.

Schema definitions are available for local testing: nrc-schemas.zipDownload nrc-schemas.zip

Make your application’s database connection configurable through one of the following methods:

via command line argument
configuration file
environment variable
(or all three with documentation on precedence)

Database commands shall be logged. The log file location shall be configurable in a manner similar to the database connection string. The log shall be in JSON format:

{
    "timestamp": "20241028 23:21:00",
    "command": "select * from users",
    "success": true
}

ETL (Extract, Transform, Load)
Your code will need to import the contents of CY22.xlsx into the database schema. It may do so as a command line tool as long as the database connection string is configurable.

Model Objects
Company
Attributes:

CompanyId
CompanyName
OrgType
Incident
Attributes:

Seqnos
DateTimeReceived
DateTimeComplete
CallType
ResponsibleState
ResponsibleZip
DescriptionOfIncident
TypeOfIncident
IncidentCause
InjuryCount
HospitalizationCount
FatalityCount
Methods:

public Company getCompany()
may return null
public IncidentTrain getIncidentTrain()
may return null
public Railroad getRailroad()
may return null
Railroad
Attributes:

RailroadId
Name
IncidentTrain
Attributes:

TrainId
TrailNameNumber
TrainType
Methods:

public IncidentTrainCar GetCars()
IncidentTrainCar
Attributes:

TrainCarId
CarNumber
CarContent
PositionInTrain
CarType
User
The user object isn’t from the spreadsheet: these represent us. You’ll need a way to bootstrap the initial user into the database: either a default username/password or a script to create an initial user.

Attributes:

Username
DisplayName
HashedPassword
Salt
Methods:

public boolean SetPassword(String plainTextPassword)
return true if password is hashed and saved successfully
Views
Screens
Login
The initial user interface should present the user with a login form. The user shall log in with a known username and password. The password must be hashed and salted in the database.

Main Screen
The main screen should allow users to open forms to view:

Incidents
Companies
Railroads
User Maintenance
Incidents
A button shall open a form to enter a new incident.

Search fields will allow the user to search for incidents by:

Seqnos
Or one or more of the following

Date range
Fatalities or injuries present
State
Search results shall appear in a DataGridView that includes the following data:

Seqnos
DataTimeReceived
CallType
ResponsibleState
TypeOfIncident
Double clicking on a row in the DataGridView will open a detailed view. All attributes shall be visible. If companies, railroads, or trains are associated with this incident, we shall be able to open details of each from this form.

Companies
A data grid view shall list all companies. Double clicking on a company shall open a form listing all incidents.

Railroads
A data grid view shall list all railroads. Double clicking on a railroad shall open a form listing all incidents.

User Maintenance
Allow the authenticated user to change their password.

User interface notes
The main form shall show the user’s username and displayname somewhere in the UI.

Input or processing errors should result in an indication of the error in the user interface. Examples of errors: invalid username/password, missing required data when adding a new incident. How the errors are displayed are up to the team.

Many actions result in showing a list of incidents in a DataGridView. This should perhaps be a reusable component.

Deliverables
A source repository that contains a C# project
Github, gitlab, or gitea are all fine as long as the instructor has access to clone the repo by the submission deadline.
The project shall compile with the command dotnet build
The project shall run with the command dotnet run
Documentation that includes
Information on configuring database connections
A default configuration that will connect to your lab database
Project artifacts shall include
Planning notes
Progress notes (at least once every 2 days)
Testing methodology
