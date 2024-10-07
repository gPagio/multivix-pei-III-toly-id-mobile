using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TolyID.Helpers;
using TolyID.MVVM.Models;
using TolyID.MVVM.Views;
using TolyID.MVVM.Views.CadastroDeCaptura;
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

    private int _numeroDeCapturas;
    public int NumeroDeCapturas
    {
        get => _numeroDeCapturas;
        set => SetProperty(ref _numeroDeCapturas, value);
    }

    public TatuViewModel(Tatu tatu, TatuService tatuService, CapturaService capturaService)
    {
        Tatu = tatu;
        _tatuService = tatuService;
        _capturaService = capturaService;
        AtualizaNumeroDeCapturas();
    }

    private void AtualizaNumeroDeCapturas()
    {
        if (Tatu != null && Tatu.Capturas != null)
        {
            NumeroDeCapturas = Tatu.Capturas.Count;
        }
        else
        {
            NumeroDeCapturas = 0;
        }
    }

    public async Task AtualizaTatu(Tatu tatu)
    {
        Tatu = await _tatuService.GetTatu(tatu.Id);
        AtualizaNumeroDeCapturas();
    }

    [RelayCommand]
    private async Task VisualizaCaptura(Captura captura)
    {
        var viewModel = new CapturaViewModel(_capturaService);
        await Shell.Current.Navigation.PushAsync(new CapturaView(captura, viewModel));
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
        CadastroCapturaViewModel vm = new(_tatu, _capturaService);
        await Shell.Current.Navigation.PushAsync(new DadosGeraisView(vm));
        AtualizaNumeroDeCapturas();
    }
}
