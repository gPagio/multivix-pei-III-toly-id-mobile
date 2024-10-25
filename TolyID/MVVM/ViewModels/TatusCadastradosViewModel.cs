using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TolyID.DTO;
using TolyID.Helpers;
using TolyID.MVVM.Models;
using TolyID.MVVM.Views;
using TolyID.Services;
using TolyID.Services.Api;

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
        bool resposta = await Application.Current.MainPage.DisplayAlert
            ("Confirmação", 
            $"Você tem certeza que deseja excluir o tatu {tatu.IdentificacaoAnimal}?", 
            "Sim", 
            "Não");

        if (resposta) 
        {
            await _tatuService.DeletaTatu(tatu);
            BuscaTatusNoBanco();
        }
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

    [RelayCommand]
    private async Task Deslogar()
    {
        bool resposta = await Application.Current.MainPage.DisplayAlert
            ("Confirmação",
            $"Você tem certeza que deseja sair?",
            "Sim",
            "Não");

        if (resposta)
        {
            await Shell.Current.GoToAsync("//LoginView");
        }
    }

    [RelayCommand]
    private async Task GerarTokenApi()
    {
        var tatuService = new TatuService();
        var apiTatu = new CadastrarTatuApiService();
        List<Tatu> listaTatus = await tatuService.GetTatusNaoCadastrados();
        foreach (var tatu in listaTatus)
        {
            await apiTatu.Cadastrar(tatu);
        }

        var capturaService = new CapturaService();
        var apiCaptura = new CadastrarCapturaApi();
        try
        {

            Captura captura = await capturaService.GetCaptura(1);
           
                CapturaDTO DTO = new DTO.CapturaDTO(captura);
                await apiCaptura.CadastrarCaptura(DTO, captura);

        }
        catch (Exception ex)
        {
            // Tratar exceções (log, alertar o usuário, etc.)
            Console.WriteLine($"Erro: {ex.Message}");
        }

    }
}
