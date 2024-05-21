using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TolyID.MVVM.Models;

namespace TolyID.MVVM.ViewModels;

public partial class CadastroViewModel
{
    public static TatuCapturadoModel Tatu { get; set; } = new();
    
    // ================================= DADOS GERAIS ===============================================
    public ObservableCollection<CampoCadastroModel> DadosGerais { get; } =
    [
        new CampoCadastroModel("ID ANIMAL", CriaEntryComTecladoNormal(Tatu.DadosGerais, nameof(Tatu.DadosGerais.IdAnimal))),
        new CampoCadastroModel("Nº IDENTIFICAÇÃO", CriaEntryComTecladoNumerico(Tatu.DadosGerais, nameof(Tatu.DadosGerais.NumeroIdentificacao))),
        new CampoCadastroModel("LOCAL DE CAPTURA", CriaEntryComTecladoNormal(Tatu.DadosGerais, nameof(Tatu.DadosGerais.LocalDeCaptura))),
        new CampoCadastroModel("EQUIPE RESPONSÁVEL", CriaEntryComTecladoNormal(Tatu.DadosGerais, nameof(Tatu.DadosGerais.EquipeResponsavel))),
        new CampoCadastroModel("INSTITUIÇÃO", CriaEntryComTecladoNormal(Tatu.DadosGerais, nameof(Tatu.DadosGerais.Instituicao))),
        new CampoCadastroModel("PESO", CriaEntryComTecladoNumerico(Tatu.DadosGerais, nameof(Tatu.DadosGerais.Peso))),
        new CampoCadastroModel("N° MICROCHIP", CriaEntryComTecladoNumerico(Tatu.DadosGerais, nameof(Tatu.DadosGerais.NumeroMicrochip))),
        new CampoCadastroModel("DATA DE CAPTURA", CriaDatePicker(Tatu.DadosGerais, nameof(Tatu.DadosGerais.DataDeCaptura))),
        new CampoCadastroModel("HORÁRIO DE CAPTURA", CriaTimePicker(Tatu.DadosGerais, nameof(Tatu.DadosGerais.HorarioDeCaptura))),
        new CampoCadastroModel("CONTATO DO RESPONSÁVEL", CriaEntryComTecladoNormal(Tatu.DadosGerais, nameof(Tatu.DadosGerais.ContatoDoResponsavel))),
        new CampoCadastroModel("OBSERVAÇÕES", CriaEntryComTecladoNormal(Tatu.DadosGerais, nameof(Tatu.DadosGerais.Observacoes)))
    ];

