using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductViewer.Contracts
{
    public interface IDataParser<T>
    {
        Task<List<T>> GetData(string filePath);
    }
}
