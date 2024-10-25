using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TolyID.MVVM.Models;

namespace TolyID.DTO
{
    public class AmostrasDTO
    {
        [JsonProperty("sangue")]
        public bool Sangue { get; set; }

        [JsonProperty("fezes")]
        public bool Fezes { get; set; }

        [JsonProperty("pelo")]
        public bool Pelo { get; set; }

        [JsonProperty("ectoparasitos")]
        public bool Ectoparasitos { get; set; }

        [JsonProperty("swab")]
        public bool Swab { get; set; }

        [JsonProperty("local")]
        public bool Local { get; set; }

        [JsonProperty("outros")]
        public string Outros { get; set; }

        public AmostrasDTO(Amostras amostras)
        {
            Sangue = amostras.Sangue;
            Fezes = amostras.Fezes;
            Pelo = amostras.Pelo;
            Ectoparasitos = amostras.Ectoparasitos;
            Swab = amostras.Swab;
            Local = amostras.Local;
        }
    }

    
}
