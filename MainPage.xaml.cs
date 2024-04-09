using SqliteDBManager.Database.DBManager;
using SqliteDBManager.Database.LocalDB.Central;
using SqliteDBManager.Database.LocalDB.MetaData;
using SqliteDBManager.Database.LocalDB.Protocol;
using SqliteDBManager.Database.LocalDB.User;

namespace SqliteDBManager
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly IDBManager _dbManager;
        private readonly IUserDB _userDB;
        private readonly IMetadataDB _metadataDB;
        private readonly IProtocolDB _protocolDB;
        private readonly ICentralDB _centralDB;

        public MainPage()
        {
            try
            {
                InitializeComponent();
                _userDB = new UserDB();
                _metadataDB = new MetadataDB();
                _protocolDB = new ProtocolDB();
                _centralDB = new CentralDB();
                _dbManager = new DBManager(_userDB, _metadataDB, _protocolDB, _centralDB);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            try
            {
                _dbManager.ZipDBFile(Utilities.Enum.DBEnum.UserDB);
                _dbManager.ZipDBFile(Utilities.Enum.DBEnum.MetadataDB);
                _dbManager.ZipDBFile(Utilities.Enum.DBEnum.ProtocolDB);
                _dbManager.ZipDBFile(Utilities.Enum.DBEnum.CentralDB);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}
