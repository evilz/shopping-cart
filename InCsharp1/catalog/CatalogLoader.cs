using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsharpEvolve
{
    public class CatalogLoader : ICatalogLoader
    {
        // TASK from C# 4
        public Task<Catalog> LoadCatalog(IProgress<Product> progress = null)
        {
            var datas = CategoryFiles
                .AsParallel()
                .SelectMany(file =>
                {
                    return ReadLines(file).Select(t =>
                    {
                        var category = ExtractCategoryNameForm(t.file);
                        var product = t.line.ToProduct(category);
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
                var catalogPath = "../../Data";
                var dataPath = "data.txt";

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
