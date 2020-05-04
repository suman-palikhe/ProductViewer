using ProductViewer.Models;
using System.Collections.Generic;

namespace ProductViewer.Utility
{
    public class ProductCodeViewEqualityComparer : IEqualityComparer<ProductCodeView>
    {
        public bool Equals(ProductCodeView x, ProductCodeView y)
        {
            return x.ProductId == y.ProductId
                    && x.RetailerProductCode == x.RetailerProductCode
                    && x.ProductName == y.ProductName
                    && x.RetailerProductCodeType == y.RetailerProductCodeType;
                    
        }

        public int GetHashCode(ProductCodeView obj)
        {
            return obj.ProductId.GetHashCode();
        }
    }
}
