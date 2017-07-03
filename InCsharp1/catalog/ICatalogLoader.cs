using System;
using System.Threading.Tasks;

namespace CsharpEvolve
{
    public interface ICatalogLoader
    {
        // C# 5.0 : Task with progress report
        Task<Catalog> LoadCatalog(IProgress<Product> progress = null);
    }
}