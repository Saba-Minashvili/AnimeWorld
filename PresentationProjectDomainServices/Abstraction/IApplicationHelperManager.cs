using PresentationProjectDomainDtos;
using PresentationProjectDomainModels.Abstraction;
using PresentationProjectDomainModels.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PresentationProjectDomainServices.Abstraction
{
    public interface IApplicationHelperManager
    {
        bool SignInUser(SignInUserDto user);
        void SignOutUser();
        UserAccount GetCurrentUser();
    }
}
