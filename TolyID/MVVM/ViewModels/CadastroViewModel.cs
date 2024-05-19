using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TolyID.MVVM.Models;
//using System.Diagnostics;

namespace TolyID.MVVM.ViewModels;

public partial class CadastroViewModel
{
    // ================================= DADOS GERAIS ===============================================
    public ObservableCollection<CampoCadastroModel> DadosGerais { get; } =
    [
        new CampoCadastroModel("ID ANIMAL", CriaEntryComTecladoNormal()),
        new CampoCadastroModel("Nº IDENTIFICAÇÃO", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("LOCAL DE CAPTURA", CriaEntryComTecladoNormal()),
        new CampoCadastroModel("EQUIPE RESPONSÁVEL", CriaEntryComTecladoNormal()),
        new CampoCadastroModel("INSTITUIÇÃO", CriaEntryComTecladoNormal()),
        new CampoCadastroModel("PESO", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("N° MICROCHIP", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("DATA DE CAPTURA", new DatePicker()),
        new CampoCadastroModel("HORÁRIO DE CAPTURA", new TimePicker()),
        new CampoCadastroModel("CONTATO DO RESPONSÁVEL", CriaEntryComTecladoNormal()),
        new CampoCadastroModel("OBSERVAÇÕES", CriaEntryComTecladoNormal())
    ];

    // ================================= BIOMETRIA ===============================================
    public ObservableCollection<CampoCadastroModel> Biometria { get; } =
    [
        new CampoCadastroModel("COMPRIMENTO TOTAL", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("COMPRIMENTO DA CABEÇA", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("LARGURA DA CABEÇA", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("PADRÃO ESCUDO CEFÁLICO", CriaEntryComTecladoNormal()),
        new CampoCadastroModel("COMPRIMENTO ESCUDO CEFÁLICO", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("LARGURA ESCUDO CEFÁLICO", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("LARGURA INTER-ORBITAL", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("COMPRIMENTO DA ORELHA", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("COMPRIMENTO DA CAUDA", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("LARGURA DA CAUDA", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("COMPRIMENTO ESCUDO ESCAPULAR", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("SEMICIRCUNFERÊNCIA ESCUDO ESCAPULAR", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("COMPRIMENTO ESCUDO PÉLVICO", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("SEMICIRCUNFERÊNCIA ESCUDO PÉLVICO", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("LARGURA NA 2ª CINTA", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("NÚMERO DE CINTAS", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("COMPRIMENTO MÃO SEM UNHA", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("COMPRIMENTO UNHA DA MÃO", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("COMPRIMENTO PÉ SEM UNHA", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("COMPRIMENTO UNHA DO PÉ", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("COMPRIMENTO DO PÊNIS", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("LARGURA BASE DO PÊNIS", CriaEntryComTecladoNumerico()),
        new CampoCadastroModel("COMPRIMENTO DO CLITÓRIS", CriaEntryComTecladoNumerico())
    ];

    // ================================= AMOSTRAS ===============================================
    public ObservableCollection<CampoCadastroModel> AmostrasColunaZero { get; } =
    [
        new CampoCadastroModel("SANGUE", new CheckBox()),
        new CampoCadastroModel("FEZES", new CheckBox()),
        new CampoCadastroModel("PELO", new CheckBox())
    ];

    public ObservableCollection<CampoCadastroModel> AmostrasColunaUm { get; } =
    [
        new CampoCadastroModel("ECTOPARASITOS", new CheckBox()),
        new CampoCadastroModel("SWAB", new CheckBox()),
        new CampoCadastroModel("LOCAL", new CheckBox())
    ];

    public CampoCadastroModel Outros { get; } = new("OUTROS", CriaEntryComTecladoNormal());

    // ================================= COMANDOS ===============================================

    [RelayCommand]
    void CriaTatuCapturado()
    {
        TatuCapturadoModel tatu = new();

        foreach (CampoCadastroModel campo in DadosGerais)
        {
            switch (campo.Nome)
            {
                case "ID ANIMAL":
                    tatu.DadosGerais.IdAnimal = campo.Valor.ToString();
                    break;
                case "N° IDENTIFICAÇÃO":
                    tatu.DadosGerais.NumeroIdentificacao = Convert.ToInt32(campo.Valor);
                    break;
                case "LOCAL DE CAPTURA":
                    tatu.DadosGerais.LocalDeCaptura = campo.Valor.ToString();
                    break;
                case "EQUIPE RESPONSÁVEL":
                    tatu.DadosGerais.EquipeResponsavel = campo.Valor.ToString();
                    break;
                case "INSTITUIÇÃO":
                    tatu.DadosGerais.Instituicao = campo.Valor.ToString();
                    break;
                case "PESO":
                    tatu.DadosGerais.Peso = Convert.ToDouble(campo.Valor);
                    break;
                case "N° MICROCHIP":
                    tatu.DadosGerais.NumeroMicrochip = Convert.ToInt32(campo.Valor);
                    break;
                case "DATA DE CAPTURA":
                    tatu.DadosGerais.DataDeCaptura = Convert.ToDateTime(campo.Valor);
                    break;
                case "HORÁRIO DE CAPTURA":
                    tatu.DadosGerais.HorarioDeCaptura = TimeSpan.Parse(campo.Valor.ToString());
                    break;
                case "CONTATO DO RESPONSÁVEL":
                    tatu.DadosGerais.ContatoDoResponsavel = campo.Valor.ToString();
                    break;
                case "OBSERVAÇÕES":
                    tatu.DadosGerais.Observacoes = campo.Valor.ToString();
                    break;
            }
        }

        foreach (CampoCadastroModel campo in Biometria)
        {
            switch (campo.Nome)
            {

            }
        }

        foreach (CampoCadastroModel campo in AmostrasColunaZero)
        {

        }

        foreach (CampoCadastroModel campo in AmostrasColunaUm)
        {

        }

        tatu.Amostras.Outros = Outros.Valor.ToString();

        Debug.WriteLine($"%&%&%& {tatu.Amostras.Outros} %&%&%&%");
    }

    // ================================= MÉTODOS ===============================================

    private static Entry CriaEntryComTecladoNormal()
    {
        return new Entry() { Keyboard = Keyboard.Default, ReturnType = ReturnType.Next };
    }

    private static Entry CriaEntryComTecladoNumerico()
    {
        return new Entry() { Keyboard = Keyboard.Numeric, ReturnType = ReturnType.Next };
    }

    //public void Teste()
    //{
    //    Debug.WriteLine($"%&%&%&%&% {DadosGerais[8].Valor} %&%&%&%&%&  ");
    //}
}
