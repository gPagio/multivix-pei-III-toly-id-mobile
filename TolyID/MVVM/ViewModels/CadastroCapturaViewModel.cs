﻿using Android.Hardware.Camera2.Params;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TolyID.MVVM.Models;
using TolyID.Services;

namespace TolyID.MVVM.ViewModels;

public partial class CadastroCapturaViewModel
{
    private TatuModel _tatu;
    public static CapturaModel Captura { get; set; } = new();

    public CadastroCapturaViewModel(TatuModel tatu)
    {
        _tatu = tatu;
        AdicionaParametrosFisiologicos();

        DadosGerais = new List<CampoCadastroModel> 
        {
           //new CampoCadastroModel("ID ANIMAL", CriaEntryComTecladoNormal(Tatu.DadosGerais, nameof(Tatu.DadosGerais.IdAnimal))),
            new CampoCadastroModel("Nº IDENTIFICAÇÃO", CriaEntryComTecladoNumerico(Captura.DadosGerais, nameof(Captura.DadosGerais.NumeroIdentificacao))),
            new CampoCadastroModel("LOCAL DE CAPTURA", CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.LocalDeCaptura))),
            new CampoCadastroModel("EQUIPE RESPONSÁVEL", CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.EquipeResponsavel))),
            new CampoCadastroModel("INSTITUIÇÃO", CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.Instituicao))),
            new CampoCadastroModel("PESO", CriaEntryComTecladoNumerico(Captura.DadosGerais, nameof(Captura.DadosGerais.Peso))),
            //new CampoCadastroModel("N° MICROCHIP", CriaEntryComTecladoNumerico(Tatu.DadosGerais, nameof(Tatu.DadosGerais.NumeroMicrochip))),
            new CampoCadastroModel("DATA DE CAPTURA", CriaDatePicker(Captura.DadosGerais, nameof(Captura.DadosGerais.DataDeCaptura))),
            new CampoCadastroModel("HORÁRIO DE CAPTURA", CriaTimePicker(Captura.DadosGerais, nameof(Captura.DadosGerais.HorarioDeCaptura))),
            new CampoCadastroModel("CONTATO DO RESPONSÁVEL", CriaEntryComTecladoNormal(Captura.DadosGerais, nameof(Captura.DadosGerais.ContatoDoResponsavel))),
            new CampoCadastroModel("OBSERVAÇÕES", CriaEditor(Captura.DadosGerais, nameof(Captura.DadosGerais.Observacoes)))
        };

        FichaAnestesica = new List<CampoCadastroModel>
        {
            new CampoCadastroModel("TIPO DE ANESTÉSICO/DOSE", CriaEntryComTecladoNormal(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.TipoAnestesicoOuDose))),
            new CampoCadastroModel("VIA DE ADMINISTRAÇÃO", CriaEntryComTecladoNormal(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.ViaDeAdministracao))),
            new CampoCadastroModel("APLICAÇÃO", CriaTimePicker(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.Aplicacao))),
            new CampoCadastroModel("INDUÇÃO", CriaTimePicker(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.Inducao))),
            new CampoCadastroModel("RETORNO", CriaTimePicker(Captura.FichaAnestesica, nameof(Captura.FichaAnestesica.Retorno)))
        };

        Biometria = new List<CampoCadastroModel>
        {
            new CampoCadastroModel("COMPRIMENTO TOTAL", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoTotal))),
            new CampoCadastroModel("COMPRIMENTO DA CABEÇA", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDaCabeca))),
            new CampoCadastroModel("LARGURA DA CABEÇA", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraDaCabeca))),
            new CampoCadastroModel("PADRÃO ESCUDO CEFÁLICO", CriaEntryComTecladoNormal(Captura.Biometria, nameof(Captura.Biometria.PadraoEscudoCefalico))),
            new CampoCadastroModel("COMPRIMENTO ESCUDO CEFÁLICO", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoEscudoCefalico))),
            new CampoCadastroModel("LARGURA ESCUDO CEFÁLICO", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraEscudoCefalico))),
            new CampoCadastroModel("LARGURA INTER-ORBITAL", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraInterOrbital))),
            new CampoCadastroModel("COMPRIMENTO DA ORELHA", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDaOrelha))),
            new CampoCadastroModel("COMPRIMENTO DA CAUDA", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDaCauda))),
            new CampoCadastroModel("LARGURA DA CAUDA", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraDaCauda))),
            new CampoCadastroModel("COMPRIMENTO ESCUDO ESCAPULAR", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoEscudoEscapular))),
            new CampoCadastroModel("SEMICIRCUNFERÊNCIA ESCUDO ESCAPULAR", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.SemicircunferenciaEscudoEscapular))),
            new CampoCadastroModel("COMPRIMENTO ESCUDO PÉLVICO", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoEscudoPelvico))),
            new CampoCadastroModel("SEMICIRCUNFERÊNCIA ESCUDO PÉLVICO", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.SemicircunferenciaEscudoPelvico))),
            new CampoCadastroModel("LARGURA NA 2ª CINTA", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraNaSegundaCinta))),
            new CampoCadastroModel("NÚMERO DE CINTAS", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.NumeroDeCintas))),
            new CampoCadastroModel("COMPRIMENTO MÃO SEM UNHA", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoMaoSemUnha))),
            new CampoCadastroModel("COMPRIMENTO UNHA DA MÃO", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoUnhaDaMao))),
            new CampoCadastroModel("COMPRIMENTO PÉ SEM UNHA", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoPeSemUnha))),
            new CampoCadastroModel("COMPRIMENTO UNHA DO PÉ", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoUnhaDoPe))),
            new CampoCadastroModel("COMPRIMENTO DO PÊNIS", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDoPenis))),
            new CampoCadastroModel("LARGURA BASE DO PÊNIS", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.LarguraBasePenis))),
            new CampoCadastroModel("COMPRIMENTO DO CLITÓRIS", CriaEntryComTecladoNumerico(Captura.Biometria, nameof(Captura.Biometria.ComprimentoDoClitoris)))
        };

        Amostras = new List<CampoCadastroModel>
        {
            new CampoCadastroModel("SANGUE", CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Sangue))),
            new CampoCadastroModel("FEZES", CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Fezes))),
            new CampoCadastroModel("PELO", CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Pelo))),
            new CampoCadastroModel("ECTOPARASITOS", CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Ectoparasitos))),
            new CampoCadastroModel("SWAB", CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Swab))),
            new CampoCadastroModel("LOCAL", CriaCheckBox(Captura.Amostras, nameof(Captura.Amostras.Local)))
        };
    }
    
    public List<CampoCadastroModel> DadosGerais { get; }
    public List<CampoCadastroModel> Biometria { get; }
    public List<CampoCadastroModel> Amostras { get; }
    public CampoCadastroModel Outros { get; } = new("OUTROS", CriaEditor(Captura.Amostras, nameof(Captura.Amostras.Outros)));
    
    public List<CampoCadastroModel> FichaAnestesica { get; }
    public ObservableCollection<ParametroFisiologicoModel> ParametrosFisiologicos { get; set; } = new();

    // ================================= COMANDOS ===============================================

    [RelayCommand]
    private void AdicionaParametrosFisiologicos()
    {
        ParametrosFisiologicos.Add(new ParametroFisiologicoModel());
    }

    [RelayCommand]  // Ligado ao botão "Finalizar"
    async Task AdicionaCapturaNoBanco()
    {
        Captura.FichaAnestesica.ParametrosFisiologicos = ParametrosFisiologicos.ToList();

        await BancoDeDadosService.SalvaCapturaAsync(Captura, _tatu);
        Captura = new CapturaModel();
    }

    // ================================= MÉTODOS ===============================================

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
 
        entry.SetBinding(Entry.TextProperty, new Binding(caminhoDeBinding, mode: BindingMode.TwoWay));
        return entry;
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
