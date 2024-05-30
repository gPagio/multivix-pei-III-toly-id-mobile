using SQLite;

namespace TolyID.MVVM.Models;

[Table("DadosGerais")]
public class DadosGeraisModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    //public string? IdAnimal { get; set; }
    public int NumeroIdentificacao { get; set; }

    public string? LocalDeCaptura { get; set; }
    public string? EquipeResponsavel { get; set; }
    public string? Instituicao { get; set; }
    public double Peso { get; set; }
    //public int NumeroMicrochip { get; set; }
    public DateTime DataDeCaptura { get; set; }
    public TimeSpan HorarioDeCaptura { get; set; }
    public string? ContatoDoResponsavel { get; set; }
    public string? Observacoes { get; set; }
}
