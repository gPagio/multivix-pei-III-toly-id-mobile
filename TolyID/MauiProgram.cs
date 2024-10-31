using CommunityToolkit.Maui;
using TolyID.MVVM.Views;
using TolyID.MVVM.ViewModels;
using Microsoft.Extensions.Logging;
using TolyID.Services;
using UraniumUI;
using TolyID.Services.Api;
using TolyID.Services.Api.Cadastrar;
using TolyID.Services.Api.Ler;
using TolyID.Services.Api.Gerar;

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
                .UseUraniumUI()
                .UseUraniumUIMaterial() 
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<BaseApi>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        // REGISTRO DE SERVICES
        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {   
            // BANCO LOCAL
            mauiAppBuilder.Services.AddSingleton<BaseDatabaseService>();
            mauiAppBuilder.Services.AddSingleton<TatuService>();
            mauiAppBuilder.Services.AddSingleton<CapturaService>();

            // API: CADASTRAR
            mauiAppBuilder.Services.AddTransient<CadastrarCapturaApiService>();
            mauiAppBuilder.Services.AddTransient<CadastrarTatuApiService>();

            // API: GERAR TOKEN
            mauiAppBuilder.Services.AddTransient<GerarTokenApiService>();

            // API: LER
            mauiAppBuilder.Services.AddTransient<LerCapturasApiService>();
            mauiAppBuilder.Services.AddTransient<LerTatuApiService>();

            mauiAppBuilder.Services.AddSingleton<BaseApi>();
            mauiAppBuilder.Services.AddTransient<CapturaApiService>();
            mauiAppBuilder.Services.AddTransient<TatusApiService>();
            mauiAppBuilder.Services.AddTransient<TokenApiService>();

            return mauiAppBuilder;
        }

        // REGISTRO DE VIEWMODELS
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuider)
        {
            mauiAppBuider.Services.AddSingleton<TatusCadastradosViewModel>();

            mauiAppBuider.Services.AddTransient<LoginViewModel>();
            mauiAppBuider.Services.AddTransient<CadastroUsuarioViewModel>();
            mauiAppBuider.Services.AddTransient<ConfiguracoesViewModel>();

            return mauiAppBuider;
        }

        // REGISTRO DE TELAS
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuider)
        { 
            mauiAppBuider.Services.AddSingleton<TatusCadastradosView>();

            mauiAppBuider.Services.AddTransient<LoginView>();
            mauiAppBuider.Services.AddTransient<CadastroUsuarioView>();
            mauiAppBuider.Services.AddTransient<ConfiguracoesView>();

            return mauiAppBuider;
        }
    }
}
