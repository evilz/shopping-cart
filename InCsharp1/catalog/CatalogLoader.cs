using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsharpEvolve
{
    public class CatalogLoaderWithCache : ICatalogLoader
    {
        private readonly ICatalogLoader _innerLoader;
        private Catalog _cachedCatalog;

        public CatalogLoaderWithCache(ICatalogLoader catalogLoader) => _innerLoader = catalogLoader;

        public async Task<Catalog> LoadCatalog(IProgress<Product> progress)
        {
            if (_cachedCatalog == null)
            {
                _cachedCatalog = await _innerLoader.LoadCatalog(progress);
            }

            return _cachedCatalog;
        }
    }
    public class CatalogLoader : ICatalogLoader
    {
        // TASK from C# 4 using TPL
        public Task<Catalog> LoadCatalog(IProgress<Product> progress = null)
        {
            var datas = CategoryFiles
                .AsParallel()
                .SelectMany(file =>
                {
                    return ReadLines(file).Select(t =>
                    {
                        var category = ExtractCategoryNameForm(t.file);
                        var product = t.line.ParseAsCsvProduct(category);
                        progress?.Report(product);
                        return product;
                    });

                });
            return Task.FromResult(new Catalog(datas.ToList()));
        }

        private static IEnumerable<string> CategoryFiles
        {
            get
            {
                const string catalogPath = "../../Data";
                string dataPath = "data.txt";

                // C# 3.0 : LINQ
                return Directory.GetDirectories(catalogPath)
                                .Select(dir => Path.Combine(dir, dataPath));
            }
        }
        
        private static string ExtractCategoryNameForm(string filePath)
        {
            var category = new DirectoryInfo(Path.GetDirectoryName(filePath)).Name;
            category = Regex.Replace(category, "\\d+-", string.Empty);
            return category;
        }

        // C# 7.0 : Named tuple
        private static IEnumerable<(string file, string line)> ReadLines(string file)
        {
            foreach (var line in File.ReadLines(file))
            {
                // C# 2.0 : Iterators
                yield return (file,line);
                Task.Delay(500).Wait();
            }

        }
    }
}
