using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TolyID.MVVM.Models;
using TolyID.MVVM.Views;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class TatuViewModel : ObservableObject
{
    private TatuModel _tatu;
    public TatuModel Tatu
    {
        get => _tatu;
        set => SetProperty(ref _tatu, value);
    }

    public TatuViewModel(TatuModel tatu)
    {
        Tatu = tatu;
    }

    public async Task AtualizaTatu(TatuModel tatu)
    {
        Tatu = await BancoDeDadosService.GetTatu(tatu.Id);
    }

    [RelayCommand]
    private async Task VisualizaCaptura(CapturaModel captura)
    {
        await Shell.Current.Navigation.PushAsync(new CapturaView(captura));
    }

    [RelayCommand]
    private async Task DeletaCaptura(CapturaModel captura)
    {
        await BancoDeDadosService.DeletaCaptura(captura);
        await AtualizaTatu(Tatu);
    }

    [RelayCommand]
    private async Task EditaTatu()
    {
        var viewModel = new MicrochipViewModel(Tatu);
        var popup = new MicrochipPopup(viewModel);
        await Shell.Current.CurrentPage.ShowPopupAsync(popup);
        await AtualizaTatu(Tatu);
    }

    [RelayCommand]
    private async Task AdicionaCaptura()
    {
        await Shell.Current.Navigation.PushModalAsync(new NavigationPage(new CadastroCapturaTabbedView(Tatu)), true);
    }
}
