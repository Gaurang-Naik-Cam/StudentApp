using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using DatabaseLibrary;
using StudentApp.Models;

namespace StudentApp;

public static class MauiProgram
{
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

		//builder.Services.AddSingleton<MainPage>();
		//builder.Services.AddDbContext<StudentDBContext>(options =>
		//	options.UseSqlite($"Filename={GetDatabasePath()}", x => x.MigrationsAssembly(nameof(DatabaseLibrary))));

		return builder.Build();
	}

    private static string GetDatabasePath()
    {
		var databasePath = string.Empty;
		var databaseName = "Activity5.db3";

		if(DeviceInfo.Platform == DevicePlatform.Android || DeviceInfo.Platform == DevicePlatform.WinUI)
		{
			databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseName);
		}
		return databasePath;

    }
}
