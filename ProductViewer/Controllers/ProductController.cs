using Microsoft.AspNetCore.Mvc;
using ProductViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductViewer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<ProductCodeView> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ProductCodeView
            {
                ProductId = 12,
                ProductName = "asdasd",
                RetailerProductCode = "asdasd",
                RetailerProductCodeType = "asdsadsdsds"
            })
            .ToArray();
        }
    }
}
