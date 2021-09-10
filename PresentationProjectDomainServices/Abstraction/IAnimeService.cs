using PresentationProjectDomainModels.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainServices.Abstraction
{
    public interface IAnimeService
    {
        AnimeDataContainer GetAnimeResultContainerData(string animeName);
        IEnumerable<Anime> GetAnimeData(string animeName);
        Anime GetSingleAnimeData(long id);
    }
}
