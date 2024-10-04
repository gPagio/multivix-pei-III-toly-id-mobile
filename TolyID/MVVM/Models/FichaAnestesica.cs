using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel;

namespace TolyID.MVVM.Models;

[Table("FichasAnestesicas")]
public class FichaAnestesica
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [DisplayName("Tipo de Anestésico/Dose")]
    public string? TipoAnestesicoOuDose { get; set; }

    [DisplayName("Via de Administração")]
    public string? ViaDeAdministracao { get; set; }

    [DisplayName("Aplicação")]
    public TimeSpan? Aplicacao { get; set; }

    [DisplayName("Indução")]
    public TimeSpan? Inducao { get; set; }

    [DisplayName("Retorno")]
    public TimeSpan? Retorno { get; set; }

    [DisplayName("Parâmetros Fisiológicos a cada 10 min")]
    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public List<ParametroFisiologico> ParametrosFisiologicos { get; set; }

    public FichaAnestesica()
    {
        ParametrosFisiologicos = new List<ParametroFisiologico>();
    }
}
