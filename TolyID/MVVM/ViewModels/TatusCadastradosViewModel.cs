using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TolyID.Helpers;
using TolyID.Messages;
using TolyID.MVVM.Models;
using TolyID.MVVM.Views;
using TolyID.MVVM.Views.BottomSheet;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class TatusCadastradosViewModel : ObservableObject
{
    private readonly TatuService _tatuService;
    public ObservableCollection<Tatu> Tatus { get; } = new();

    public TatusCadastradosViewModel(TatuService tatuService)
    {
        // Mensagem de ordenação, que é enviada do OrdenarBottomSheet
        WeakReferenceMessenger.Default.Register<OrdenarTatusMessage>(this, (r, m) =>
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                OrdenaTatus(m.Value);
            });
        });

        _tatuService = tatuService;
        Task.Run(() => BuscaTatusNoBanco());
    }

    public async Task BuscaTatusNoBanco()
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
        bool resposta = await Shell.Current.DisplayAlert
            ("Confirmação", 
            $"Você tem certeza que deseja excluir o tatu {tatu.IdentificacaoAnimal}?", 
            "Sim", 
            "Não");

        if (resposta) 
        {
            await _tatuService.DeletaTatu(tatu);
            await BuscaTatusNoBanco();
        }
    }

    [RelayCommand]
    private async Task VisualizaTatu(Tatu tatu)
    {
        Debug.WriteLine(tatu.FoiEnviadoParaApi);
        var capturaService = ServiceHelper.GetService<CapturaService>();
        var tatuView = new TatuView(new TatuViewModel(tatu, _tatuService, capturaService), tatu);
        await Shell.Current.Navigation.PushAsync(tatuView);
    }

    [RelayCommand]
    private async Task NovoTatu()
    {
        await Shell.Current.CurrentPage.ShowPopupAsync(new CadastroTatuPopup(new CadastroTatuViewModel(_tatuService)));
        await BuscaTatusNoBanco();
    }

    [RelayCommand]
    private async Task Configuracoes()
    {
        await Shell.Current.GoToAsync("ConfiguracoesView");
    }

    [RelayCommand]
    private async Task FiltrosDeOrdenacao()
    {
        var ordenar = ServiceHelper.GetService<OrdenarTatusBottomSheet>();
        await ordenar.ShowAsync();
    }

    private void OrdenaTatus(Dictionary<int, int> ordemEParametro)
    {
        // Key (ordem): 0 = decrescente, 1 = crescente
        // Value (parâmetro): 0 = nome, 1 = qtd de capturas, 2 = data da última captura

        int ordem = ordemEParametro.Keys.FirstOrDefault();
        int parametro = ordemEParametro.Values.FirstOrDefault();

        var listaDeTatus = Tatus.ToList();

        switch (parametro) 
        {
            case 0: // Ordenar por nome

                listaDeTatus = ordem == 1 
                    ? listaDeTatus.OrderBy(t => t.IdentificacaoAnimal).ToList()
                    : listaDeTatus.OrderByDescending(t => t.IdentificacaoAnimal).ToList();
                break;

            case 1: // Ordenar por qtd de capturas

                listaDeTatus = ordem == 1
                    ? listaDeTatus.OrderBy(t => t.Capturas.Count).ToList()
                    : listaDeTatus.OrderByDescending(t => t.Capturas.Count).ToList();
                break;

            case 2: // Ordenar por data da última captura

                listaDeTatus = ordem == 1
                    ? listaDeTatus.OrderBy(t => t.Capturas.LastOrDefault()?.DadosGerais.DataHoraDeCaptura).ToList()
                    : listaDeTatus.OrderByDescending(t => t.Capturas.LastOrDefault()?.DadosGerais.DataHoraDeCaptura).ToList();
                break;
        }

        Tatus.Clear();

        foreach (var tatu in listaDeTatus)
        {
            Tatus.Add(tatu);
        }
    }
}
