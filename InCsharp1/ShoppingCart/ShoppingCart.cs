using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CsharpEvolve
{
    public class ShoppingCart : IShoppingCart 
    {
        private readonly IShoppingCartPricer _pricer;

        public ShoppingCart(IShoppingCartPricer pricer) : this(pricer, new List<Product>())
        {
           
        }

        private IList<Product> _items;

        public ShoppingCart(IShoppingCartPricer pricer, IEnumerable<Product> items)
        {
            _pricer = pricer;
            _items = new List<Product>(items);
        }
        public IShoppingCart AddItem(Product item)
        {
            _items.Add(item);
            return this;
        }

        public IShoppingCart RemoveItem(ProductId id)
        {
            var removedItem = _items.FirstOrDefault(p => Equals(p.Id, id));
            if (removedItem != null)
            {
                _items.Remove(removedItem);
            }
            return this;
        }

        public IShoppingCart Clear()
        {
            _items.Clear();
            return this;
        }

        public double TotalAmount => _pricer.ComputePrice(this);
        public IEnumerator<Product> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
}