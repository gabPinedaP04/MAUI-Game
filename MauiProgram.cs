using Microsoft.Extensions.Logging;

namespace juego;

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
				fonts.AddFont("CloisterBlack.ttf", "sana");
				fonts.AddFont("pricedown bl.otf", "gta");

			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
