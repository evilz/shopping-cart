using System;
using System.Threading.Tasks;

namespace CsharpEvolve
{
    public interface ICatalogLoader
    {
       // Catalog LoadCatalog();

        Task<Catalog> LoadCatalog(IProgress<Product> progress);
    }
}