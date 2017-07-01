using System;
using System.Linq;

namespace CsharpEvolve
{
    public class Program
    {
        public static void Main()
        {
            // Configure Application (config file + service init)

            // Load Catalog
            var catalogLoader = new CatalogLoader();

            var counter = 0;
            var progress = new Progress<Product>(p =>
            {
                counter++;
                // log in file 
                //Console.WriteLine($"| {p.Category,-15} | {p.Id,3} | {p.Title,-35} | {p.Price,15:#####.00}$ |");
                Console.Clear();
                Console.WriteLine(counter);
            });

            var catalog = catalogLoader.LoadCatalog(progress).Result;

            foreach (var product in catalog)
            {
                Console.WriteLine($"| {product.Category,-15} | {product.Id,3} | {product.Title,-35} | {product.Price,15:#####.00}$ |");
            }

            Console.WriteLine($" TYPE A xx to Add in basket | C to checkout ");
            Console.Write($" >>  ");
            var command = Console.ReadLine();
            //var catalog = catalogLoader.LoadCatalog();

            //foreach (var product in catalog)
            //{
            //    Console.WriteLine($"{product.Id} \t\t{product.Title}\t\t\t\t\t\t{product.Amount}");
            //}

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
