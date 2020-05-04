using ProductViewer.Contracts;
using ProductViewer.Models;
using System;
using System.Globalization;

namespace ProductViewer.Implementation
{
    public class RetailerProductParser : DataParser<RetailerProduct>, IRetailerProductParser
	{
		public RetailerProductParser(IFileReader fileReader) : base(fileReader)
		{
		}

		protected override RetailerProduct ConvertToModel(string line)
		{
			var tokens = line.Split(",");

			return new RetailerProduct()
			{
				ProductId = int.Parse(tokens[0]),
				RetailerName = tokens[1],
				RetailerProductCode = tokens[2],
				RetailerProductCodeType = tokens[3],
				DateReceived = DateTime.Parse(tokens[4], CultureInfo.GetCultureInfo("en-AU"))
			};
		}
	}
}
