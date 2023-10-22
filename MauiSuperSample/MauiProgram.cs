using MauiSuperSample.Util;
using MauiSuperSample.View;
using MauiSuperSample.Viewmodel;
using Microsoft.Extensions.Logging;

namespace MauiSuperSample
{
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

            builder.Services.AddSingleton<ReadLocalFile>();


            builder.Services.AddTransient<View1ViewModel>();


            builder.Services.AddTransient<View1>();

            return builder.Build();
        }
    }
}