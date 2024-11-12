using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TolyID.MVVM.Models;
using TolyID.MVVM.Views.CadastroDeCaptura;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class CadastroCapturaViewModel : ObservableObject
{
    private readonly CapturaService _capturaService;

    [ObservableProperty]
    private Tatu _tatu;

    [ObservableProperty]
    private static Captura captura = new();

    // Campos de data e hora separados, serão juntados em um só campo de Dados Gerais
    [ObservableProperty]
    private DateTime dataDeCaptura = DateTime.Now;
    [ObservableProperty]
    private TimeSpan horarioDeCaptura = DateTime.Now.TimeOfDay;

    public ObservableCollection<ParametroFisiologico> ParametrosFisiologicos { get; private set; }

    // Indicador de carregamento
    [ObservableProperty]
    private bool estaCarregando = false;

    [ObservableProperty]
    private bool botaoProximoBloqueado = false;

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
        DataDeCaptura = Captura.DadosGerais.DataHoraDeCaptura;
        HorarioDeCaptura = Captura.DadosGerais.DataHoraDeCaptura.TimeOfDay;
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
        EstaCarregando = true;

        Captura.FichaAnestesica.ParametrosFisiologicos = ParametrosFisiologicos.ToList();
        Captura.DadosGerais.DataHoraDeCaptura = DataDeCaptura.Date + HorarioDeCaptura;

        Debug.WriteLine(Captura.Biometria.ComprimentoDoPenis);
        Debug.WriteLine(Captura.Biometria.LarguraBasePenis);
        Debug.WriteLine(Captura.Biometria.ComprimentoDoClitoris);

        if (Captura.Id == 0)
        {
            await _capturaService.SalvaCaptura(Captura, _tatu);
        }
        else
        {
            await _capturaService.AtualizaCaptura(Captura);
        }

        Captura = new Captura();

        //TODO: achar melhor forma de navegar de volta à página de tatu
        await Shell.Current.Navigation.PopAsync(true);
        await Shell.Current.Navigation.PopAsync(true);
        await Shell.Current.Navigation.PopAsync(true);
        await Shell.Current.Navigation.PopAsync(true);

        EstaCarregando = false;
    }

    [RelayCommand]
    private async Task IrParaFichaAnestesica()
    {
        Task.Run(() => AlternaHabilitacaoBotaoProximo());
        await Shell.Current.Navigation.PushAsync(new FichaAnestesicaView(this));
    }

    [RelayCommand]
    private async Task IrParaBiometria()
    {
        Task.Run(() => AlternaHabilitacaoBotaoProximo());
        await Shell.Current.Navigation.PushAsync(new BiometriaView(this));
    }

    [RelayCommand]
    private async Task IrParaAmostras()
    {
        Task.Run(() => AlternaHabilitacaoBotaoProximo());
        await Shell.Current.Navigation.PushAsync(new AmostrasView(this));
    }

    private async Task AlternaHabilitacaoBotaoProximo()
    {
        BotaoProximoBloqueado = true;
        await Task.Delay(2000);
        BotaoProximoBloqueado = false;
    }
}
