using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TolyID.MVVM.Models;

namespace TolyID.DTO.ApiDTO
{
    public class ContentDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("usuario")]
        public UsuarioDTO Usuario { get; set; }

        [JsonProperty("tatu")]
        public Tatu Tatu { get; set; }

        [JsonProperty("dadosGerais")]
        public DadosGerais DadosGerais { get; set; }

        [JsonProperty("fichaAnestesica")]
        public FichaAnestesica FichaAnestesica { get; set; }

        [JsonProperty("biometria")]
        public Biometria Biometria { get; set; }

        [JsonProperty("amostra")]
        public Amostras Amostra { get; set; }
    }
}
