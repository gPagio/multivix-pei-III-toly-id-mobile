using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TolyID.Constants;
using TolyID.Services.Api;

namespace TolyID.MVVM.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string email;
    [ObservableProperty]
    private string senha;

    [ObservableProperty]
    bool estaCarregando = false;

    private readonly TokenApiService _tokenApiService;

    public LoginViewModel(TokenApiService tokenApiService)
    {
        _tokenApiService = tokenApiService;
    }

    [RelayCommand]
    private async Task RealizaLogin()
    {
        EstaCarregando = true;
        try
        {
            await _tokenApiService.GeraToken(Email, Senha);
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//MainPage");
        }
        catch 
        {
            await Application.Current.MainPage.DisplayAlert("Erro", $"Erro ao realizar login", "Ok");
        }    
        EstaCarregando = false;
    }

    [RelayCommand]
    private async Task ModoOffline()
    {
        bool resposta = await Application.Current.MainPage.DisplayAlert("Aviso", $"Você está entrando no modo offline. Será necessário fazer login para sincronizar os dados com a nuvem quando houver conexão de rede", "Continuar Offline", "Fazer Login");
        if (resposta) 
        {
            // Configura token como vazio para indicar que está em modo offline
            await SecureStorage.SetAsync(AppConstants.SECURE_STORAGE_API_TOKEN_KEY, "");
            
            Application.Current.MainPage = new AppShell();
        }
    }
    
    //[RelayCommand]
    //private async Task NavegaParaParaTelaDeCadastro()
    //{
    //    await Shell.Current.GoToAsync("//CadastroView");
    //}
}
