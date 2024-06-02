using SQLite;
using System.ComponentModel;

namespace TolyID.MVVM.Models;

[Table("DadosGerais")]
public class DadosGeraisModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    //public string? IdAnimal { get; set; }
    [DisplayName("Número de Identificação")]
    public int NumeroIdentificacao { get; set; }

    [DisplayName("Local de Captura")]
    public string? LocalDeCaptura { get; set; }

    [DisplayName("Equipe Responsável")]
    public string? EquipeResponsavel { get; set; }

    [DisplayName("Instituição")]
    public string? Instituicao { get; set; }

    [DisplayName("Peso")]
    public double Peso { get; set; }
    //public int NumeroMicrochip { get; set; }

    [DisplayName("Data de Captura")]
    public DateTime DataDeCaptura { get; set; }

    [DisplayName("Horário de Captura")]
    public TimeSpan HorarioDeCaptura { get; set; }

    [DisplayName("Contato do Responsável")]
    public string? ContatoDoResponsavel { get; set; }

    [DisplayName("Observações")]
    public string? Observacoes { get; set; }
}
