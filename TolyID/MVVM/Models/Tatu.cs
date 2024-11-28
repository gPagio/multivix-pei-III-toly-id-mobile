using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TolyID.MVVM.Models;

[Table("Tatu")]
public class Tatu
{
    #region para realizar sincronizacao com o banco
    public int? IdAPI { get; set; }
    public bool FoiEnviadoParaApi { get; set; } = false;
    public DateTime? UltimaAtualizacao { get; set; }
    #endregion

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string? IdentificacaoAnimal { get; set; }

    public int? NumeroMicrochip { get; set; }

    public string? Sexo { get; set; } = "M";

    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public List<Captura>? Capturas { get; set; }


    [Ignore]
    public SexoTatu SexoTatu
    {
        get => Sexo == "F" ? SexoTatu.Femea : SexoTatu.Macho;
        set => Sexo = value == SexoTatu.Femea ? "F" : "M";
    }

    public override string ToString()
    {
        return $"Id: {Id}\nIdentificacao do Animal: {IdentificacaoAnimal}\nNumero do Microchip: {NumeroMicrochip}\n";
    }
}
