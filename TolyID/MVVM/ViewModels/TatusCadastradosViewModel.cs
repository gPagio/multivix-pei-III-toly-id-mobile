using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class TatusCadastradosViewModel : ObservableObject
{
    public ObservableCollection<TatuModel> Tatus { get; } = new();

    public async Task BuscaTatusNoBanco()
    {
        var tatus = await BancoDeDadosService.GetTatusAsync();
        Tatus.Clear();

        foreach (var tatu in tatus)
        {
            Tatus.Add(tatu);
        }
    }
}
