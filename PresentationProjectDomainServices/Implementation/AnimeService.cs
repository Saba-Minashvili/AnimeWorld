using Newtonsoft.Json;
using PresentationProjectDomainModels.Implementation;
using PresentationProjectDomainServices.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainServices.Implementation
{
    public class AnimeService : IAnimeService
    {
        private readonly string _getDataApiurl = "https://api.jikan.moe/v3/search/anime?q=";
        private readonly string _getSingleDataApiurl = "https://api.jikan.moe/v3/anime/";
        public IEnumerable<Anime> GetAnimeData(string animeName)
        {
            var data = GetAnimeResultContainerData(animeName);
            return data.Results;
        }

        public AnimeDataContainer GetAnimeResultContainerData(string animeName)
        {
            var fullUrl = $"{_getDataApiurl}{animeName.ToLower()}";
            var response = WebProxyService.GetDataFromApi(fullUrl);
            var data = JsonConvert.DeserializeObject<AnimeDataContainer>(response);
            return data;
        }

        public Anime GetSingleAnimeData(long id)
        {
            var fullUrl = $"{_getSingleDataApiurl}{id}";
            var response = WebProxyService.GetDataFromApi(fullUrl);
            var data = JsonConvert.DeserializeObject<Anime>(response);
            return data;
        }
    }
}
