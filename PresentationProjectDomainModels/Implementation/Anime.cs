using Newtonsoft.Json;
using PresentationProjectDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainModels.Implementation
{
    public class Anime
    {
        [JsonProperty("mal_id")]
        public long Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("synopsis")]
        public string Synopsis { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("episodes")]
        public long Episodes { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        [JsonProperty("members")]
        public long Members { get; set; }
    }
}
