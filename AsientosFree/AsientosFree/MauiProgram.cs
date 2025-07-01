using AsientosFree.Services;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;

namespace AsientosFree;

public static class MauiProgram
{
	public static AppDatabase _appDb;

	public static MauiApp CreateMauiApp()
	{
		

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string dbPath = Path.Combine(FileSystem.AppDataDirectory, "AsientosFree.db3");
		_appDb = new AppDatabase(dbPath);

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
