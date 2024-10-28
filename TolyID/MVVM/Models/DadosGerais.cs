using Newtonsoft.Json;
using SQLite;
using System.ComponentModel;

namespace TolyID.MVVM.Models;

[Table("DadosGerais")]
public class DadosGerais
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    //[DisplayName("Número de Identificação")]
    //public int? NumeroIdentificacao { get; set; }

    [JsonProperty("localDeCaptura")]
    public string? LocalDeCaptura { get; set; }

    [JsonProperty("equipeResponsavel")]
    public string? EquipeResponsavel { get; set; }

    [JsonProperty("instituicao")]
    public string? Instituicao { get; set; }

    [JsonProperty("pesoDoTatu")]
    public double? Peso { get; set; }

    [JsonProperty("dataCaptura")]
    public DateTime DataHoraDeCaptura { get; set; } = DateTime.Now;

    //[DisplayName("Horário de Captura")]
    //public TimeSpan HorarioDeCaptura { get; set; } = DateTime.Now.TimeOfDay;

    [JsonProperty("contatoDoResponsavel")]
    public string? ContatoDoResponsavel { get; set; }

    [JsonProperty("observacoes")]
    public string? Observacoes { get; set; }
}
