using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TolyID.Helpers;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class CadastroCapturaViewModel
{
    private readonly Tatu _tatu;
    private readonly CapturaService _capturaService;
    public static Captura Captura { get; set; } = new();

    // Construtor da classe para criação de uma nova captura
    public CadastroCapturaViewModel(Tatu tatu, CapturaService capturaService)
    {
        _tatu = tatu;
        _capturaService = capturaService;
        InicializaListasECampos();
        AdicionaParametrosFisiologicos();
    }

    // Construtor da classe para edição de uma captura já existente
    public CadastroCapturaViewModel(Tatu tatu, Captura captura, CapturaService capturaService)
    {
        _tatu = tatu;
        _capturaService = capturaService;
        Captura = captura;
        InicializaListasECampos();
    }

    public List<CampoCadastro> DadosGerais { get; private set; }
    public List<CampoCadastro> Biometria { get; private set; }
    public List<CampoCadastro> Amostras { get; private set; }
    public CampoCadastro Outros { get; private set; }
    public List<CampoCadastro> FichaAnestesica { get; private set; }
    public ObservableCollection<ParametroFisiologico> ParametrosFisiologicos { get; private set; }

    // ================================= COMANDOS ===============================================

    [RelayCommand]
    private async void AdicionaParametrosFisiologicos()
    {
        if(ParametrosFisiologicos.Count == 10)
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
        Captura.DadosGerais.DataDeCaptura = Captura.DadosGerais.DataDeCaptura.Date;

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

    // ================================= MÉTODOS ===============================================

    private async void MostraMensagemLimiteDeParametros()
    {
        var toast = Toast.Make("Limite de 20 parâmetros atingido!", ToastDuration.Short, 14);
        await toast.Show();
    }

    public void InicializaListasECampos()
    {
        DadosGerais = new List<CampoCadastro>
        {
            new CampoCadastro("Nº Identificação", UiFactory.CriaEntryComTecladoNumerico(Captura.DadosGerais, nameof(Captura.DadosGerais.NumeroIdentificacao))),
            new CampoCadastro("Local De Captura", UiFactory.CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.LocalDeCaptura))),
            new CampoCadastro("Equipe Responsável", UiFactory.CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.EquipeResponsavel))),
            new CampoCadastro("Instituição", UiFactory.CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.Instituicao))),
            new CampoCadastro("Peso", UiFactory.CriaEntryComTecladoNumerico(Captura.DadosGerais, nameof(Captura.DadosGerais.Peso))),
            new CampoCadastro("Data De Captura", UiFactory.CriaDatePicker(Captura.DadosGerais, nameof(Captura.DadosGerais.DataDeCaptura))),
            new CampoCadastro("Horário De Captura", UiFactory.CriaTimePicker(Captura.DadosGerais, nameof(Captura.DadosGerais.HorarioDeCaptura))),
            new CampoCadastro("Contato do Responsável", UiFactory.CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.ContatoDoResponsavel))),
            new CampoCadastro("Observações", UiFactory.CriaEditor(Captura.DadosGerais, nameof(Captura.DadosGerais.Observacoes)))
        };

        FichaAnestesica = new List<CampoCadastro>
        {
            new CampoCadastro("Tipo De Anestésico/Dose", UiFactory.CriaEntryComTecladoNormal(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.TipoAnestesicoOuDose))),
            new CampoCadastro("Via De Administração", UiFactory.CriaEntryComTecladoNormal(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.ViaDeAdministracao))),
            new CampoCadastro("Aplicação", UiFactory.CriaTimePicker(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.Aplicacao))),
            new CampoCadastro("Indução", UiFactory.CriaTimePicker(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.Inducao))),
            new CampoCadastro("Retorno", UiFactory.CriaTimePicker(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.Retorno)))
        };

        Biometria = new List<CampoCadastro>
        {
            new CampoCadastro("Comprimento Total", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoTotal))),
            new CampoCadastro("Comprimento Da Cabeça", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDaCabeca))),
            new CampoCadastro("Largura Da Cabeça", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraDaCabeca))),
            new CampoCadastro("Padrão Escudo Cefálico", UiFactory.CriaEntryComTecladoNormal(Captura.Biometria, nameof(Captura.Biometria.PadraoEscudoCefalico))),
            new CampoCadastro("Comprimento Escudo Cefálico", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoEscudoCefalico))),
            new CampoCadastro("Largura Escudo Cefálico", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraEscudoCefalico))),
            new CampoCadastro("Largura Inter-Orbital", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraInterOrbital))),
            new CampoCadastro("Comprimento Da Orelha", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDaOrelha))),
            new CampoCadastro("Comprimento Da Cauda", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDaCauda))),
            new CampoCadastro("Largura Da Cauda", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraDaCauda))),
            new CampoCadastro("Comprimento Escudo Escapular", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoEscudoEscapular))),
            new CampoCadastro("Semicircunferência Escudo Escapular", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.SemicircunferenciaEscudoEscapular))),
            new CampoCadastro("Comprimento Escudo Pélvico", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoEscudoPelvico))),
            new CampoCadastro("Semicircunferência Escudo Pélvico", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.SemicircunferenciaEscudoPelvico))),
            new CampoCadastro("Largura Na 2ª Cinta", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraNaSegundaCinta))),
            new CampoCadastro("Número De Cintas", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.NumeroDeCintas))),
            new CampoCadastro("Comprimento Mão Sem Unha", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoMaoSemUnha))),
            new CampoCadastro("Comprimento Unha Da Mão", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoUnhaDaMao))),
            new CampoCadastro("Comprimento Pé Sem Unha", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoPeSemUnha))),
            new CampoCadastro("Comprimento Unha Do Pé", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoUnhaDoPe))),
            new CampoCadastro("Comprimento Do Pênis", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDoPenis))),
            new CampoCadastro("Largura Base Do Pênis", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraBasePenis))),
            new CampoCadastro("Comprimento Do Clitóris", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDoClitoris)))
        };

        Amostras = new List<CampoCadastro>
        {
            new CampoCadastro("Sangue", UiFactory.CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Sangue))),
            new CampoCadastro("Fezes", UiFactory.CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Fezes))),
            new CampoCadastro("Pelo", UiFactory.CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Pelo))),
            new CampoCadastro("Ectoparasitos", UiFactory.CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Ectoparasitos))),
            new CampoCadastro("Swab", UiFactory.CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Swab))),
            new CampoCadastro("Local", UiFactory.CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Local)))
        };

        Outros = new("Outros", UiFactory.CriaEditor(Captura.Amostras, nameof(Captura.Amostras.Outros)));

        ParametrosFisiologicos = new();

        if (Captura.FichaAnestesica.ParametrosFisiologicos.Count != 0)
        {
            foreach (var parametro in Captura.FichaAnestesica.ParametrosFisiologicos)
            {
                ParametrosFisiologicos.Add(parametro);
            }
        }
    }
}
