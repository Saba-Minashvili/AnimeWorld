using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainServices.Abstraction
{
    public interface IForgotPasswordService
    {
        bool SendForgotPasswordMessage(string email);
    }
}
