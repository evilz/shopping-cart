using System.Linq;

namespace CsharpEvolve
{
    public class SimplePricer : IShoppingCartPricer
    {
        public double ComputePrice(IShoppingCart shoppingCart)
        {
            return shoppingCart.Sum(p => p.Price);
        }
    }
}