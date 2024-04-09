using SqliteDBManager.Utilities.Enum;

namespace SqliteDBManager.Database.DBManager;

internal interface IDBManager
{
    Task ZipDBFile(DBEnum DbToZip);
    Task<bool> DeleteAllZipFiles();
    Task UnzipDBFile(DBEnum DbToZip);
}
