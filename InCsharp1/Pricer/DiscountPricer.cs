using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsharpEvolve.Order;

namespace CsharpEvolve.Pricer
{
    public class DiscountPricer : IShoppingCartPricer
    {
        public (double cartTotal, double discount, double finalTotal) ComputePrice(IShoppingCart shoppingCart)
        {
            var discount = 0.0;
            foreach (var t in shoppingCart.GroupByProduct())
            {
                if (t.product.Category == "Confection") {discount += t.product.Price * 0.10; continue;}
                if (t.count > 3) {discount += t.product.Price; continue;}
            }

            var cartTotal = shoppingCart.Sum(p => p.Price);
            // C# 7.0 : Digit separators
            if (cartTotal >= 1_000)
            {
                discount += cartTotal * .10;
            }
            
            return  (cartTotal: cartTotal, discount: discount, finalTotal: cartTotal - discount);
        }
    }
    
}
