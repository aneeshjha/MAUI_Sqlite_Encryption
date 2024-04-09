using SqliteDBManager.Database.LocalDB.Central;
using SqliteDBManager.Database.LocalDB.MetaData;
using SqliteDBManager.Database.LocalDB.Protocol;
using SqliteDBManager.Database.LocalDB.User;
using SqliteDBManager.Utilities.Constants;
using SqliteDBManager.Utilities.Enum;
using System.IO.Compression;

namespace SqliteDBManager.Database.DBManager;

internal class DBManager : IDBManager
{
    private readonly IUserDB _userDB;
    private readonly IMetadataDB _metadataDB;
    private readonly IProtocolDB _protocolDB;
    private readonly ICentralDB _centralDB;
    public DBManager(IUserDB userDB,
        IMetadataDB metadataDB,
        IProtocolDB protocolDB,
        ICentralDB centralDB)
    {
        _userDB = userDB;
        _metadataDB = metadataDB;
        _protocolDB = protocolDB;
        _centralDB = centralDB;
    }
    public Task<bool> DeleteAllZipFiles()
    {
        throw new NotImplementedException();
    }

    public Task UnzipDBFile(DBEnum DbToZip)
    {
        throw new NotImplementedException();
    }

    public async Task ZipDBFile(DBEnum DbToZip)
    {
        try
        {
            string zipFileName = string.Empty;
            string sourceFileName = string.Empty;
            switch (DbToZip)
            {
                case DBEnum.UserDB:
                    zipFileName = DBConstants.UserDBname;
                    sourceFileName = _userDB.DatabaseFilePath;
                    break;
                case DBEnum.MetadataDB:
                    zipFileName = DBConstants.MetadataDBname;
                    sourceFileName = _metadataDB.DatabaseFilePath;
                    break;
                case DBEnum.ProtocolDB:
                    zipFileName = DBConstants.ProtocolDBname;
                    sourceFileName = _protocolDB.DatabaseFilePath;
                    break;
                case DBEnum.CentralDB:
                    zipFileName = DBConstants.CentralDBname;
                    sourceFileName = _centralDB.DatabaseFilePath;
                    break;
                default:
                    break;
            }
            string zipFilePath = Path.Combine(FileSystem.CacheDirectory, $"{zipFileName}.zip");
            if (File.Exists(zipFilePath))
            {
                File.Delete(zipFilePath);
            }
            Zip(zipFilePath, sourceFileName);
        }
        catch (Exception ex)
        {

            throw;
        }

    }

    private void Zip(string zipFilePath, string sourceFileName)
    {
        using (ZipArchive zip = ZipFile.Open(zipFilePath, ZipArchiveMode.Create))
        {
            zip.CreateEntryFromFile(sourceFileName, Path.GetFileName(sourceFileName), CompressionLevel.Optimal);
        }
    }
}
