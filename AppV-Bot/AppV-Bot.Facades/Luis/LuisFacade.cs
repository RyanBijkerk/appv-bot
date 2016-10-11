using System.Threading.Tasks;
using AppV_Bot.Models.Luis;
using AppV_Bot.Services.Luis;

namespace AppV_Bot.Facades.Luis
{
    public class LuisFacade
    {
        private readonly LuisService _luisService;

        public LuisFacade()
        {
            _luisService = new LuisService();
        }

        public async Task<LuisModel> GetEntity(string query)
        {
            return await _luisService.GetEntity(query);
        }
    }
}
