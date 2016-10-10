using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AppV_Bot.Models;

namespace AppV_Bot.Services
{
    public class PackagesService
    {
        public async Task<List<PackageModel>> GetPackages()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:14722/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var path = "api/packages";
            List<PackageModel> packageList = new List<PackageModel>();

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                packageList = await response.Content.ReadAsAsync<List<PackageModel>>();
            }

            return packageList;
        }
    }
}
