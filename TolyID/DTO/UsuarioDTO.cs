using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TolyID.MVVM.Models
{
    public class UsuarioDTO
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("telefone")]
        public string Telefone { get; set; }
    }
}
