using System;
using System.Globalization;
using System.Linq;

namespace CsharpEvolve
{
    public class Product
    {
        public Product(ProductId id, double amount, string title, string quantityPerUnit)
        {
            Id = id;
            Amount = amount;
            Title = title;
            QuantityPerUnit = quantityPerUnit;
        }
        public ProductId Id { get; }
        public double Amount { get; }

        public string Title { get; }

        public string QuantityPerUnit { get; }

        //ProductID,ProductName,QuantityPerUnit,UnitPrice
        public static Product FromCsv(string data)
        {
            try
            {
                var parts = data.Split(';').ToArray();
                return new Product(new ProductId(parts[0]), double.Parse(parts[3],CultureInfo.InvariantCulture), parts[1], parts[2]);
            }
            catch (Exception e)
            {
                throw new Exception($"Ërror in line {data}", e);
            }
           
        }
    }
}