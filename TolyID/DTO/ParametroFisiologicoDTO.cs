using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TolyID.MVVM.Models;  // Supondo que o modelo original esteja neste namespace

namespace TolyID.DTO
{
    public class ParametroFisiologicoDTO
    {
        [JsonProperty("frequenciaCardiaca")]
        public double? FrequenciaCardiaca { get; set; }

        [JsonProperty("frequenciaRespiratoria")]
        public double? FrequenciaRespiratoria { get; set; }

        [JsonProperty("oximetria")]
        public double? Oximetria { get; set; }

        [JsonProperty("temperatura")]
        public double? Temperatura { get; set; }

        // Construtor mapeando as propriedades do modelo ParametroFisiologico para o DTO
        public ParametroFisiologicoDTO(ParametroFisiologico parametro)
        {
            FrequenciaCardiaca = parametro.Fc;
            FrequenciaRespiratoria = parametro.Fr;
            Oximetria = parametro.Oximetria;
            Temperatura = parametro.Temperatura;
        }
    }
}
