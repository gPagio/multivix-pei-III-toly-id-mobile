using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TolyID.MVVM.Models;

namespace TolyID.DTO
{
    public class CapturaDTO
    {
        [JsonProperty("dadosGeraisDTO")]
        public DadosGeraisDTO DadosGeraisDTO { get; set; }

        [JsonProperty("fichaAnestesicaDTO")]
        public FichaAnestesicaDTO FichaAnestesicaDTO { get; set; }

        [JsonProperty("biometriaDTO")]
        public BiometriaDTO BiometriaDTO { get; set; }

        [JsonProperty("amostraDTO")]
        public AmostrasDTO AmostraDTO { get; set; }

        // Construtor mapeando as propriedades do modelo Captura para o DTO
        public CapturaDTO(Captura captura)
        {
            DadosGeraisDTO = new DadosGeraisDTO(captura.DadosGerais);
            FichaAnestesicaDTO = new FichaAnestesicaDTO(captura.FichaAnestesica);
            BiometriaDTO = new BiometriaDTO(captura.Biometria);
            AmostraDTO = new AmostrasDTO(captura.Amostras);
        }
    }
}
