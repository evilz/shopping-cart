namespace CsharpEvolve.Command
{
    public class CommandContext
    {
        public ConsoleUi Ui { get; }
        public ICatalogLoader Loader { get; }

        public ShoppingCart ShoppingCart { get; }

        public CommandContext(ConsoleUi ui, ICatalogLoader catalogLoader, ShoppingCart shoppingCart)
        {
            Ui = ui;
            Loader = catalogLoader;
            ShoppingCart = shoppingCart;
        }
    }
}