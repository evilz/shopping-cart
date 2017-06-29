using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolve
{
    public class Program
    {
        public static void Main()
        {
            // Configure Application (config file + service init)

            // Load Catalog
            var catalogLoader = new CatalogLoader();
            var catalog = catalogLoader.LoadCatalog();

            catalog.ToList().ForEach(product => Console.WriteLine($"{product.Id} \t\t{product.Title}\t\t\t\t\t\t{product.Amount}"));

            // Load Stock

            // display catalog

            // read action 
                // execute
                // loop


            //var pricer = new SimplePricer();
            //var cart = new ShoppingCart(pricer);

            //var product1 = new Product(new ProductId(1), 100, "Product 1",string.Empty);
            //var product2 = new Product(new ProductId(2), 50, "Product 2",string.Empty);

            //cart.AddItem(product1);
            
            //Console.Clear();
            //Console.Write(cart.Print());
            //Console.ReadLine();

            //cart.AddItem(product2);
            //Console.Clear();
            //Console.Write(cart.Print());
            Console.ReadLine();
        }
    }
}
