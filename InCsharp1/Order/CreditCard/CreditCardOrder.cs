namespace CsharpEvolve.Order
{
    public class CreditCardOrder : Order
    {
        public CreditCardInfo CardInfo { get; }

        public CreditCardOrder(ShoppingCart shoppingCart, CreditCardInfo cardInfo) : base(shoppingCart)
        {
            CardInfo = cardInfo;
        }
    }
}