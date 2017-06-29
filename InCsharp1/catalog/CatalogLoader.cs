using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CsharpEvolve
{
    public class CatalogLoader : ICatalogLoader
    {

        private static IEnumerable<string> CategoryFiles
        {
            get
            {
                var catalogPath = "../../catalog";
                var dataPath = "data.txt";
                return Directory.GetDirectories(catalogPath)
                    .Select(dir => Path.Combine(dir, dataPath));
            }
        }
        public Catalog LoadCatalog()
        {
            var datas = CategoryFiles
                            .SelectMany(file => 
                                File.ReadLines(file)
                                .Select(Product.FromCsv));
            
            return new Catalog(datas);
        }
    }
}
