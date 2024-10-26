using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TolyID.DTO.ApiDTO
{
    public class PageableDTO
    {
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("sort")]
        public SortDTO Sort { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("paged")]
        public bool Paged { get; set; }

        [JsonProperty("unpaged")]
        public bool Unpaged { get; set; }
    }
}
