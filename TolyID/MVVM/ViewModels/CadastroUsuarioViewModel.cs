using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TolyID.MVVM.ViewModels;

public partial class CadastroUsuarioViewModel : ObservableObject
{
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
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Erro", "Cadastro inválido", "OK");
        }
    }

    [RelayCommand]
    private async Task VoltaParaLogin()
    {
        await Shell.Current.GoToAsync("//LoginView");
    }
}
