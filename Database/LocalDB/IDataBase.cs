namespace SqliteDBManager.Database.LocalDB;

internal interface IDataBase
{
    object Connection { get; }
    string DatabaseName { get; }
    string DatabaseFilePath { get; }
    string DatabaseFileName { get; }
    string DatabaseFolder { get; }
    string DatabaseVersion { get; }
    bool Exists { get; }
    bool IsExistingDatabaseImageValid();
    void Backup();
    void Init();
}
