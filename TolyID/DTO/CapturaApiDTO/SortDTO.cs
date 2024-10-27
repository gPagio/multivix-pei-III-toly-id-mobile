using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TolyID.DTO.ApiDTO
{
    public class SortDTO
    {
        [JsonProperty("empty")]
        public bool Empty { get; set; }

        [JsonProperty("sorted")]
        public bool Sorted { get; set; }

        [JsonProperty("unsorted")]
        public bool Unsorted { get; set; }
    }
}
