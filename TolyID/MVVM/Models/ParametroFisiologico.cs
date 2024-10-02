using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel;

namespace TolyID.MVVM.Models;

[Table("ParametrosFisiologicos")]
public class ParametroFisiologico
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [ForeignKey(typeof(FichaAnestesica))]
    public int FichaAnestesicaId { get; set; }

    [DisplayName("FC")]
    public double? Fc { get; set; }

    [DisplayName("FR")]
    public double? Fr { get; set; }

    [DisplayName("Oximetria")]
    public double? Oximetria { get; set; }

    [DisplayName("Temperatura")]
    public double? Temperatura { get; set; }
}
