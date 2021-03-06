using System.Collections.Generic;

namespace CsharpEvolve
{
    public interface IShoppingCart : IEnumerable<Product>
    {
        IShoppingCart AddItem(Product product);
        IShoppingCart RemoveItem(ProductId id);
        IShoppingCart Clear();
        (double cartTotal, double discount, double finalTotal) TotalAmount { get; }
    }
}