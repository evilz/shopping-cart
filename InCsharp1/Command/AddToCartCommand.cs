using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsharpEvolve.Command
{
    public class AddToCartCommand : ICommand
    {
        private ProductId _productId;
        public async Task Execute(CommandContext commandContext)
        {
            var catalog = await commandContext.Loader.LoadCatalog();
            var product = catalog[_productId]; // ADD TRY/CATCH !
            commandContext.ShoppingCart.AddItem(product);

            commandContext.Ui.ClearScreen().DisplayShoppingCart(commandContext.ShoppingCart);
        }

        public string Help => "A xx : Add xx product in cart";

        public bool TryParse(string input)
        {
            var match = Regex.Match(input, "A (\\d+)");
            if (!match.Success) return false;

            _productId = new ProductId(match.Groups[1].Value);
            return true;
        }
    }


}
