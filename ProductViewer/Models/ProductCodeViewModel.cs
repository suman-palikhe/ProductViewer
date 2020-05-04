using System.Collections.Generic;

namespace ProductViewer.Models
{
    public class ProductCodeViewModel
    {
        public string ProductFilePath { get; set; }

        public string RetailerProductFilePath { get; set; }

        public List<ProductCodeView> ProductCodes { get; set; }

        public string ErrorMessage { get; set; }
    }
}
