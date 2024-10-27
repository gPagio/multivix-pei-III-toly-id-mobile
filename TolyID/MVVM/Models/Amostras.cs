using Newtonsoft.Json;
using SQLite;
using System.ComponentModel;

namespace TolyID.MVVM.Models;

[Table("Amostras")]
public class Amostras
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [JsonProperty("sangue")]
    public bool Sangue { get; set; }

    [JsonProperty("fezes")]
    public bool Fezes { get; set; }

    [JsonProperty("pelo")]
    public bool Pelo { get; set; }

    [JsonProperty("ectoparasitos")]
    public bool Ectoparasitos { get; set; }

    [JsonProperty("swab")]
    public bool Swab { get; set; }

    [JsonProperty("local")]
    public bool Local { get; set; }

    [JsonProperty("outros")]
    public string? Outros { get; set; }
}
