using Moq;
using ProductViewer.Contracts;
using ProductViewer.Models;
using ProductViewer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProductViewer.Implementation.Tests
{
    public class ProductAggregatorTests
    {
        [Fact]
        public async Task GenerateDistinctCodesTest()
        {
            var productsList = new List<Product>()
            {
                new Product(){ ProductId = 123, ProductName = "Pizza"},
                new Product(){ ProductId = 111, ProductName = "Chicken"},
            };

            var retailerProductList = new List<RetailerProduct>()
            {
                new RetailerProduct(){ProductId = 123, RetailerName = "WOOLWORTHS", RetailerProductCode = "111", RetailerProductCodeType = "Woolworths Reference Number" , DateReceived = new DateTime(2011, 10, 10) },
                new RetailerProduct(){ProductId = 123, RetailerName = "WOOLWORTHS", RetailerProductCode = "222", RetailerProductCodeType = "Woolworths Reference Number" , DateReceived = new DateTime(2018, 10, 10) },
                new RetailerProduct(){ProductId = 123, RetailerName = "WOOLWORTHS", RetailerProductCode = "333", RetailerProductCodeType = "BarCode" , DateReceived = new DateTime(2021, 12, 12) },
                new RetailerProduct(){ProductId = 123, RetailerName = "WOOLWORTHS", RetailerProductCode = "444", RetailerProductCodeType = "BarCode" , DateReceived = new DateTime(2018, 10, 10) },
                new RetailerProduct(){ProductId = 111, RetailerName = "Coles", RetailerProductCode = "555", RetailerProductCodeType = "Coles Ref Number" , DateReceived = new DateTime(2010, 10, 10) },
                new RetailerProduct(){ProductId = 111, RetailerName = "Coles", RetailerProductCode = "666", RetailerProductCodeType = "Coles Ref Number" , DateReceived = new DateTime(2020, 10, 10) }
            };

            var expectedResult = new List<ProductCodeView>()
            {
                new ProductCodeView(){ ProductId = 123, ProductName = "Pizza", RetailerProductCode = "222", RetailerProductCodeType = "Woolworths Reference Number" },
                new ProductCodeView(){ ProductId = 123, ProductName = "Pizza", RetailerProductCode = "333", RetailerProductCodeType = "BarCode" },
                new ProductCodeView(){ ProductId = 111, ProductName = "Chicken", RetailerProductCode = "666", RetailerProductCodeType = "Coles Ref Number" },
            };
            var productParser = new Mock<IProductParser>();
            var retailerProductParser = new Mock<IRetailerProductParser>();

            productParser.Setup(x => x.GetData(It.IsAny<string>())).ReturnsAsync(productsList);
            retailerProductParser.Setup(x => x.GetData(It.IsAny<string>())).ReturnsAsync(retailerProductList);

            var sut = new ProductAggregator(productParser.Object, retailerProductParser.Object);
            var result = await sut.GetDistinctCodeTypes("productFilePath", "retailerProductFilePath");

            Assert.Equal(expectedResult.OrderBy(x => x.RetailerProductCodeType), result.OrderBy(x => x.RetailerProductCodeType), new ProductCodeViewEqualityComparer());
        }

        [Fact]
        public async Task GenerateDistinctCodesTestTwo()
        {
            var productsList = new List<Product>()
            {
                new Product(){ ProductId = 18886, ProductName = "FISH OIL"}
            };

            var retailerProductList = new List<RetailerProduct>()
            {
                new RetailerProduct(){ProductId = 18886, RetailerName = "DDS", RetailerProductCode = "93482745", RetailerProductCodeType = "BarCode" , DateReceived = new DateTime(2011, 06, 16) },
                new RetailerProduct(){ProductId = 18886, RetailerName = "WOOLWORTHS", RetailerProductCode = "F8CE71964FAC90E59164FDB6AA19B10A", RetailerProductCodeType = "Woolworths Ref" , DateReceived = new DateTime(2018, 09, 05) },
                new RetailerProduct(){ProductId = 18886, RetailerName = "WOOLWORTHS", RetailerProductCode = "017E9562042C3E9F0E1D200A8C915052", RetailerProductCodeType = "Woolworths Ref" , DateReceived = new DateTime(2021, 03, 10) },
                new RetailerProduct(){ProductId = 18886, RetailerName = "Coles", RetailerProductCode = "93481745", RetailerProductCodeType = "BarCode" , DateReceived = new DateTime(2006, 04, 23) }
            };

            var expectedResult = new List<ProductCodeView>()
            {
                 new ProductCodeView(){ ProductId = 18886, ProductName = "FISH OIL", RetailerProductCode = "017E9562042C3E9F0E1D200A8C915052", RetailerProductCodeType = "Woolworths Ref" },
                 new ProductCodeView(){ ProductId = 18886, ProductName = "FISH OIL", RetailerProductCode = "93482745", RetailerProductCodeType = "BarCode" }
            };

            var productParser = new Mock<IProductParser>();
            var retailerProductParser = new Mock<IRetailerProductParser>();

            productParser.Setup(x => x.GetData(It.IsAny<string>())).ReturnsAsync(productsList);
            retailerProductParser.Setup(x => x.GetData(It.IsAny<string>())).ReturnsAsync(retailerProductList);

            var sut = new ProductAggregator(productParser.Object, retailerProductParser.Object);
            var result = await sut.GetDistinctCodeTypes("productFilePath", "retailerProductFilePath");

            Assert.Equal(expectedResult.OrderBy(x => x.RetailerProductCodeType), result.OrderBy(x => x.RetailerProductCodeType), new ProductCodeViewEqualityComparer());
        }
    }
}