using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TolyID.MVVM.Models;

public class TatuCapturadoModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }


    [ForeignKey(typeof(DadosGeraisModel))]
    public int DadosGeraisId { get; set; }

    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public DadosGeraisModel DadosGerais { get; set; } = new();


    [ForeignKey(typeof(BiometriaModel))]
    public int BiometriaId { get; set; }

    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public BiometriaModel Biometria { get; set; } = new();


    [ForeignKey(typeof(AmostrasModel))]
    public int AmostrasId { get; set; }

    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public AmostrasModel Amostras { get; set; } = new();
}

