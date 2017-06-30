using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CsharpEvolve
{
    public class CatalogLoader : ICatalogLoader
    {

        private static IEnumerable<string> CategoryFiles
        {
            get
            {
                var catalogPath = "../../Data";
                var dataPath = "data.txt";
                return Directory.GetDirectories(catalogPath)
                    .Select(dir => Path.Combine(dir, dataPath));
            }
        }
        //public Catalog LoadCatalog()
        //{
        //    var datas = CategoryFiles.AsParallel()
        //                    .SelectMany(file => ReadLines(file).Select(Product.FromCsv));

        //    return new Catalog(datas);
        //}

        public Task<Catalog> LoadCatalog(IProgress<Product> progress)
        {
            var datas = CategoryFiles.AsParallel()
                .SelectMany(file =>
                {
                    return ReadLines(file).Select( t =>
                    {
                        var category = new DirectoryInfo(Path.GetDirectoryName(t.file)).Name;
                        category = Regex.Replace(category, "\\d+-", string.Empty);
                        var product = Product.FromCsv(category, t.line);
                        progress.Report(product);
                        return product;
                    });
                   
                } );

            return Task.FromResult(new Catalog(datas));
        }

        private static IEnumerable<(string file, string line)> ReadLines(string file)
        {
            foreach (var line in File.ReadLines(file))
            {
                yield return (file,line);
                Task.Delay(500).Wait();
            }

        }

         
    }
}
