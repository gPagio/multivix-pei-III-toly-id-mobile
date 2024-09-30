﻿using CommunityToolkit.Maui;
using TolyID.MVVM.Views;
using TolyID.MVVM.ViewModels;
using Microsoft.Extensions.Logging;
using TolyID.Services;
using TolyID.MVVM.Models;

namespace TolyID
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .RegisterServices()
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

        // REGISTRO DE SERVICES
        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            //var caminhoDoBanco = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tatu.db3");

            mauiAppBuilder.Services.AddSingleton<BaseDatabaseService>();
            mauiAppBuilder.Services.AddSingleton<TatuService>();
            mauiAppBuilder.Services.AddSingleton<CapturaService>();

            return mauiAppBuilder;
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
