using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
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
    async void CriaTatuCapturado()
    {   
        TatuCapturadoModel tatu = new();

        //foreach (CampoCadastroModel campo in DadosGerais)
        //{
        //    if (campo.Valor == null || string.IsNullOrEmpty(campo.Valor.ToString()))
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Campo obrigatório", $"O campo {campo.Nome} deve ser preenchido", "OK");
        //        return;
        //    }

        //    switch (campo.Nome)
        //    {
        //        case "ID ANIMAL":
        //            tatu.DadosGerais.IdAnimal = campo.Valor.ToString();
        //            break;
        //        case "N° IDENTIFICAÇÃO":
        //            tatu.DadosGerais.NumeroIdentificacao = Convert.ToInt32(campo.Valor);
        //            break;
        //        case "LOCAL DE CAPTURA":
        //            tatu.DadosGerais.LocalDeCaptura = campo.Valor.ToString();
        //            break;
        //        case "EQUIPE RESPONSÁVEL":
        //            tatu.DadosGerais.EquipeResponsavel = campo.Valor.ToString();
        //            break;
        //        case "INSTITUIÇÃO":
        //            tatu.DadosGerais.Instituicao = campo.Valor.ToString();
        //            break;
        //        case "PESO":
        //            tatu.DadosGerais.Peso = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "N° MICROCHIP":
        //            tatu.DadosGerais.NumeroMicrochip = Convert.ToInt32(campo.Valor);
        //            break;
        //        case "DATA DE CAPTURA":
        //            tatu.DadosGerais.DataDeCaptura = Convert.ToDateTime(campo.Valor);
        //            break;
        //        case "HORÁRIO DE CAPTURA":
        //            tatu.DadosGerais.HorarioDeCaptura = TimeSpan.Parse(campo.Valor.ToString());
        //            break;
        //        case "CONTATO DO RESPONSÁVEL":
        //            tatu.DadosGerais.ContatoDoResponsavel = campo.Valor.ToString();
        //            break;
        //        case "OBSERVAÇÕES":
        //            tatu.DadosGerais.Observacoes = campo.Valor.ToString();
        //            break;
        //    }
        //}

        //foreach (CampoCadastroModel campo in Biometria)
        //{
        //    if (campo.Valor == null || string.IsNullOrEmpty(campo.Valor.ToString()))
        //    {
        //        await Application.Current.MainPage.DisplayAlert("Campo obrigatório", $"O campo {campo.Nome} deve ser preenchido", "OK");
        //        return;
        //    }

        //    switch (campo.Nome)
        //    {
        //        case "COMPRIMENTO TOTAL":
        //            tatu.Biometria.ComprimentoTotal = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "COMPRIMENTO DA CABEÇA":
        //            tatu.Biometria.ComprimentoDaCabeca = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "LARGURA DA CABEÇA":
        //            tatu.Biometria.LarguraDaCabeca = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "PADRÃO ESCUDO CEFÁLICO":
        //            tatu.Biometria.PadraoEscudoCefalico = campo.Valor.ToString()!;
        //            break;
        //        case "COMPRIMENTO ESCUDO CEFÁLICO":
        //            tatu.Biometria.ComprimentoEscudoCefalico = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "LARGURA ESCUDO CEFÁLICO":
        //            tatu.Biometria.LarguraEscudoCefalico = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "LARGURA INTER-ORBITAL":
        //            tatu.Biometria.LarguraInterOrbital = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "COMPRIMENTO DA ORELHA":
        //            tatu.Biometria.ComprimentoDaOrelha = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "COMPRIMENTO DA CAUDA":
        //            tatu.Biometria.ComprimentoDaCauda = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "LARGURA DA CAUDA":
        //            tatu.Biometria.LarguraDaCauda = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "COMPRIMENTO ESCUDO ESCAPULAR":
        //            tatu.Biometria.ComprimentoEscudoEscapular = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "SEMICIRCUNFERÊNCIA ESCUDO ESCAPULAR":
        //            tatu.Biometria.SemicircunferenciaEscudoEscapular = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "COMPRIMENTO ESCUDO PÉLVICO":
        //            tatu.Biometria.ComprimentoEscudoPelvico = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "SEMICIRCUNFERÊNCIA ESCUDO PÉLVICO":
        //            tatu.Biometria.SemicircunferenciaEscudoPelvico = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "LARGURA NA 2ª CINTA":
        //            tatu.Biometria.LarguraNaSegundaCinta = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "NÚMERO DE CINTAS":
        //            tatu.Biometria.NumeroDeCintas = Convert.ToInt32(campo.Valor);
        //            break;
        //        case "COMPRIMENTO MÃO SEM UNHA":
        //            tatu.Biometria.ComprimentoMaoSemUnha = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "COMPRIMENTO UNHA DA MÃO":
        //            tatu.Biometria.ComprimentoUnhaDaMao = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "COMPRIMENTO PÉ SEM UNHA":
        //            tatu.Biometria.ComprimentoPeSemUnha = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "COMPRIMENTO UNHA DO PÉ":
        //            tatu.Biometria.ComprimentoUnhaDoPe = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "COMPRIMENTO DO PÊNIS":
        //            tatu.Biometria.ComprimentoDoPenis = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "LARGURA BASE DO PÊNIS":
        //            tatu.Biometria.LarguraBasePenis = Convert.ToDouble(campo.Valor);
        //            break;
        //        case "COMPRIMENTO DO CLITÓRIS":
        //            tatu.Biometria.ComprimentoDoClitoris = Convert.ToDouble(campo.Valor);
        //            break;
        //    }
        //}

        foreach (CampoCadastroModel campo in AmostrasColunaZero)
        {
            if (campo.Valor == null)
            {
                campo.Valor = false; 
            }

            switch (campo.Nome)
            {
                case "SANGUE":
                    tatu.Amostras.Sangue = Convert.ToBoolean(campo.Valor); 
                    break;
                case "FEZES":
                    tatu.Amostras.Fezes = Convert.ToBoolean(campo.Valor);
                    break;
                case "PELO":
                    tatu.Amostras.Pelo = Convert.ToBoolean(campo.Valor);
                    break;
            }
        }

        foreach (CampoCadastroModel campo in AmostrasColunaUm)
        {
            if (campo.Valor == null)
            {
                campo.Valor = false;
            }

            switch (campo.Nome)
            {
                case "ECTOPARASITOS":
                    tatu.Amostras.Ectoparasitos = Convert.ToBoolean(campo.Valor);
                    break;
                case "SWAB":
                    tatu.Amostras.Swab = Convert.ToBoolean(campo.Valor);
                    break;
                case "LOCAL":
                    tatu.Amostras.Local = Convert.ToBoolean(campo.Valor);
                    break;
            }
        }

        if (Outros.Valor == null) 
        {
            tatu.Amostras.Outros = "";
        }
        else
        {
            tatu.Amostras.Outros = Outros.Valor.ToString();
        }
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
