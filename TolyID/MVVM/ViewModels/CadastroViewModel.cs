using System.Collections.ObjectModel;
using TolyID.MVVM.Models;

namespace TolyID.MVVM.ViewModels;

public class CadastroViewModel
{
    public ObservableCollection<CampoCadastroModel> DadosGerais { get; } =
    [
        new CampoCadastroModel("ID ANIMAL", ""),
        new CampoCadastroModel("Nº IDENTIFICAÇÃO", 0),
        new CampoCadastroModel("LOCAL DE CAPTURA", ""),
        new CampoCadastroModel("EQUIPE RESPONSÁVEL", ""),
        new CampoCadastroModel("INSTITUIÇÃO", ""),
        new CampoCadastroModel("PESO", 0.0),
        new CampoCadastroModel("N° MICROCHIP", 0),
        new CampoCadastroModel("DATA DE CAPTURA", 0),
        new CampoCadastroModel("HORARIO DE CAPTURA", 0),
        new CampoCadastroModel("CONTATO DO RESPONSÁVEL", ""),
        new CampoCadastroModel("OBSERVAÇÕES", "")
    ];

    public ObservableCollection<CampoCadastroModel> Biometria { get; } =
    [
        new CampoCadastroModel("COMPRIMENTO TOTAL", 0.0),
        new CampoCadastroModel("COMPRIMENTO DA CABEÇA", 0.0),
        new CampoCadastroModel("LARGURA DA CABEÇA", 0.0),
        new CampoCadastroModel("PADRÃO ESCUDO CEFÁLICO", ""),
        new CampoCadastroModel("COMPRIMENTO ESCUDO CEFÁLICO", 0.0),
        new CampoCadastroModel("LARGURA ESCUDO CEFÁLICO", 0.0),
        new CampoCadastroModel("LARGURA INTER-ORBITAL", 0.0),
        new CampoCadastroModel("COMPRIMENTO DA ORELHA", 0.0),
        new CampoCadastroModel("COMPRIMENTO DA CAUDA", 0.0),
        new CampoCadastroModel("LARGURA DA CAUDA", 0.0),
        new CampoCadastroModel("COMPRIMENTO ESCUDO ESCAPULAR", 0.0),
        new CampoCadastroModel("SEMICIRCUNFERÊNCIA ESCUDO ESCAPULAR", 0.0),
        new CampoCadastroModel("COMPRIMENTO ESCUDO PÉLVICO", 0.0),
        new CampoCadastroModel("SEMICIRCUNFERÊNCIA ESCUDO PÉLVICO", 0.0),
        new CampoCadastroModel("LARGURA NA 2ª CINTA", 0.0),
        new CampoCadastroModel("NÚMERO DE CINTAS", 0),
        new CampoCadastroModel("COMPRIMENTO MÃO SEM UNHA", 0.0),
        new CampoCadastroModel("COMPRIMENTO UNHA DA MÃO", 0.0),
        new CampoCadastroModel("COMPRIMENTO PÉ SEM UNHA", 0.0),
        new CampoCadastroModel("COMPRIMENTO UNHA DO PÉ", 0.0),
        new CampoCadastroModel("COMPRIMENTO DO PÊNIS", 0.0),
        new CampoCadastroModel("LARGURA BASE DO PÊNIS", 0.0),
        new CampoCadastroModel("COMPRIMENTO DO CLITÓRIS", 0.0)
    ];
}
