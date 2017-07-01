namespace CsharpEvolve.Order
{
    public class PaypalOrder : Order
    {
        public PaypalInfo PayPalInfo { get; }

        public PaypalOrder(ShoppingCart shoppingCart, PaypalInfo payPalInfo) : base(shoppingCart)
        {
            PayPalInfo = PayPalInfo;
        }
    }
}