using ProductViewer.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductViewer.Implementation
{
	public abstract class DataParser<TEntity> : IDataParser<TEntity> where TEntity : class
	{
		private IFileReader _fileReader;

		public DataParser(IFileReader fileReader)
		{
			_fileReader = fileReader;
		}

		public async Task<List<TEntity>> GetData(string filePath)
		{
			var data = new List<TEntity>();
			var lines = await _fileReader.ReadLines(filePath);

			foreach (var item in lines)
			{
				data.Add(ConvertToModel(item));
			}

			return data;
		}

		protected abstract TEntity ConvertToModel(string line); 

	}
}
