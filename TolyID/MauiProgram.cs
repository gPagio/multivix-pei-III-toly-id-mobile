using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using TolyID.MVVM.Views;
using TolyID.MVVM.ViewModels;

namespace TolyID
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .RegisterViewModels()
                .RegisterViews()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        // REGISTRO DE VIEWMODELS
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuider)
        {
            mauiAppBuider.Services.AddSingleton<TatusCadastradosViewModel>();

            return mauiAppBuider;
        }

        // REGISTRO DE TELAS
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuider)
        {
            mauiAppBuider.Services.AddSingleton<TatusCadastradosView>();

            return mauiAppBuider;
        }
    }
}
