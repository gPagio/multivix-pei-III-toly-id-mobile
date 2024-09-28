using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class CadastroTatuViewModel : ObservableObject
{
    [ObservableProperty]
    private TatuModel tatu;

    public CadastroTatuViewModel() 
    {
        Tatu = new();
    }

    public async Task AdicionaTatuNoBanco()
    {
       await BancoDeDadosService.SalvaTatu(Tatu);
    }

    [RelayCommand]
    private async Task Adiciona()
    {
        if (Tatu.IdentificacaoAnimal == "")
        {
            CriaToast("Preencha a identificação!");
            return;
        }

        await AdicionaTatuNoBanco();
        CriaToast("Novo tatu salvo!");
    }

    private async void CriaToast(string mensagem)
    {
        var toast = Toast.Make(mensagem, ToastDuration.Short, 14);
        await toast.Show();
    }
}
