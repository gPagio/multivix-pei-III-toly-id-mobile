using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TolyID.MVVM.Models;

[Table("Tatus")]
public class TatuModel : ObservableObject
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? IdentificacaoAnimal { get; set; }
    public int NumeroMicrochip { get; set; }

    [OneToMany(CascadeOperations = CascadeOperation.All)]
    public List<CapturaModel> Capturas { get; set; } = new();
}
