using SQLite;
using SqliteDBManager.Models;
using SqliteDBManager.Utilities.Constants;

namespace SqliteDBManager.Database.LocalDB.Central;

internal class CentralDB : ICentralDB
{
    private SQLiteAsyncConnection _connection;
    public object Connection => _connection;

    public string DatabaseName => DBConstants.CentralDBname;

    public string DatabaseFileName => DBConstants.CentralDBname;

    public string DatabaseFolder => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

    public string DatabaseFilePath => Path.Combine(DatabaseFolder, DatabaseName);

    public string DatabaseVersion => "1.00";

    public bool Exists => File.Exists(DatabaseFilePath);

    private Lazy<SQLiteAsyncConnection> _databaseConnectionHolder;

    private static object collisionLock = new object();

    public CentralDB()
    {
        try
        {
            SetupUserDB();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    private void SetupUserDB()
    {
        var options = new SQLiteConnectionString(DatabaseFilePath, true, "password");
        _databaseConnectionHolder = new Lazy<SQLiteAsyncConnection>(() =>
                                            new SQLiteAsyncConnection(options));
        _connection = _connection ?? _databaseConnectionHolder.Value;
        SetupTables();
    }

    public void Backup()
    {

    }

    /// <summary>
    /// initialising 
    /// </summary>
    public void Init()
    {
        try
        {
            if (!Exists || _connection == null)
            {
                SetupUserDB();
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool IsExistingDatabaseImageValid()
    {
        try
        {   // Check Connection Set
            if (_connection == null) Init();
            return (_connection != null) ? true : false;
        }
        catch
        {
            return false;
        }
    }

    private void SetupTables()
    {
        CreateTablesAsync<Sample>();
    }

    /// <summary>
    /// Create Query and add constraints query.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    protected void CreateTablesAsync<T>()
    {
        if (!_connection.TableMappings.Any(x => x.TableName == typeof(T).Name))
        {
            lock (collisionLock)
            {
                _connection.CreateTablesAsync(CreateFlags.None, typeof(T)).ConfigureAwait(false);
                switch (typeof(T).Name)
                {
                    case "Sample":
                        _connection.ExecuteAsync("CREATE UNIQUE INDEX IX_Sample ON Sample (Id, Name, VersionNum)");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
