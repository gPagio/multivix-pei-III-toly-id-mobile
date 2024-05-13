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
}
