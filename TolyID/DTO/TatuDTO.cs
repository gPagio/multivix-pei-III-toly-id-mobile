using Newtonsoft.Json;
using TolyID.MVVM.Models;

namespace TolyID.DTO
{
    public class TatuDTO
    {
        [JsonProperty("identificacaoAnimal")]
        public string? IdentificacaoAnimal { get; set; }

        [JsonProperty("numeroMicrochip")]
        public int? NumeroMicrochip { get; set; }

        [JsonProperty("sexo")]
        public string? Sexo {  get; set; }
        public TatuDTO(Tatu tatu)
        {
            IdentificacaoAnimal = tatu.IdentificacaoAnimal;
            NumeroMicrochip = tatu.NumeroMicrochip;
            Sexo = tatu.Sexo;
        }
    }
}
