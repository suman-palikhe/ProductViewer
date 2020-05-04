using ProductViewer.Contracts;
using ProductViewer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductViewer.Implementation
{
    public class ProductAggregator : IProductAggregator
    {
        private IProductParser _productParser;
        private IRetailerProductParser _retailerProductParser;

        public ProductAggregator(IProductParser productParser, IRetailerProductParser retailerProductParser)
        {
            _productParser = productParser;
            _retailerProductParser = retailerProductParser;
        }


        public async Task<List<ProductCodeView>> GetDistinctCodeTypes(string productFilePath, string retailerProductFilePath)
        {
            var products = await _productParser.GetData(productFilePath);

            var retailerProducts = await _retailerProductParser.GetData(retailerProductFilePath);

            return GenerateDistinctCodes(retailerProducts, products.ToDictionary(x => x.ProductId));
        }


        public List<ProductCodeView> GenerateDistinctCodes(List<RetailerProduct> retailerProducts, Dictionary<int, Product> productDictionary)
        {
            var result = new List<ProductCodeView>();
            var groupByProductId = retailerProducts.GroupBy(x => x.ProductId);

            foreach (var productIdGroup in groupByProductId)
            {
                var groupByCodeType = productIdGroup.GroupBy(x => x.RetailerProductCodeType);
                foreach (var item in groupByCodeType)
                {
                    var productInfo = item.OrderByDescending(x => x.DateReceived).FirstOrDefault();

                    result.Add(new ProductCodeView()
                    {
                        ProductId = productInfo.ProductId,
                        ProductName = productDictionary[productInfo.ProductId].ProductName,
                        RetailerProductCode = productInfo.RetailerProductCode,
                        RetailerProductCodeType = productInfo.RetailerProductCodeType
                    });
                }
            }

            return result;
        }
    }
}
