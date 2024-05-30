using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
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
