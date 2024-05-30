using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class TatuViewModel : ObservableObject
{
    public ObservableCollection<CapturaModel> Capturas { get; } = new();

    public async Task BuscaCapturasNoBanco()
    {
        var capturas = await BancoDeDadosService.GetCapturasAsync();
        Capturas.Clear();

        foreach (var captura in capturas)
        {
            Capturas.Add(captura);
        }
    }
}
