using System.Threading.Tasks;

namespace CsharpEvolve.Order
{
    public static class CheckoutService {

        // should be external service
        private static (bool isValid, double discount) IsValidDiscountCode(this ShoppingCart shoppingCart,  string dicountCode)
        {
            double DiscountCalc(double amount)
            {
                return amount * .05;
            }   
            const int binaryMask = 0b1011_1100_1011_0011;
            const int binaryValidator = 0b0000_0000_0000_0011;
            var isValid =(dicountCode.GetHashCode() & binaryMask) == binaryValidator;

            return isValid
                ? (true, DiscountCalc(shoppingCart.TotalAmount.cartTotal))
                : (false, 0);
        }

        public static async Task<CreditCardOrder> CheckoutWithCreditCard(this ShoppingCart shoppingCart, CreditCardInfo cardInfo, string discountCode)
        {
            (var isValid, var dicount) = shoppingCart.IsValidDiscountCode(discountCode);
            if (isValid)
            {
               // apply discount in order ...
            }

            await Task.Delay(3000); // simulate Card info verification
            return new CreditCardOrder(shoppingCart, cardInfo);
        }
        public static async Task<PaypalOrder> CheckoutWithCreditCard(this ShoppingCart shoppingCart, PaypalInfo paypalInfo, string discountCode)
        {
            await Task.Delay(3000); // simulate pappal info verification
            return new PaypalOrder(shoppingCart, paypalInfo);
        }
    }
}