using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TolyID.MVVM.Models;

[Table("Tatu")]
public class Tatu
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [JsonProperty("identificacaoAnimal")]
    public string? IdentificacaoAnimal { get; set; }

    [JsonProperty("numeroMicrochip")]
    public int NumeroMicrochip { get; set; }

    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public List<Captura>? Capturas { get; set; }

    public bool FoiEnviadoParaApi { get; set; } = false;

    public override string ToString()
    {
        return $"Id: {Id}\nIdentificacao do Animal: {IdentificacaoAnimal}\nNumero do Microchip: {NumeroMicrochip}\n";
    }
}
