using System.Collections;
using System.Collections.Generic;

namespace CsharpEvolve
{
    public class Catalog : IEnumerable<Product>
    {
        private readonly IEnumerable<Product> _items;

        public Catalog(IEnumerable<Product> items)
        {
            _items = items;
        }

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