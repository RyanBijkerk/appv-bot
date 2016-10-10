using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AppV_Api.Facades;
using AppV_Api.Models;

namespace AppV_Api.Controllers
{
    public class PackageController : ApiController
    {

        private readonly PackagesFacade _packagesFacade;

        public PackageController()
        {
            _packagesFacade = new PackagesFacade();
        }

        [Route("api/packages")]
        public async Task<List<PackageModel>> GetPackages()
        {
            return await _packagesFacade.GetPackages();
        }

    }
}
