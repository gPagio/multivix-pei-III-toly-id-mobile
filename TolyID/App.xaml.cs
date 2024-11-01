#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

using System.IdentityModel.Tokens.Jwt;
using TolyID.Constants;
using TolyID.MVVM.Views.CadastroDeCaptura;

namespace TolyID;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
        //MainPage = new BiometriaView(new MVVM.ViewModels.CadastroCapturaViewModel(new MVVM.Models.Tatu(), new Services.CapturaService())); 
    }

    protected override async void OnStart()
    {
        bool usuarioEstaLogado = await CheckarUsuarioLogado();

        if (!usuarioEstaLogado)
        {
            await Shell.Current.GoToAsync("//LoginView");
        }
    }

    private async Task<bool> CheckarUsuarioLogado()
    {
        var token = await SecureStorage.GetAsync(AppConstants.SECURE_STORAGE_API_TOKEN_KEY);

        if (string.IsNullOrEmpty(token)) 
        {
            return false;
        }

        JwtSecurityTokenHandler jwtHandler = new();
        var jwtToken = jwtHandler.ReadJwtToken(token);

        if (jwtToken.ValidTo < DateTime.UtcNow) 
        {
            return false;
        }

        return true;
    }
}
