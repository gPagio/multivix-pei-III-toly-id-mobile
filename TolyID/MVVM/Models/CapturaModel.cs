using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TolyID.MVVM.Models;

[Table("Capturas")]
public class CapturaModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    
    [ForeignKey(typeof(TatuModel))]
    public int TatuId { get; set; } // CHAVE ESTRANGEIRA DO TATU


    [ForeignKey(typeof(DadosGeraisModel))]
    public int DadosGeraisId { get; set; }

    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public DadosGeraisModel DadosGerais { get; set; } = new();


    [ForeignKey(typeof(FichaAnestesicaModel))]
    public int FichaAnestesicaId { get; set; }
    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public FichaAnestesicaModel FichaAnestesica { get; set; } = new();


    [ForeignKey(typeof(BiometriaModel))]
    public int BiometriaId { get; set; }

    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public BiometriaModel Biometria { get; set; } = new();


    [ForeignKey(typeof(AmostrasModel))]
    public int AmostrasId { get; set; }

    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public AmostrasModel Amostras { get; set; } = new();
}

