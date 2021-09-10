using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainModels.Abstraction
{
    public interface IUser
    {
        [Key]
        int Id { get; set; }
        [Required]
        string Name { get; set; }
        [Required]
        string Surname { get; set; }
        [Required]
        int Age { get; set; }
        [Required]
        string Password { get; set; }
        [Required]
        string Username { get; set; }
    }
}
