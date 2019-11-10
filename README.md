# CreditInfo

To run locally:

-Use the provided CreateDBScript.sql to create the Database in SQL Server.

-Configure CreditInfoDataLoader app.config with the correct database settings and file path to import, and then run the console application Program

-Run the CreditInfoWebAPI on IIS and use the two provided methods to return values


NOTE:
I did not have enough time to implement everything, so I have done a barebones version of each component:

-DB script can be run to create full database
-CreditInfoDataLoader does not import to database, but it does read from the file and does most of the importing into memory
-CreditInfoWebAPI is there as a placeholder with the IndividualController and Search/Detail methods to be expanded to read from DB and return results.