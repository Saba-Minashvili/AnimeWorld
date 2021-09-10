using PresentationProjectDomainModels.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainModels.Abstraction
{
    public interface IUserAccount
    {
        int Id { get; set; }
        IUser User { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string AccountImage { get; set; }
        string Email { get; set; }
        List<long> FavoriteAnimesIds { get; set; }
        List<Anime> FavoriteAnimes { get; set; }
    }
}
