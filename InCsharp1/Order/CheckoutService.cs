using System.Threading.Tasks;

namespace CsharpEvolve.Order
{
    public static class CheckoutService {

        public static async Task<CreditCardOrder> CheckoutWithCreditCard(this ShoppingCart shoppingCart, CreditCardInfo cardInfo)
        {
            await Task.Delay(3000); // simulate Card info verification
            return new CreditCardOrder(shoppingCart, cardInfo);
        }
        public static async Task<PaypalOrder> CheckoutWithCreditCard(this ShoppingCart shoppingCart, PaypalInfo paypalInfo)
        {
            await Task.Delay(3000); // simulate pappal info verification
            return new PaypalOrder(shoppingCart, paypalInfo);
        }
    }
}