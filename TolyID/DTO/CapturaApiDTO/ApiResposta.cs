using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TolyID.Services.Api.TatusApiService;

namespace TolyID.DTO.ApiDTO
{
    public class ApiResposta
    {
        [JsonProperty("content")]
        public List<ContentDTO>? Content { get; set; }

        [JsonProperty("pageable")]
        public PageableDTO Pageable { get; set; }

        [JsonProperty("last")]
        public bool Last { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("totalElements")]
        public int TotalElements { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("number")]
        public int Number { get; set; }

        [JsonProperty("sort")]
        public SortDTO Sort { get; set; }

        [JsonProperty("numberOfElements")]
        public int NumberOfElements { get; set; }

        [JsonProperty("first")]
        public bool First { get; set; }

        [JsonProperty("empty")]
        public bool Empty { get; set; }
    }
}
