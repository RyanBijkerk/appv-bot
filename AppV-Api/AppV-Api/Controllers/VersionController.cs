using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using AppV_Api.Facades.Product;
using AppV_Api.Models.Product;

namespace AppV_Api.Controllers
{
    public class VersionController : ApiController
    {
        private readonly ProductFacade _productFacade;

        public VersionController()
        {
            _productFacade = new ProductFacade();
        }

        [Route("api/productinformation")]
        public async Task<ProductModel> GetProductInformation()
        {
            return await _productFacade.GetProductInformation();
        }

    }
}
