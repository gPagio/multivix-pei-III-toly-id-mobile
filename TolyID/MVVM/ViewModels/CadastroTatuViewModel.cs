using CommunityToolkit.Mvvm.ComponentModel;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class CadastroTatuViewModel : ObservableObject
{
    [ObservableProperty]
    private static TatuModel tatu = new();

    public static async Task AdicionaTatuNoBanco()
    {
       await BancoDeDadosService.SalvaTatuAsync(tatu);
    }
}
