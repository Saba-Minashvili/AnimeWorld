using Newtonsoft.Json;
using PresentationProjectDomainModels.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainDb
{
    public static class DbFileWorkerService
    {
        public static void WriteCollectionInFile<T>(T item, string path)
        {
            List<T> allAccounts = new List<T>();
            allAccounts.Add(item);
            var json = JsonConvert.SerializeObject(allAccounts);
            var exist = File.Exists(path);

            if (!exist)
            {
                var create = File.Create(path);
                create.Dispose();
            }

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(json);
            }
        }

        public static void WriteInFile(UserAccount item, string path)
        {
            var json = JsonConvert.SerializeObject(item);
            var exist = File.Exists(path);

            if (!exist)
            {
                var create = File.Create(path);
                create.Dispose();
            }

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(json);
            }
        }

        public static void WriteInFile(UserAccount item, string path, bool append)
        {
            var allAccountData = ReadDataFromFile<List<UserAccount>>(path);
            var existsUser = allAccountData.FirstOrDefault(o => o.Username == item.Username && o.Password == item.Password);
            if(existsUser != null)
            {
                allAccountData.Remove(existsUser);
                allAccountData.Add(item);
            }
            else
            {
                allAccountData.Add(item);
            }
            var json = JsonConvert.SerializeObject(allAccountData);
            var exist = File.Exists(path);

            if (!exist)
            {
                var create = File.Create(path);
                create.Dispose();
            }

            using (StreamWriter writer = new StreamWriter(path, append))
            {
                writer.WriteLine(json);
            }
        }

        public static List<UserAccount> ReadDataFromFile<T>(string path)
        {
            try
            {
                var data = new List<UserAccount>();
                var json = string.Empty;
                using (StreamReader reader = new StreamReader(path))
                {
                    json = reader.ReadToEnd();
                }

                data = JsonConvert.DeserializeObject<List<UserAccount>>(json);

                if(data == null)
                {
                    data = new List<UserAccount>();
                }

                return data;
            }
            catch
            {
                return new List<UserAccount>();
            }
        }

        public static UserAccount ReadFromFile(string path)
        {
            var json = string.Empty;
            using (StreamReader reader = new StreamReader(path))
            {
                json = reader.ReadToEnd();
            }

            var data = JsonConvert.DeserializeObject<UserAccount>(json);

            return data;
        }
    }
}
