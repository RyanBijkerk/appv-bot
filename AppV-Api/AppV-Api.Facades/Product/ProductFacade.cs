using System.Threading.Tasks;
using AppV_Api.Models.Product;
using AppV_Api.Services.Services;

namespace AppV_Api.Facades.Product
{
    public class ProductFacade
    {

        private readonly ProductServices _productServices;

        public ProductFacade()
        {
            _productServices = new ProductServices();
        }


        public async Task<ProductModel> GetProductInformation()
        {
            return await _productServices.GetProductInformation();
        }
    }
}
