using PresentationProjectDomainDb;
using PresentationProjectDomainDtos;
using PresentationProjectDomainModels.Abstraction;
using PresentationProjectDomainModels.Implementation;
using PresentationProjectDomainServices.Abstraction;
using System;
using System.Collections.Generic;

namespace PresentationProjectDomainServices.Implementation
{
    public class ApplicationHelperManager : IApplicationHelperManager
    {
        private readonly string _tablePath = "loginAccount.json";
        private readonly string _allAccounts = "allAccounts.json";

        public UserAccount GetCurrentUser()
        {
            return DbFileWorkerService.ReadFromFile(_tablePath);
        }

        public bool SignInUser(SignInUserDto user)
        {
            try
            {
                var existUser = DbFileWorkerService.ReadDataFromFile<List<UserAccount>>(_allAccounts);
                foreach(var item in existUser)
                {
                    if (user.Username == item.Username && user.Password == item.Password)
                    {
                        var result = new UserAccount()
                        {
                            Username = user.Username,
                            Password = user.Password,
                            AccountImage = item.AccountImage,
                            Email = item.Email,
                            FavoriteAnimesIds = item.FavoriteAnimesIds,
                            FavoriteAnimes = item.FavoriteAnimes,
                            User = item.User
                        };

                        LoginUserHelperManager.LogInUser(result);
                        DbFileWorkerService.WriteInFile(result, _tablePath);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SignOutUser()
        {
            LoginUserHelperManager.LogOutUser();
        }
    }
}
