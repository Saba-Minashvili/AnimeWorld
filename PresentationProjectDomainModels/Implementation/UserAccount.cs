using PresentationProjectDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainModels.Implementation
{
    public class UserAccount : IUserAccount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public IUser User { get; set; }
        public string AccountImage { get; set; }
        public string Email { get; set; }
        public List<long> FavoriteAnimesIds { get; set; } = new List<long>();
        public List<Anime> FavoriteAnimes { get; set; } = new List<Anime>();
    }
}
