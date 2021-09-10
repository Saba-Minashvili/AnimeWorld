using PresentationProjectDomainModels.Abstraction;
using PresentationProjectDomainModels.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainServices.Abstraction
{
    public interface IAccountService
    {
        bool CreateUserAccount(string username, string password, string email);
    }
}
