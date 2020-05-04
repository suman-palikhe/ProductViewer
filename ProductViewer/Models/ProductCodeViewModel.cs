using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductViewer.Models
{
    public class ProductCodeViewModel
    {
        public string ProductFilePath { get; set; }

        public string RetailerProductFilePath { get; set; }

        public List<ProductCodeView> ProductCodes { get; set; }
    }
}
