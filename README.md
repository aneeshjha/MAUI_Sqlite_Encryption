
# MAUI_Sqlite_Encryption

Author:

Aneesh Jha
aneeshkumarjha@gmail.com

Created multiple sqlite database file and encrypt them using sqliteCipher
Archieved the sqlite file

For Sqlite encryption I have used **sqlite-net-sqlcipher** 
https://www.nuget.org/packages/sqlite-net-sqlcipher/

To check if sqlite file is encrypted with password you can pull the sqlite file from android using adb commands and try to open in DB browser for sqlite-cipher. It will pop up a window to enter the key used while encrypting.

Many times we need to sync our data with backend server so we need to zip our file and upload it to server via api.
I have also added a code for zipping of sqlite and uploading it. Zipped files will be stored in cache folder of app sandbox and can be validated by pulling it using the adb commands.

