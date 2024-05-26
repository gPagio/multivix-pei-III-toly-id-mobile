using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class CapturasViewModel : ObservableObject
{
    public ObservableCollection<TatuCapturadoModel> Tatus { get; } = new();

    [RelayCommand]
    public async Task CarregaTatus()
    {
        var tatus = await BancoDeDadosService.GetTatusAsync();
        Tatus.Clear();
        
        foreach (var tatu in tatus)
        {
            Debug.WriteLine($"{tatu.Id} - {tatu.DadosGerais.DataDeCaptura} - {tatu.DadosGerais.Id}");
            Tatus.Add(tatu);
        }
    }

}