    // ================================= BIOMETRIA ===============================================
    public ObservableCollection<CampoCadastroModel> Biometria { get; } =
    [
        new CampoCadastroModel("COMPRIMENTO TOTAL", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.ComprimentoTotal))),
        new CampoCadastroModel("COMPRIMENTO DA CABEÇA", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.ComprimentoDaCabeca))),
        new CampoCadastroModel("LARGURA DA CABEÇA", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.LarguraDaCabeca))),
        new CampoCadastroModel("PADRÃO ESCUDO CEFÁLICO", CriaEntryComTecladoNormal(Tatu.Biometria, nameof(Tatu.Biometria.PadraoEscudoCefalico))),
        new CampoCadastroModel("COMPRIMENTO ESCUDO CEFÁLICO", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.ComprimentoEscudoCefalico))),
        new CampoCadastroModel("LARGURA ESCUDO CEFÁLICO", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.LarguraEscudoCefalico))),
        new CampoCadastroModel("LARGURA INTER-ORBITAL", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.LarguraInterOrbital))),
        new CampoCadastroModel("COMPRIMENTO DA ORELHA", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.ComprimentoDaOrelha))),
        new CampoCadastroModel("COMPRIMENTO DA CAUDA", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.ComprimentoDaCauda))),
        new CampoCadastroModel("LARGURA DA CAUDA", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.LarguraDaCauda))),
        new CampoCadastroModel("COMPRIMENTO ESCUDO ESCAPULAR", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.ComprimentoEscudoEscapular))),
        new CampoCadastroModel("SEMICIRCUNFERÊNCIA ESCUDO ESCAPULAR", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.SemicircunferenciaEscudoEscapular))),
        new CampoCadastroModel("COMPRIMENTO ESCUDO PÉLVICO", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.ComprimentoEscudoPelvico))),
        new CampoCadastroModel("SEMICIRCUNFERÊNCIA ESCUDO PÉLVICO", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.SemicircunferenciaEscudoPelvico))),
        new CampoCadastroModel("LARGURA NA 2ª CINTA", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.LarguraNaSegundaCinta))),
        new CampoCadastroModel("NÚMERO DE CINTAS", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.NumeroDeCintas))),
        new CampoCadastroModel("COMPRIMENTO MÃO SEM UNHA", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.ComprimentoMaoSemUnha))),
        new CampoCadastroModel("COMPRIMENTO UNHA DA MÃO", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.ComprimentoUnhaDaMao))),
        new CampoCadastroModel("COMPRIMENTO PÉ SEM UNHA", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.ComprimentoPeSemUnha))),
        new CampoCadastroModel("COMPRIMENTO UNHA DO PÉ", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.ComprimentoUnhaDoPe))),
        new CampoCadastroModel("COMPRIMENTO DO PÊNIS", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.ComprimentoDoPenis))),
        new CampoCadastroModel("LARGURA BASE DO PÊNIS", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.LarguraBasePenis))),
        new CampoCadastroModel("COMPRIMENTO DO CLITÓRIS", CriaEntryComTecladoNumerico(Tatu.Biometria, nameof(Tatu.Biometria.ComprimentoDoClitoris)))
    ];

    // ================================= AMOSTRAS ===============================================
    public ObservableCollection<CampoCadastroModel> AmostrasColunaZero { get; } =
    [
        new CampoCadastroModel("SANGUE", CriaCheckBox(Tatu.Amostras, nameof(Tatu.Amostras.Sangue))),
        new CampoCadastroModel("FEZES", CriaCheckBox(Tatu.Amostras, nameof(Tatu.Amostras.Fezes))),
        new CampoCadastroModel("PELO", CriaCheckBox(Tatu.Amostras, nameof(Tatu.Amostras.Pelo)))
    ];

    public ObservableCollection<CampoCadastroModel> AmostrasColunaUm { get; } =
    [
        new CampoCadastroModel("ECTOPARASITOS", CriaCheckBox(Tatu.Amostras, nameof(Tatu.Amostras.Ectoparasitos))),
        new CampoCadastroModel("SWAB", CriaCheckBox(Tatu.Amostras, nameof(Tatu.Amostras.Swab))),
        new CampoCadastroModel("LOCAL", CriaCheckBox(Tatu.Amostras, nameof(Tatu.Amostras.Local)))
    ];

    public CampoCadastroModel Outros { get; } = new("OUTROS", CriaEntryComTecladoNormal(Tatu.Amostras, nameof(Tatu.Amostras.Outros)));

    // ================================= COMANDOS ===============================================

    [RelayCommand]
    async void CriaTatuCapturado()
    {   
        TatuCapturadoModel novoTatu = new();

        // Implementar lógica de criação de um novo tatu a partir
        // do tatu estático da classe. Após a criação e armazenamento
        // no banco de dados, deve-se limpar todos os dados do tatu
        // estático.
    }

    // ================================= MÉTODOS ===============================================

    private static Entry CriaEntryComTecladoNormal(object bindingContext, string caminhoDeBinding)
    {
        Entry entry = new Entry
        {
            Keyboard = Keyboard.Default,
            ReturnType = ReturnType.Next
        };

        entry.BindingContext = bindingContext;
        entry.SetBinding(Entry.TextProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));

        return entry;
    }

    private static Entry CriaEntryComTecladoNumerico(object bindingContext, string caminhoDeBinding)
    {
        Entry entry = new Entry
        {
            Keyboard = Keyboard.Numeric,
            ReturnType = ReturnType.Next
        };

        entry.BindingContext = bindingContext;
        entry.SetBinding(Entry.TextProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));

        return entry;
    }

    private static DatePicker CriaDatePicker (object bindingContext, string caminhoDeBinding)
    {
        DatePicker datePicker = new();
        datePicker.BindingContext = bindingContext;
        datePicker.SetBinding(DatePicker.DateProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return datePicker;
    }

    private static TimePicker CriaTimePicker(object bindingContext, string caminhoDeBinding)
    {
        TimePicker timePicker = new();
        timePicker.BindingContext = bindingContext;
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
