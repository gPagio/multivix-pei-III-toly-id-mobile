using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TolyID.MVVM.Models;
using TolyID.MVVM.Views;
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

    [RelayCommand]
    async Task DeletaTatu(TatuModel tatu)
    {
        await BancoDeDadosService.DeletaTatuAsync(tatu.Id);
        await BuscaTatusNoBanco();
    }

    [RelayCommand]
    async Task VisualizaTatu(TatuModel tatu)
    {
        Debug.WriteLine("AOBA");
        await Shell.Current.Navigation.PushAsync(new TatuView(tatu));
    }
}
