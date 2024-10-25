using Newtonsoft.Json;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace TolyID.MVVM.Models;

[Table("Capturas")]
public class Captura
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    
    [ForeignKey(typeof(Tatu))]
    public int TatuId { get; set; } 

    [ForeignKey(typeof(DadosGerais))]
    public int DadosGeraisId { get; set; }

    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public DadosGerais DadosGerais { get; set; } = new();


    [ForeignKey(typeof(FichaAnestesica))]
    public int FichaAnestesicaId { get; set; }
    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public FichaAnestesica FichaAnestesica { get; set; } = new();


    [ForeignKey(typeof(Biometria))]
    public int BiometriaId { get; set; }

    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public Biometria Biometria { get; set; } = new();


    [ForeignKey(typeof(Amostras))]
    public int AmostrasId { get; set; }

    [OneToOne(CascadeOperations = CascadeOperation.All)]
    public Amostras Amostras { get; set; } = new();

    public bool FoiEnviadoParaApi {  get; set; } = false;
}

