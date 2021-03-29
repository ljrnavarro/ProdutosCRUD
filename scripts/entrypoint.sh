#!/bin/bash
echo "... Starting scripts"
sh -c 

cd /usr/src/scripts

sleep 35

echo "Start running SQL Scripts"

ls

for fs in *.sql
do
    echo "Executing script $fs"
    /opt/mssql-tools/bin/sqlcmd -S 0.0.0.0 -U sa -P sqlserver@123 -i "$fs" 
done
echo 'Finished setup script'

