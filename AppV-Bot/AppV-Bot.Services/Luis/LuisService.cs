using System;
using System.Net.Http;
using System.Threading.Tasks;
using AppV_Bot.Models.Luis;
using Newtonsoft.Json;

namespace AppV_Bot.Services.Luis
{
    public class LuisService
    {
        public async Task<LuisModel> GetEntity(string query)
        {
            query = Uri.EscapeDataString(query);
            LuisModel data = new LuisModel();
            using (HttpClient client = new HttpClient())
            {
                string requestUri = "https://api.projectoxford.ai/luis/v1/application?id=ad7bfbd5-66c2-4185-8c3f-310a21634134&subscription-key=dd2b5fe1152844adbcc17a06dfacd3a5&q=" + query;
                HttpResponseMessage returnMessage = await client.GetAsync(requestUri);

                if (returnMessage.IsSuccessStatusCode)
                {
                    var jsonDataResponse = await returnMessage.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<LuisModel>(jsonDataResponse);
                }
            }

            return data;
        }
    }
}
