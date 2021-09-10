using PresentationProjectDomainDb;
using PresentationProjectDomainModels.Implementation;
using PresentationProjectDomainServices.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainServices.Implementation
{
    public class UserService : IUserService
    {
        private readonly string dbConnectionString = @"Data Source=DESKTOP-0FM65T2;Initial Catalog=User;Integrated Security=True";
        public bool CreateUser(string name, string surname, int age, string email, string username, string password)
        {
            try
            {
                string myUserSQL = string.Empty;
                myUserSQL += "INSERT INTO UserTbl (Name, Surname, Age, Email, Username, Password) ";
                myUserSQL += "VALUES ('" + name + "', '" + surname + "',";
                myUserSQL += "'" + age + "', '" + email + "', '" + username + "', '" + password + "')";

                // posting user on Server
                SQLDatabaseServerConnection.ExecuteSQL(myUserSQL, dbConnectionString);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
