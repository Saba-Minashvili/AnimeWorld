using PresentationProjectDomainDb;
using PresentationProjectDomainModels.Implementation;
using PresentationProjectDomainServices.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PresentationProjectDomainServices.Implementation
{
    public class AccountService : IAccountService
    {
        public static List<UserAccount> _allAccount = default;
        private readonly string connectionString = @"Data Source=DESKTOP-0FM65T2;Initial Catalog=Account;Integrated Security=True";
        public bool CreateUserAccount(string username, string password, string email)
        {
            try
            { 
                // query for account to add info on SQL Server
                string myAccountSQL = string.Empty;
                myAccountSQL += "INSERT INTO AccountTbl (Username, Password, Email) ";
                myAccountSQL += "VALUES ('" + username + "', '" + password + "', '" + email + "')";

                // posting account on Server
                SQLDatabaseServerConnection.ExecuteSQL(myAccountSQL, connectionString);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
