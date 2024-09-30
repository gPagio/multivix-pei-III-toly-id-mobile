using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
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

    public TatusCadastradosViewModel()
    {
        BuscaTatusNoBanco();
    }

    public async void BuscaTatusNoBanco()
    {
        var tatus = await BaseDatabaseService.GetTatus();
        Tatus.Clear();

        foreach (var tatu in tatus)
        {
            Tatus.Add(tatu);
        }
    }

    [RelayCommand]
    private async Task DeletaTatu(TatuModel tatu)
    {
        await BaseDatabaseService.DeletaTatu(tatu);
        BuscaTatusNoBanco();
    }

    [RelayCommand]
    private async Task VisualizaTatu(TatuModel tatu)
    {
        var tatuView = new TatuView(new TatuViewModel(tatu), tatu);
        await Shell.Current.Navigation.PushAsync(tatuView);
    }

    [RelayCommand]
    private async Task NovoTatu()
    {
        await Shell.Current.CurrentPage.ShowPopupAsync(new CadastroTatuPopup(new CadastroTatuViewModel()));
        BuscaTatusNoBanco();
    }
}
