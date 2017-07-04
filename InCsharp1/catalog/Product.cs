using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace CsharpEvolve
{
    public class Product : IEquatable<Product>
    {
        public Product(ProductId id, double price, string title, string quantityPerUnit, string category)
        {
            Id = id;
            Price = price;
            Title = title;
            QuantityPerUnit = quantityPerUnit;
            Category = category;
        }
        public ProductId Id { get; }
        public double Price { get; }

        public string Title { get; }

        public string QuantityPerUnit { get; }
        
        public string Category { get; }

        public bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }

        public void Deconstruct(out string title, out string category, out double price)
        {
            title = Title;
            category = Category;
            price = Price;
        }

        public void Deconstruct(out (string title, string category,  double price) tuple )
        {
           tuple = (Title,Category,Price);
        }
    }
}