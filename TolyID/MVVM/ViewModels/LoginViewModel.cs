using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace TolyID.MVVM.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    [RelayCommand]
    private async Task Login()
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
    
    [RelayCommand]
    private async Task IrParaTelaDeCadastro()
    {
        await Shell.Current.GoToAsync("//CadastroView");
    }
}
