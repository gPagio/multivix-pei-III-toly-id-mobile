using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class CadastroTatuViewModel : ObservableObject
{
    private readonly TatuService _tatuService;

    [ObservableProperty]
    private Tatu tatu;

    public List<SexoTatu> sexosTatu { get; set; } = new()
    {
        SexoTatu.Macho,
        SexoTatu.Femea
    };

    public CadastroTatuViewModel(TatuService tatuService) 
    {
        _tatuService = tatuService;
        Tatu = new();
    }

    public async Task AdicionaTatuNoBanco()
    {
       await _tatuService.SalvaTatu(Tatu);
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
