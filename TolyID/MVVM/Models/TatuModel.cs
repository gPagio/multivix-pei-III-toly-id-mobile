using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TolyID.MVVM.Models;

[Table("Tatus")]
public class TatuModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? IdentificacaoAnimal { get; set; }
    public int NumeroMicrochip { get; set; }

    [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
    public List<CapturaModel> Capturas { get; set; } = new();
}
