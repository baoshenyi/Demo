1. ErrorHandler.dtsx
https://www.sqlshack.com/an-overview-of-error-handling-in-ssis-package/
IntegrationServicesProject\FlatFile
Porcess ErrorHandler.csv and get failed records from Error.csv

2. Checkpoints.dtsx (click F4 to add checkpoint)
https://www.sqlshack.com/using-checkpoint-in-ssis-package-to-restart-package-execution/
update [dbo].[Destination] set [Total Amount]='Eighty' 
(failed)=> find IntegrationServicesProject\Checkpoint\Checkpoint.xml
update [dbo].[Destination] set Name='Gilly' where Name='Gill'
Only "Update records" runs

3. LogingAudit.dtsx
https://medium.com/@shristibal1998/creating-sql-profiler-type-logging-in-ssis-eba686d1e491
Right click package and choose "Logging" to add SQL Database, SQL Profiler and windows event logging
SELECT *
  FROM [dbo].[sysssislog]
  
4. WebAPI.dtsx
https://docs.microsoft.com/en-us/archive/blogs/dbrowne/how-to-load-an-assembly-in-a-ssis-script-task-that-isnt-in-the-gac
Nuget package used in script task has been loaded to GAC or use "AppDomain.CurrentDomain.AssemblyResolve"

5.  Business intelligence
https://pragmaticworks.com/resources/free-webinars/

6. Know package meet enterprise standard or not
https://www.sqlshack.com/how-to-retrieve-information-about-ssis-packages-stored-in-msdb-database/
https://docs.microsoft.com/en-us/openspecs/sql_data_portability/ms-dtsx/d578be53-65c5-424e-8757-1e8c4e33b56b?redirectedfrom=MSDN
