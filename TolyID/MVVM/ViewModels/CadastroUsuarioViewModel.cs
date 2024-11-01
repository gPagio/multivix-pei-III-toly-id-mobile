using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TolyID.MVVM.Models;

namespace TolyID.MVVM.ViewModels;

public partial class CadastroUsuarioViewModel : ObservableObject
{
    [ObservableProperty]
    private Usuario usuario;

    public CadastroUsuarioViewModel()
    {
        usuario = new Usuario();
    }

    private bool ConfirmaCadastro()
    {
        // TODO: IMPLEMENTAR LÓGICA
        return true;
    }
    
    [RelayCommand]
    private async Task Cadastro()
    {
        bool cadastroConfirmado = ConfirmaCadastro();

        if (cadastroConfirmado)
        {
            await Shell.Current.GoToAsync("//LoginView");
            await Shell.Current.DisplayAlert("Sucesso", "Cadastro realizado. Faça login para continuar.", "OK");
        }
        else
        {
            await Shell.Current.DisplayAlert("Erro", "Cadastro inválido.", "OK");
        }
    }

    [RelayCommand]
    private async Task VoltaParaLogin()
    {
        await Shell.Current.GoToAsync("//LoginView");
    }
}
