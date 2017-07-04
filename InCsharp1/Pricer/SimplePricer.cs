using System.Linq;

namespace CsharpEvolve
{
    public class SimplePricer : IShoppingCartPricer
    {
        public (double cartTotal, double discount, double finalTotal) ComputePrice(IShoppingCart shoppingCart)
        {
            var cartTotal = shoppingCart.Sum(p => p.Price);
            return (cartTotal, 0.0, cartTotal);
        }
    }
}