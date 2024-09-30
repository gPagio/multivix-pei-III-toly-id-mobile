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
    private TatuModel _tatu;
    public static CapturaModel Captura { get; set; } = new();

    // Construtor da classe para criação de uma nova captura
    public CadastroCapturaViewModel(TatuModel tatu)
    {
        _tatu = tatu;
        InicializaListasECampos();
        AdicionaParametrosFisiologicos();
    }

    // Construtor da classe para edição de uma captura já existente
    public CadastroCapturaViewModel(TatuModel tatu, CapturaModel captura)
    {
        _tatu = tatu;
        Captura = captura;
        InicializaListasECampos();
    }

    public List<CampoCadastroModel> DadosGerais { get; private set; }
    public List<CampoCadastroModel> Biometria { get; private set; }
    public List<CampoCadastroModel> Amostras { get; private set; }
    public CampoCadastroModel Outros { get; private set; }
    public List<CampoCadastroModel> FichaAnestesica { get; private set; }
    public ObservableCollection<ParametroFisiologicoModel> ParametrosFisiologicos { get; private set; }

    // ================================= COMANDOS ===============================================

    [RelayCommand]
    private void AdicionaParametrosFisiologicos()
    {
        if(ParametrosFisiologicos.Count == 10)
        {
            MostraMensagemLimiteDeParametros();
            return;
        }

        ParametrosFisiologicos.Add(new ParametroFisiologicoModel());
    }

    [RelayCommand] 
    private async Task SalvaCapturaNoBanco()
    {
        Captura.FichaAnestesica.ParametrosFisiologicos = ParametrosFisiologicos.ToList();
        Captura.DadosGerais.DataDeCaptura = Captura.DadosGerais.DataDeCaptura.Date;

        if (Captura.Id == 0)
        {
            await BaseDatabaseService.SalvaCaptura(Captura, _tatu);
        }
        else
        {
            await BaseDatabaseService.AtualizaCaptura(Captura);    
        }

        Captura = new CapturaModel();
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
        DadosGerais = new List<CampoCadastroModel>
        {
            new CampoCadastroModel("Nº Identificação", UiFactory.CriaEntryComTecladoNumerico(Captura.DadosGerais, nameof(Captura.DadosGerais.NumeroIdentificacao))),
            new CampoCadastroModel("Local De Captura", UiFactory.CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.LocalDeCaptura))),
            new CampoCadastroModel("Equipe Responsável", UiFactory.CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.EquipeResponsavel))),
            new CampoCadastroModel("Instituição", UiFactory.CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.Instituicao))),
            new CampoCadastroModel("Peso", UiFactory.CriaEntryComTecladoNumerico(Captura.DadosGerais, nameof(Captura.DadosGerais.Peso))),
            new CampoCadastroModel("Data De Captura", UiFactory.CriaDatePicker(Captura.DadosGerais, nameof(Captura.DadosGerais.DataDeCaptura))),
            new CampoCadastroModel("Horário De Captura", UiFactory.CriaTimePicker(Captura.DadosGerais, nameof(Captura.DadosGerais.HorarioDeCaptura))),
            new CampoCadastroModel("Contato do Responsável", UiFactory.CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.ContatoDoResponsavel))),
            new CampoCadastroModel("Observações", UiFactory.CriaEditor(Captura.DadosGerais, nameof(Captura.DadosGerais.Observacoes)))
        };

        FichaAnestesica = new List<CampoCadastroModel>
        {
            new CampoCadastroModel("Tipo De Anestésico/Dose", UiFactory.CriaEntryComTecladoNormal(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.TipoAnestesicoOuDose))),
            new CampoCadastroModel("Via De Administração", UiFactory.CriaEntryComTecladoNormal(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.ViaDeAdministracao))),
            new CampoCadastroModel("Aplicação", UiFactory.CriaTimePicker(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.Aplicacao))),
            new CampoCadastroModel("Indução", UiFactory.CriaTimePicker(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.Inducao))),
            new CampoCadastroModel("Retorno", UiFactory.CriaTimePicker(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.Retorno)))
        };

        Biometria = new List<CampoCadastroModel>
        {
            new CampoCadastroModel("Comprimento Total", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoTotal))),
            new CampoCadastroModel("Comprimento Da Cabeça", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDaCabeca))),
            new CampoCadastroModel("Largura Da Cabeça", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraDaCabeca))),
            new CampoCadastroModel("Padrão Escudo Cefálico", UiFactory.CriaEntryComTecladoNormal(Captura.Biometria, nameof(Captura.Biometria.PadraoEscudoCefalico))),
            new CampoCadastroModel("Comprimento Escudo Cefálico", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoEscudoCefalico))),
            new CampoCadastroModel("Largura Escudo Cefálico", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraEscudoCefalico))),
            new CampoCadastroModel("Largura Inter-Orbital", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraInterOrbital))),
            new CampoCadastroModel("Comprimento Da Orelha", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDaOrelha))),
            new CampoCadastroModel("Comprimento Da Cauda", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDaCauda))),
            new CampoCadastroModel("Largura Da Cauda", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraDaCauda))),
            new CampoCadastroModel("Comprimento Escudo Escapular", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoEscudoEscapular))),
            new CampoCadastroModel("Semicircunferência Escudo Escapular", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.SemicircunferenciaEscudoEscapular))),
            new CampoCadastroModel("Comprimento Escudo Pélvico", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoEscudoPelvico))),
            new CampoCadastroModel("Semicircunferência Escudo Pélvico", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.SemicircunferenciaEscudoPelvico))),
            new CampoCadastroModel("Largura Na 2ª Cinta", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraNaSegundaCinta))),
            new CampoCadastroModel("Número De Cintas", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.NumeroDeCintas))),
            new CampoCadastroModel("Comprimento Mão Sem Unha", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoMaoSemUnha))),
            new CampoCadastroModel("Comprimento Unha Da Mão", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoUnhaDaMao))),
            new CampoCadastroModel("Comprimento Pé Sem Unha", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoPeSemUnha))),
            new CampoCadastroModel("Comprimento Unha Do Pé", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoUnhaDoPe))),
            new CampoCadastroModel("Comprimento Do Pênis", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDoPenis))),
            new CampoCadastroModel("Largura Base Do Pênis", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraBasePenis))),
            new CampoCadastroModel("Comprimento Do Clitóris", UiFactory.CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDoClitoris)))
        };

        Amostras = new List<CampoCadastroModel>
        {
            new CampoCadastroModel("Sangue", UiFactory.CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Sangue))),
            new CampoCadastroModel("Fezes", UiFactory.CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Fezes))),
            new CampoCadastroModel("Pelo", UiFactory.CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Pelo))),
            new CampoCadastroModel("Ectoparasitos", UiFactory.CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Ectoparasitos))),
            new CampoCadastroModel("Swab", UiFactory.CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Swab))),
            new CampoCadastroModel("Local", UiFactory.CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Local)))
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
