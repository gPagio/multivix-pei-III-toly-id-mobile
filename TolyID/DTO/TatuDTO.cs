using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TolyID.MVVM.Models;

namespace TolyID.DTO
{
    public class TatuDTO
    {
        [JsonProperty("identificacaoAnimal")]
        public string? IdentificacaoAnimal { get; set; }

        [JsonProperty("numeroMicrochip")]
        public int NumeroMicrochip { get; set; }
        public TatuDTO(Tatu tatu)
        {
            IdentificacaoAnimal = tatu.IdentificacaoAnimal;
            NumeroMicrochip = tatu.NumeroMicrochip;
        }

    }
}
