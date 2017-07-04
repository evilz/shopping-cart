using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolve
{
    public static class ShoppingCartExt
    {
        public static IEnumerable<(Product product, int count)> GroupByProduct(this IShoppingCart shoppingCart)
        {
            return shoppingCart.GroupBy(product => product)
                .Select(g => new ValueTuple<Product, int>( g.Key, g.Count()));
        }
    }
}
