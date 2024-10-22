using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TolyID.MVVM.Models
{
    public class Usuario
    {
        [JsonProperty("email")]
        public string? Email { get; set; }
        [JsonProperty("senha")]
        public string? Senha { get; set; }
    }
}
