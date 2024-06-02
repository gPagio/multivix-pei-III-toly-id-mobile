using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel;

namespace TolyID.MVVM.Models;

[Table("ParametrosFisiologicos")]
public class ParametroFisiologicoModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [ForeignKey(typeof(FichaAnestesicaModel))]
    public int FichaAnestesicaId { get; set; }

    [DisplayName("FC")]
    public double Fc { get; set; }

    [DisplayName("FR")]
    public double Fr { get; set; }

    [DisplayName("Oximetria")]
    public double Oximetria { get; set; }

    [DisplayName("Temperatura")]
    public double Temperatura { get; set; }
}
