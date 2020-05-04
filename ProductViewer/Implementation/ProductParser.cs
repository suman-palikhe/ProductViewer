using ProductViewer.Contracts;
using ProductViewer.Models;

namespace ProductViewer.Implementation
{
	public class ProductParser : DataParser<Product>, IProductParser
	{
		public ProductParser(IFileReader fileReader) : base(fileReader)
		{
		}

		protected override Product ConvertToModel(string line)
		{
			var tokens = line.Split(',');

			return new Product()
			{
				ProductId = int.Parse(tokens[0]),
				ProductName = tokens[1]
			};
		}
	}
}
