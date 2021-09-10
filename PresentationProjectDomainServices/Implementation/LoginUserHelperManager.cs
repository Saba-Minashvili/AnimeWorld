using PresentationProjectDomainModels.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainServices.Implementation
{
    public class LoginUserHelperManager
    {
        private static IUserAccount _loginUser = default;
        public static void LogInUser(IUserAccount account) => _loginUser = account;
        public static void LogOutUser() => _loginUser = default;
        public static IUserAccount GetCurrentUser() => _loginUser;
    }
}
