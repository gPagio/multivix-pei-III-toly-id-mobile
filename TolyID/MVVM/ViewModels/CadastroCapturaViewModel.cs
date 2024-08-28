using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        //AdicionaParametrosFisiologicos();
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
    async Task SalvaCapturaNoBanco()
    {
        Captura.FichaAnestesica.ParametrosFisiologicos = ParametrosFisiologicos.ToList();
        Captura.DadosGerais.DataDeCaptura = Captura.DadosGerais.DataDeCaptura.Date;

        if (Captura.Id == 0)
        {
            await BancoDeDadosService.SalvaCapturaAsync(Captura, _tatu);
        }
        else
        {
            await BancoDeDadosService.AtualizaCapturaAsync(Captura);    
        }

        Captura = new CapturaModel();
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
            new CampoCadastroModel("Nº Identificação", CriaEntryComTecladoNumerico(Captura.DadosGerais, nameof(Captura.DadosGerais.NumeroIdentificacao))),
            new CampoCadastroModel("Local De Captura", CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.LocalDeCaptura))),
            new CampoCadastroModel("Equipe Responsável", CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.EquipeResponsavel))),
            new CampoCadastroModel("Instituição", CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.Instituicao))),
            new CampoCadastroModel("Peso", CriaEntryComTecladoNumerico(Captura.DadosGerais, nameof(Captura.DadosGerais.Peso))),
            new CampoCadastroModel("Data De Captura", CriaDatePicker(Captura.DadosGerais, nameof(Captura.DadosGerais.DataDeCaptura))),
            new CampoCadastroModel("Horário De Captura", CriaTimePicker(Captura.DadosGerais, nameof(Captura.DadosGerais.HorarioDeCaptura))),
            new CampoCadastroModel("Contato do Responsável", CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.ContatoDoResponsavel))),
            new CampoCadastroModel("Observações", CriaEditor(Captura.DadosGerais, nameof(Captura.DadosGerais.Observacoes)))
        };

        FichaAnestesica = new List<CampoCadastroModel>
        {
            new CampoCadastroModel("Tipo De Anestésico/Dose", CriaEntryComTecladoNormal(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.TipoAnestesicoOuDose))),
            new CampoCadastroModel("Via De Administração", CriaEntryComTecladoNormal(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.ViaDeAdministracao))),
            new CampoCadastroModel("Aplicação", CriaTimePicker(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.Aplicacao))),
            new CampoCadastroModel("Indução", CriaTimePicker(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.Inducao))),
            new CampoCadastroModel("Retorno", CriaTimePicker(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.Retorno)))
        };

        Biometria = new List<CampoCadastroModel>
        {
            new CampoCadastroModel("Comprimento Total", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoTotal))),
            new CampoCadastroModel("Comprimento Da Cabeça", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDaCabeca))),
            new CampoCadastroModel("Largura Da Cabeça", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraDaCabeca))),
            new CampoCadastroModel("Padrão Escudo Cefálico", CriaEntryComTecladoNormal(Captura.Biometria, nameof(Captura.Biometria.PadraoEscudoCefalico))),
            new CampoCadastroModel("Comprimento Escudo Cefálico", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoEscudoCefalico))),
            new CampoCadastroModel("Largura Escudo Cefálico", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraEscudoCefalico))),
            new CampoCadastroModel("Largura Inter-Orbital", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraInterOrbital))),
            new CampoCadastroModel("Comprimento Da Orelha", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDaOrelha))),
            new CampoCadastroModel("Comprimento Da Cauda", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDaCauda))),
            new CampoCadastroModel("Largura Da Cauda", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraDaCauda))),
            new CampoCadastroModel("Comprimento Escudo Escapular", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoEscudoEscapular))),
            new CampoCadastroModel("Semicircunferência Escudo Escapular", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.SemicircunferenciaEscudoEscapular))),
            new CampoCadastroModel("Comprimento Escudo Pélvico", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoEscudoPelvico))),
            new CampoCadastroModel("Semicircunferência Escudo Pélvico", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.SemicircunferenciaEscudoPelvico))),
            new CampoCadastroModel("Largura Na 2ª Cinta", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraNaSegundaCinta))),
            new CampoCadastroModel("Número De Cintas", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.NumeroDeCintas))),
            new CampoCadastroModel("Comprimento Mão Sem Unha", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoMaoSemUnha))),
            new CampoCadastroModel("Comprimento Unha Da Mão", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoUnhaDaMao))),
            new CampoCadastroModel("Comprimento Pé Sem Unha", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoPeSemUnha))),
            new CampoCadastroModel("Comprimento Unha Do Pé", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoUnhaDoPe))),
            new CampoCadastroModel("Comprimento Do Pênis", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDoPenis))),
            new CampoCadastroModel("Largura Base Do Pênis", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraBasePenis))),
            new CampoCadastroModel("Comprimento Do Clitóris", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDoClitoris)))
        };

        Amostras = new List<CampoCadastroModel>
        {
            new CampoCadastroModel("Sangue", CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Sangue))),
            new CampoCadastroModel("Fezes", CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Fezes))),
            new CampoCadastroModel("Pelo", CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Pelo))),
            new CampoCadastroModel("Ectoparasitos", CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Ectoparasitos))),
            new CampoCadastroModel("Swab", CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Swab))),
            new CampoCadastroModel("Local", CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Local)))
        };

        Outros = new("Outros", CriaEditor(Captura.Amostras, nameof(Captura.Amostras.Outros)));

        ParametrosFisiologicos = new();

        if (Captura.FichaAnestesica.ParametrosFisiologicos.Count != 0)
        {
            foreach (var parametro in Captura.FichaAnestesica.ParametrosFisiologicos)
            {
                ParametrosFisiologicos.Add(parametro);
            }
        }
    }

    private static Entry CriaEntryComTecladoNormal(object bindingContext, string caminhoDeBinding)
    {
        Entry entry = new Entry
        {
            Keyboard = Keyboard.Default,
            ReturnType = ReturnType.Next,
            TextColor = Color.FromArgb("#000000"),
            Placeholder = "Digite",
            BindingContext = bindingContext
        };

        entry.SetBinding(Entry.TextProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return entry;
    }

    private static Entry CriaEntryComTecladoNumerico(object bindingContext, string caminhoDeBinding)
    {
        Entry entry = new Entry
        {
            Keyboard = Keyboard.Numeric,
            ReturnType = ReturnType.Next,
            TextColor = Color.FromArgb("#000000"),
            BindingContext = bindingContext
        };

        entry.TextChanged += EntryNumericoTextChanged;

        entry.SetBinding(Entry.TextProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return entry;
    }

    // Apaga o número 0 dos Entries numéricos ao digitar um valor. Solução temporária
    private static void EntryNumericoTextChanged(object sender, TextChangedEventArgs e)
    {
        Entry entry = (Entry)sender;

        if (e.NewTextValue != string.Empty && e.OldTextValue == 0.ToString() && Convert.ToDouble(entry.Text) % 10 == 0)
        {
            double numeroDigitado = Convert.ToDouble(entry.Text);
            numeroDigitado /= 10;
            entry.Text = numeroDigitado.ToString();
        }
    }

    private static Editor CriaEditor(object bindingContext, string caminhoDeBinding)
    {
        Editor editor = new();
        editor.BindingContext = bindingContext;
        editor.TextColor = Color.FromArgb("#000000");
        editor.Placeholder = "Digite";
        editor.SetBinding(Editor.TextProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return editor;
    }

    private static DatePicker CriaDatePicker (object bindingContext, string caminhoDeBinding)
    {
        DatePicker datePicker = new();
        datePicker.BindingContext = bindingContext;
        datePicker.TextColor = Color.FromArgb("#000000");
        datePicker.SetBinding(DatePicker.DateProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return datePicker;
    }

    private static TimePicker CriaTimePicker(object bindingContext, string caminhoDeBinding)
    {
        TimePicker timePicker = new();
        timePicker.BindingContext = bindingContext;
        timePicker.TextColor = Color.FromArgb("#000000");
        timePicker.SetBinding(TimePicker.TimeProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return timePicker;
    }

    private static CheckBox CriaCheckBox (object bindingContext, string caminhoDeBinding)
    {
        CheckBox checkBox = new();
        checkBox.BindingContext = bindingContext;
        checkBox.SetBinding(CheckBox.IsCheckedProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return checkBox;
    }
}
