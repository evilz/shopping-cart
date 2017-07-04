using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpEvolve.Order
{
    public abstract class Order
    {
        private readonly ShoppingCart _shoppingCart;

        protected Order(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;

            OrderItems = _shoppingCart.GroupBy(product => product)
                .Select(g => new OrderItem(g.Key, g.Count()));

            TotalAmount = _shoppingCart.TotalAmount;
        }
        
        public IEnumerable<OrderItem> OrderItems {get;}

        public (double cartTotal, double discount, double finalTotal) TotalAmount { get; }

    }
}
