using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel;

namespace TolyID.MVVM.Models;

[Table("FichasAnestesicas")]
public class FichaAnestesica
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [JsonProperty("tipoAnestesicoOuDose")]
    public string? TipoAnestesicoOuDose { get; set; }

    [JsonProperty("viaDeAdministracao")]
    public string? ViaDeAdministracao { get; set; }

    [JsonProperty("aplicacao")]
    public TimeSpan Aplicacao { get; set; } = new();

    [JsonProperty("inducao")]
    public TimeSpan Inducao { get; set; } = new();

    [JsonProperty("retorno")]
    public TimeSpan Retorno { get; set; } = new();

    [JsonProperty("parametrosFisiologicos")]
    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public List<ParametroFisiologico> ParametrosFisiologicos { get; set; }

    public FichaAnestesica()
    {
        ParametrosFisiologicos = new List<ParametroFisiologico>();
    }
}
