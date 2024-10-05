using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class CadastroCapturaViewModel : ObservableObject
{
    private readonly Tatu _tatu;
    private readonly CapturaService _capturaService;

    [ObservableProperty]
    private static Captura captura = new();

    public ObservableCollection<ParametroFisiologico> ParametrosFisiologicos { get; private set; }


    // Construtor da classe para criação de uma nova captura
    public CadastroCapturaViewModel(Tatu tatu, CapturaService capturaService)
    {
        _tatu = tatu;
        _capturaService = capturaService;
        InicializaParametrosFisiologicos();
        AdicionaParametrosFisiologicos();
    }

    // Construtor da classe para edição de uma captura já existente
    public CadastroCapturaViewModel(Tatu tatu, Captura captura, CapturaService capturaService)
    {
        _tatu = tatu;
        _capturaService = capturaService;
        Captura = captura;
        InicializaParametrosFisiologicos();
    }

    public void InicializaParametrosFisiologicos()
    {
        ParametrosFisiologicos = new();

        if (Captura.FichaAnestesica.ParametrosFisiologicos.Count != 0)
        {
            foreach (var parametro in Captura.FichaAnestesica.ParametrosFisiologicos)
            {
                ParametrosFisiologicos.Add(parametro);
            }
        }
    }

    private async void MostraMensagemLimiteDeParametros()
    {
        var toast = Toast.Make("Limite de 20 parâmetros atingido!", ToastDuration.Short, 14);
        await toast.Show();
    }

    // ================================= COMANDOS ===============================================

    [RelayCommand]
    private void AdicionaParametrosFisiologicos()
    {
        if (ParametrosFisiologicos.Count == 10)
        {
            MostraMensagemLimiteDeParametros();
            return;
        }

        ParametrosFisiologicos.Add(new ParametroFisiologico());
    }

    [RelayCommand]
    private async Task SalvaCapturaNoBanco()
    {
        Captura.FichaAnestesica.ParametrosFisiologicos = ParametrosFisiologicos.ToList();

        if (Captura.Id == 0)
        {
            await _capturaService.SalvaCaptura(Captura, _tatu);
        }
        else
        {
            await _capturaService.AtualizaCaptura(Captura);
        }

        Captura = new Captura();
        await Shell.Current.Navigation.PopModalAsync(true);
    }

    [RelayCommand]
    private async Task Voltar()
    {
        await Shell.Current.Navigation.PopModalAsync(true);
    }
}
