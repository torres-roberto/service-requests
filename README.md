# service-requests
A RESTful API that exposes service request resources.

 This improves tenant experience in the building while improving communication between building staff and the end users.

Running the project
-
Dependency: .NET Core 3.1.101

After cloning the project, navigate inside the `src` folder.

To start the API: `dotnet run --project ServiceRequests`<br>
To run unit tests:  `dotnet test`

<br>

****
Notes on Code Challenge doc:
****
Storage Choice: In memory Dictionary for fast adds, deletes, lookups, and simplicity.


The spec suggested to return statuses: 201 and 404. I am returning back 204 instead of 201 (since 201 is created). 