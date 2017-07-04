namespace CsharpEvolve
{
    public interface IShoppingCartPricer
    {
        (double cartTotal, double discount, double finalTotal) ComputePrice(IShoppingCart shoppingCart);
    }
}