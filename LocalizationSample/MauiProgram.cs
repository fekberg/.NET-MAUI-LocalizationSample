﻿using Microsoft.Extensions.Logging;

namespace LocalizationSample;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif

        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("sv-SE");
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sv-SE");
		AppResources.Culture = Thread.CurrentThread.CurrentCulture;

		builder.Services.AddLocalization();
		builder.Services.AddTransient<MainPage>();

        return builder.Build();
	}
}
