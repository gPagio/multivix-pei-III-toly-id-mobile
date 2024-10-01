using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TolyID.Helpers;
using TolyID.MVVM.Models;
using TolyID.MVVM.Views;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class TatusCadastradosViewModel : ObservableObject
{
    private readonly TatuService _tatuService;
    public ObservableCollection<Tatu> Tatus { get; } = new();

    public TatusCadastradosViewModel(TatuService tatuService)
    {
        _tatuService = tatuService;
        BuscaTatusNoBanco();
    }

    public async void BuscaTatusNoBanco()
    {
        var tatus = await _tatuService.GetTatus();
        Tatus.Clear();

        foreach (var tatu in tatus)
        {
            Tatus.Add(tatu);
        }
    }

    [RelayCommand]
    private async Task DeletaTatu(Tatu tatu)
    {
        await _tatuService.DeletaTatu(tatu);
        BuscaTatusNoBanco();
    }

    [RelayCommand]
    private async Task VisualizaTatu(Tatu tatu)
    {
        var capturaService = ServiceHelper.GetService<CapturaService>();

        var tatuView = new TatuView(new TatuViewModel(tatu, _tatuService, capturaService), tatu);
        await Shell.Current.Navigation.PushAsync(tatuView);
    }

    [RelayCommand]
    private async Task NovoTatu()
    {
        await Shell.Current.CurrentPage.ShowPopupAsync(new CadastroTatuPopup(new CadastroTatuViewModel(_tatuService)));
        BuscaTatusNoBanco();
    }
}
