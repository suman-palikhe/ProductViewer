using ProductViewer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductViewer.Contracts
{
    public interface IProductAggregator
    {
        Task<List<ProductCodeView>> GetDistinctCodeTypes(string productFilePath, string retailerProductFilePath);
    }
}
