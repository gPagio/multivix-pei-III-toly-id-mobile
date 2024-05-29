using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions;

namespace TolyID.MVVM.Models;

[Table("TatusCapturados")]
public class TatuCapturadoModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [ForeignKey(typeof(DadosGeraisModel))]
    public int DadosGeraisId { get; set; }

    [OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
    public DadosGeraisModel DadosGerais { get; set; } = new();


    [ForeignKey(typeof(BiometriaModel))]
    public int BiometriaId { get; set; }

    [OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
    public BiometriaModel Biometria { get; set; } = new();


    [ForeignKey(typeof(AmostrasModel))]
    public int AmostrasId { get; set; }

    [OneToOne(CascadeOperations = CascadeOperation.CascadeRead)]
    public AmostrasModel Amostras { get; set; } = new();
}

