# Tracker.API

Tracker API contains thre micro services and its API end points.

1.	**User Service** – This API provides end point for the authentication of a user and creating a use (which is accessible only for admins), it is connected to a SQL DB.
2.	**Vehicle API** – This API provides end point to create a vehicle and know the current location of a vehicle as well as the position on a particular date and time. This API is connected to the Mongo DB, also using a Map Box API to find the location by providing co-ordinates.
3.	**Location API** - This API provides an end point to update the location, as this might be a highly using API there is only one end point, this can scale independently based on the number of vehicles on the road.  This API also connected to the mongo DB.

## How to run

There are three batch files (RunLocationService.bat, RunUserService.bat, RunVehicleService.bat) in the root directory of the repo, each one will build and run the API in Kestrel dev server.

Then the API will be accessible in,
  1. Location Service - https://localhost:5001 
  2. User Service - https://localhost:5011
  3. Vehicle Servic - https://localhost:5021
  
  In memory data base is using for User DB (SQL DB) and remote mongo instance is using for the TrackerDB (Mongo DB)
