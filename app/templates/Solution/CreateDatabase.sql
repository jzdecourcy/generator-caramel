EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'<%= applicationName %>'
GO
USE [master]
GO
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'<%= applicationName %>')
DROP DATABASE [<%= applicationName %>]
GO
CREATE DATABASE [<%= applicationName %>]
GO
USE [master]
GO
IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'<%= applicationName %>Web')
DROP LOGIN [<%= applicationName %>Web]
GO
USE [master]
GO
CREATE LOGIN [<%= applicationName %>Web] WITH PASSWORD=N'Test123!', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [<%= applicationName %>]
GO
CREATE USER [<%= applicationName %>Web] FOR LOGIN [<%= applicationName %>Web]
GO
USE [<%= applicationName %>]
GO
EXEC sp_addrolemember N'db_datareader', N'<%= applicationName %>Web'
GO
USE [<%= applicationName %>]
GO
EXEC sp_addrolemember N'db_datawriter', N'<%= applicationName %>Web'
GO
IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'<%= applicationName %>Report')
DROP LOGIN [<%= applicationName %>Report]
GO
USE [master]
GO
CREATE LOGIN [<%= applicationName %>Report] WITH PASSWORD=N'Test123!', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [<%= applicationName %>]
GO
CREATE USER [<%= applicationName %>Report] FOR LOGIN [<%= applicationName %>Report]
GO
USE [<%= applicationName %>]
GO
EXEC sp_addrolemember N'db_datareader', N'<%= applicationName %>Report'
GO
