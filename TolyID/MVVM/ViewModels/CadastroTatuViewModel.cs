using CommunityToolkit.Mvvm.ComponentModel;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class CadastroTatuViewModel : ObservableObject
{
    [ObservableProperty]
    private TatuModel tatu = new();

    public async Task AdicionaTatuNoBanco()
    {
       await BancoDeDadosService.SalvaTatu(Tatu);
    }
}
