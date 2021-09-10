using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PresentationProjectDomainServices.Implementation
{
    public class WebProxyService
    {
        public static string GetDataFromApi(string api)
        {
            HttpClient client = new HttpClient();
            var respone = client.GetStringAsync(api);
            return respone.Result;
        }
    }
}
