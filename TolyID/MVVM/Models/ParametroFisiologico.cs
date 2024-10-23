using Newtonsoft.Json;
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

    [JsonProperty("frequenciaCardiaca")]
    public double? Fc { get; set; }

    [JsonProperty("frequenciaRespiratoria")]
    public double? Fr { get; set; }

    [JsonProperty("oximetria")]
    public double? Oximetria { get; set; }

    [JsonProperty("temperatura")]
    public double? Temperatura { get; set; }
}
