using Microsoft.AspNetCore.Mvc;
using ProductViewer.Contracts;
using ProductViewer.Models;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace ProductViewer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private const string ProductFile = "IRIProducts.txt";
        private const string RetailerProducts = "RetailerProducts.txt";
        private IProductAggregator _productAggregator;

        public ProductController(IProductAggregator productAggregator)
        {
            _productAggregator = productAggregator;
        }

        [HttpGet]
        public async Task<ProductCodeViewModel> Get()
        {
            var productFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Files", ProductFile);
            var retailerProductFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Files", RetailerProducts);

            var result = await _productAggregator.GetDistinctCodeTypes(productFilePath, retailerProductFilePath);

            return new ProductCodeViewModel()
            {
                ProductCodes = result,
                ProductFilePath = productFilePath,
                RetailerProductFilePath = retailerProductFilePath
            };
        }
    }
}
