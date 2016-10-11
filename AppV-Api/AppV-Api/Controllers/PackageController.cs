using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
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

        //[EnableQuery]
        [Route("api/packages")]
        public async Task<List<PackageModel>> GetPackages([FromUri]string packageName)
        {
            var packageList = await _packagesFacade.GetPackages();
            var packageListFiltered = packageList.Where(p => p.Name.ToLower() == packageName.ToLower()).ToList();

            return packageListFiltered;
        }
    }
}
