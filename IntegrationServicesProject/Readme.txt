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