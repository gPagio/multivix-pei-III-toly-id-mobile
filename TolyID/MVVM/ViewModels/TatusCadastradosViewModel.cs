using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TolyID.MVVM.Models;
using TolyID.MVVM.Views;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class TatusCadastradosViewModel : ObservableObject
{
    public ObservableCollection<TatuModel> Tatus { get; } = new();

    public async Task BuscaTatusNoBanco()
    {
        var tatus = await BancoDeDadosService.GetTatus();
        Tatus.Clear();

        foreach (var tatu in tatus)
        {
            Tatus.Add(tatu);
        }
    }

    [RelayCommand]
    private async Task DeletaTatu(TatuModel tatu)
    {
        await BancoDeDadosService.DeletaTatu(tatu);
        await BuscaTatusNoBanco();
    }

    [RelayCommand]
    private async Task VisualizaTatu(TatuModel tatu)
    {
        await Shell.Current.Navigation.PushAsync(new TatuView(tatu));
    }
}
