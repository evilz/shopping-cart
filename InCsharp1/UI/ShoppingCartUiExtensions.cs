using System.Linq;
using System.Text;

namespace CsharpEvolve
{
    public static class ShoppingCartUiExtensions
    {
        public static string Print(this ShoppingCart cart)
        {
            var sb = cart.Aggregate(new StringBuilder(new string('-',60) + "\n"),
                            (builder, product) => builder.AppendLine($"{product.Title:15} | {product.Price}"));
            sb.AppendLine(new string('-', 60));
            sb.AppendLine($"\t\t\t\t\tTOTAL : {cart.TotalAmount}");
            return sb.ToString();
        }
    }
}
