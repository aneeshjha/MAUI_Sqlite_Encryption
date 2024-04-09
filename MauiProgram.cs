using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using SqliteDBManager.Database.DBManager;
using SqliteDBManager.Database.LocalDB.User;
using SqliteDBManager.Database.LocalDB.Protocol;
using SqliteDBManager.Database.LocalDB.MetaData;
using SqliteDBManager.Database.LocalDB.Central;

namespace SqliteDBManager;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        })
            .RegisterServices()
            .UseMauiCommunityToolkit();
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IDBManager,DBManager>();
        builder.Services.AddSingleton<IUserDB, UserDB>();
        builder.Services.AddSingleton<IProtocolDB, ProtocolDB>();
        builder.Services.AddSingleton<IMetadataDB, MetadataDB>();
        builder.Services.AddSingleton<ICentralDB, CentralDB>();
        return builder;
    }
}