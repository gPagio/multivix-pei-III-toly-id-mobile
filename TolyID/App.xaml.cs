#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using TolyID.Constants;
using TolyID.Helpers;
using TolyID.MVVM.ViewModels;
using TolyID.MVVM.Views;
using TolyID.MVVM.Views.CadastroDeCaptura;
using Microsoft.Maui.Storage;
using Microsoft.Maui.ApplicationModel;
using TolyID.Services;

namespace TolyID;

public partial class App : Application
{
    private readonly BaseDatabaseService _baseDatabaseService;

    public App(BaseDatabaseService baseDatabaseService)
    {
        InitializeComponent();
        _baseDatabaseService = baseDatabaseService;
        IniciarBancoDeDados();
        MainPage = new CarregamentoView();  
    }

    private async void IniciarBancoDeDados()
    {
        await _baseDatabaseService.Init();
    }

    protected override async void OnStart()
    {
        bool usuarioEstaLogado = await CheckarUsuarioLogado();

        if (usuarioEstaLogado)
        {
            MainPage = new AppShell();
        }
        else
        {
            var loginView = ServiceHelper.GetService<LoginView>();
            MainPage = loginView;
        }
    }

    private async Task<bool> CheckarUsuarioLogado()
    {
        var token = await SecureStorage.GetAsync(AppConstants.SECURE_STORAGE_API_TOKEN_KEY);

        if (!string.IsNullOrEmpty(token) && TokenValido(token))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool TokenValido(string token)
    {
        JwtSecurityTokenHandler jwtHandler = new();
        var jwtToken = jwtHandler.ReadJwtToken(token);

        Debug.WriteLine(jwtToken.ValidTo);

        return jwtToken.ValidTo > DateTime.UtcNow;
    }
}
