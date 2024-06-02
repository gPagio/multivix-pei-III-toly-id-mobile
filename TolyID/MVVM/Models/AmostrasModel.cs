using SQLite;
using System.ComponentModel;

namespace TolyID.MVVM.Models;

[Table("Amostras")]
public class AmostrasModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [DisplayName("Sangue")]
    public bool Sangue { get; set; }

    [DisplayName("Fezes")]
    public bool Fezes { get; set; }

    [DisplayName("Pelo")]
    public bool Pelo { get; set; }

    [DisplayName("Ectoparasitos")]
    public bool Ectoparasitos { get; set; }

    [DisplayName("SWAB")]
    public bool Swab { get; set; }

    [DisplayName("Local")]
    public bool Local { get; set; }

    [DisplayName("Outros")]
    public string? Outros { get; set; }
}
