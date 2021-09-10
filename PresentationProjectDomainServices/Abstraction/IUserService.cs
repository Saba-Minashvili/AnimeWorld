using PresentationProjectDomainModels.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainServices.Abstraction
{
    public interface IUserService
    {
        bool CreateUser(string name, string surname, int age, string email, string username, string password);
    }
}
