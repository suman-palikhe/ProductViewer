using ProductViewer.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductViewer.Implementation
{
	public class FileReader : IFileReader
    {
        public async Task<List<string>> ReadLines(string filePath)
        {
			try
			{
				return (await File.ReadAllLinesAsync(filePath)).ToList();
			}
			catch (Exception ex)
			{
				Console.Write($"Cannot read file. Path: {filePath}");
				throw;
			}
        }
    }
}
