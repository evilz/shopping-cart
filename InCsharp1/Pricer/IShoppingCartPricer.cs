namespace CsharpEvolve
{
    public interface IShoppingCartPricer
    {
        double ComputePrice(IShoppingCart shoppingCart);
    }
}