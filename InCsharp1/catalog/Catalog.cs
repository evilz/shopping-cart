using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CsharpEvolve
{
    public class Catalog : IEnumerable<Product>
    {
        private readonly Dictionary<ProductId, Product> _items;

        public Catalog(IEnumerable<Product> items)
        {
            ProductId KeySelector(Product product) => product.Id;
            Product ElementSelector(Product product) => product;

            _items = items.ToDictionary(KeySelector, ElementSelector);
        }

        public Product this[ProductId productId] => _items[productId];

        public IEnumerator<Product> GetEnumerator()
        {
            return _items.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}