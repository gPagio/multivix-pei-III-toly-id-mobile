using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TolyID.Services.Api;

namespace TolyID.MVVM.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private string email;
    [ObservableProperty]
    private string senha;

    private readonly TokenApiService _tokenApiService;

    public LoginViewModel(TokenApiService tokenApiService)
    {
        _tokenApiService = tokenApiService;
    }

    [RelayCommand]
    private async Task RealizaLogin()
    {
        try
        {
            await _tokenApiService.GeraToken(email, senha);
            await Shell.Current.GoToAsync("//MainPage");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Erro", $"Erro ao realizar login: {ex.Message}", "Ok");
        }       
    }
    
    [RelayCommand]
    private async Task NavegaParaParaTelaDeCadastro()
    {
        await Shell.Current.GoToAsync("//CadastroView");
    }
}
