using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TolyID.MVVM.Models;

[Table("Tatu")]
public class Tatu
{
    #region para realizar sincronizacao com o banco
    public int? IdAPI { get; set; }
    public bool FoiEnviadoParaApi { get; set; } = false;
    #endregion

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string? IdentificacaoAnimal { get; set; }

    public int NumeroMicrochip { get; set; }

    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public List<Captura>? Capturas { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}\nIdentificacao do Animal: {IdentificacaoAnimal}\nNumero do Microchip: {NumeroMicrochip}\n";
    }
}
