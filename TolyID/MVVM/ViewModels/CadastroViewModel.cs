using System.Collections.ObjectModel;
using TolyID.MVVM.Models;

namespace TolyID.MVVM.ViewModels;

public class CadastroViewModel
{
    public ObservableCollection<CampoCadastroModel> DadosGerais { get; } =
    [
        new CampoCadastroModel("ID ANIMAL", new Entry(){Keyboard = Keyboard.Default}),
        new CampoCadastroModel("Nº IDENTIFICAÇÃO", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("LOCAL DE CAPTURA", new Entry(){Keyboard = Keyboard.Default}),
        new CampoCadastroModel("EQUIPE RESPONSÁVEL", new Entry(){Keyboard = Keyboard.Default}),
        new CampoCadastroModel("INSTITUIÇÃO", new Entry(){Keyboard = Keyboard.Default}),
        new CampoCadastroModel("PESO", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("N° MICROCHIP", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("DATA DE CAPTURA", new DatePicker()),
        new CampoCadastroModel("HORARIO DE CAPTURA", new TimePicker()),
        new CampoCadastroModel("CONTATO DO RESPONSÁVEL", new Entry(){Keyboard = Keyboard.Default}),
        new CampoCadastroModel("OBSERVAÇÕES", new Entry(){Keyboard = Keyboard.Default})
    ];

    public ObservableCollection<CampoCadastroModel> Biometria { get; } =
    [
        new CampoCadastroModel("COMPRIMENTO TOTAL", Keyboard.Numeric),
        new CampoCadastroModel("COMPRIMENTO DA CABEÇA", Keyboard.Numeric),
        new CampoCadastroModel("LARGURA DA CABEÇA", Keyboard.Numeric),
        new CampoCadastroModel("PADRÃO ESCUDO CEFÁLICO", Keyboard.Default),
        new CampoCadastroModel("COMPRIMENTO ESCUDO CEFÁLICO", Keyboard.Numeric),
        new CampoCadastroModel("LARGURA ESCUDO CEFÁLICO", Keyboard.Numeric),
        new CampoCadastroModel("LARGURA INTER-ORBITAL", Keyboard.Numeric),
        new CampoCadastroModel("COMPRIMENTO DA ORELHA", Keyboard.Numeric),
        new CampoCadastroModel("COMPRIMENTO DA CAUDA", Keyboard.Numeric),
        new CampoCadastroModel("LARGURA DA CAUDA", Keyboard.Numeric),
        new CampoCadastroModel("COMPRIMENTO ESCUDO ESCAPULAR", Keyboard.Numeric),
        new CampoCadastroModel("SEMICIRCUNFERÊNCIA ESCUDO ESCAPULAR", Keyboard.Numeric),
        new CampoCadastroModel("COMPRIMENTO ESCUDO PÉLVICO", Keyboard.Numeric),
        new CampoCadastroModel("SEMICIRCUNFERÊNCIA ESCUDO PÉLVICO", Keyboard.Numeric),
        new CampoCadastroModel("LARGURA NA 2ª CINTA", Keyboard.Numeric),
        new CampoCadastroModel("NÚMERO DE CINTAS", Keyboard.Numeric),
        new CampoCadastroModel("COMPRIMENTO MÃO SEM UNHA", Keyboard.Numeric),
        new CampoCadastroModel("COMPRIMENTO UNHA DA MÃO", Keyboard.Numeric),
        new CampoCadastroModel("COMPRIMENTO PÉ SEM UNHA", Keyboard.Numeric),
        new CampoCadastroModel("COMPRIMENTO UNHA DO PÉ", Keyboard.Numeric),
        new CampoCadastroModel("COMPRIMENTO DO PÊNIS", Keyboard.Numeric),
        new CampoCadastroModel("LARGURA BASE DO PÊNIS", Keyboard.Numeric),
        new CampoCadastroModel("COMPRIMENTO DO CLITÓRIS", Keyboard.Numeric)
    ];
}
