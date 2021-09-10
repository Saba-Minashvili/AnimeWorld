using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainModels.Implementation
{
    public class AnimeDataContainer
    {
        [JsonProperty("request_hash")]
        public string RequestHash { get; set; }

        [JsonProperty("request_cached")]
        public bool RequestCached { get; set; }

        [JsonProperty("request_cache_expiry")]
        public long RequestCacheExpiry { get; set; }

        [JsonProperty("results")]
        public List<Anime> Results { get; set; }
    }
}
