using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductViewer.Contracts
{
    public interface IFileReader
    {
        Task<List<string>> ReadLines(string filePath);
    }
}
