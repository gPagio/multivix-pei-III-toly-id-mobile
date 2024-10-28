using Newtonsoft.Json;
using TolyID.MVVM.Models;

namespace TolyID.DTO
{
    public class DadosGeraisDTO
    {
        [JsonProperty("localDeCaptura")]
        public string? LocalDeCaptura { get; set; }

        [JsonProperty("equipeResponsavel")]
        public string? EquipeResponsavel { get; set; }

        [JsonProperty("instituicao")]
        public string? Instituicao { get; set; }

        [JsonProperty("pesoDoTatu")]
        public double? PesoDoTatu { get; set; }

        [JsonProperty("dataCaptura")]
        public string? DataCaptura { get; set; }

        [JsonProperty("contatoDoResponsavel")]
        public string? ContatoDoResponsavel { get; set; }

        [JsonProperty("observacoes")]
        public string? Observacoes { get; set; }

        // Construtor mapeando as propriedades do modelo DadosGerais para o DTO
        public DadosGeraisDTO(DadosGerais dadosGerais)
        {
            LocalDeCaptura = dadosGerais.LocalDeCaptura;
            EquipeResponsavel = dadosGerais.EquipeResponsavel;
            Instituicao = dadosGerais.Instituicao;
            PesoDoTatu = dadosGerais.Peso;

            // Gerando a string no formato "2024-10-06T16:30:00"
            var data = dadosGerais.DataHoraDeCaptura;
            DataCaptura = $"{data.Year}-{data.Month:D2}-{data.Day:D2}T{data.Hour:D2}:{data.Minute:D2}:{data.Second:D2}";

            ContatoDoResponsavel = dadosGerais.ContatoDoResponsavel;
            Observacoes = dadosGerais.Observacoes;
        }
    }
}
