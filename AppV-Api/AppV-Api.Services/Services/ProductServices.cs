using System.Reflection;
using System.Threading.Tasks;
using AppV_Api.Models.Product;

namespace AppV_Api.Services.Services
{
    public class ProductServices
    {
        public async Task<ProductModel> GetProductInformation()
        {
            return await Task.Run(() =>
            {
                return new ProductModel {Version = Assembly.GetExecutingAssembly().GetName().Version.ToString()};
            });

        }
    }
}