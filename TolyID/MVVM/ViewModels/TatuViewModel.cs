using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TolyID.Helpers;
using TolyID.MVVM.Models;
using TolyID.MVVM.Views;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class TatuViewModel : ObservableObject
{
    private readonly TatuService _tatuService;
    private readonly CapturaService _capturaService;

    private Tatu _tatu;
    public Tatu Tatu
    {
        get => _tatu;
        set => SetProperty(ref _tatu, value);
    }

    public TatuViewModel(Tatu tatu, TatuService tatuService, CapturaService capturaService)
    {
        Tatu = tatu;
        _tatuService = tatuService;
        _capturaService = capturaService;
    }

    public async Task AtualizaTatu(Tatu tatu)
    {
        Tatu = await _tatuService.GetTatu(tatu.Id);
    }

    [RelayCommand]
    private async Task VisualizaCaptura(Captura captura)
    {
        var viewModel = new CapturaViewModel(_capturaService);
        await Shell.Current.Navigation.PushAsync(new CapturaView(captura, viewModel, _tatuService));
    }

    [RelayCommand]
    private async Task DeletaCaptura(Captura captura)
    {
        bool resposta = await Application.Current.MainPage.DisplayAlert
            ("Confirmação",
            "Você tem certeza que deseja excluir a captura?",
            "Sim",
            "Não");
        
        if (resposta) 
        {
            await _capturaService.DeletaCaptura(captura);
            await AtualizaTatu(Tatu);
        }
    }

    [RelayCommand]
    private async Task EditaTatu()
    {
        var tatuService = ServiceHelper.GetService<TatuService>();
        var viewModel = new EditarTatuViewModel(Tatu, tatuService);
        var popup = new EditarTatuPopup(viewModel);
        await Shell.Current.CurrentPage.ShowPopupAsync(popup);
        await AtualizaTatu(Tatu);
    }

    [RelayCommand]
    private async Task AdicionaCaptura()
    {
        await Shell.Current.Navigation.PushModalAsync(new NavigationPage(new CadastroCapturaTabbedView(Tatu, _capturaService)), true);
    }
}
