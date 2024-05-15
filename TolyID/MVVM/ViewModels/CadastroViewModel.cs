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
        new CampoCadastroModel("COMPRIMENTO TOTAL", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("COMPRIMENTO DA CABEÇA", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("LARGURA DA CABEÇA", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("PADRÃO ESCUDO CEFÁLICO", new Entry(){Keyboard = Keyboard.Default}),
        new CampoCadastroModel("COMPRIMENTO ESCUDO CEFÁLICO", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("LARGURA ESCUDO CEFÁLICO", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("LARGURA INTER-ORBITAL", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("COMPRIMENTO DA ORELHA", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("COMPRIMENTO DA CAUDA", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("LARGURA DA CAUDA", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("COMPRIMENTO ESCUDO ESCAPULAR", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("SEMICIRCUNFERÊNCIA ESCUDO ESCAPULAR", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("COMPRIMENTO ESCUDO PÉLVICO", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("SEMICIRCUNFERÊNCIA ESCUDO PÉLVICO", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("LARGURA NA 2ª CINTA", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("NÚMERO DE CINTAS", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("COMPRIMENTO MÃO SEM UNHA", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("COMPRIMENTO UNHA DA MÃO", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("COMPRIMENTO PÉ SEM UNHA", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("COMPRIMENTO UNHA DO PÉ", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("COMPRIMENTO DO PÊNIS", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("LARGURA BASE DO PÊNIS", new Entry(){Keyboard = Keyboard.Numeric}),
        new CampoCadastroModel("COMPRIMENTO DO CLITÓRIS", new Entry(){Keyboard = Keyboard.Numeric})
    ];
}
