using System;
using System.Globalization;
using System.Linq;

namespace CsharpEvolve
{
    public static class ProductFactories
    {
        // C# 3.0 Extension method
        public static Product ParseAsCsvProduct(this string data, string category = null)
        {
            try
            {
                var parts = data.Split(';').ToArray();
                var productId = new ProductId(parts[0]);
                var price = Double.Parse(parts[3], CultureInfo.InvariantCulture);
                var title = parts[1];
                var quantityPerUnit = parts[2];
                category= category ?? string.Empty;

                return new Product(productId, price, title, quantityPerUnit, category);
            }
            catch (Exception e)
            {
                throw new Exception($"Error in line {data}", e);
            }

        }
    }
}
