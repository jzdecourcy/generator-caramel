sqlcmd -S (local) -i CreateDatabase.sql
CALL Migrate.bat
PAUSE