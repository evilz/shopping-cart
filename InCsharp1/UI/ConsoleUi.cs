using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsharpEvolve.Command;

namespace CsharpEvolve
{
    public class ConsoleUi
    {
        private readonly TextWriter _output;

        public ConsoleUi(TextWriter output)
        {
            _output = output;
        }

        public void DisplayCatalog(Catalog catalog)
        {
            foreach (var product in catalog)
            {
                _output.WriteLine($"| {product.Category,-15} | {product.Id,3} | {product.Title,-35} | {product.Price,15:#####.00}$ |");
            }
        }

        public void DisplayShoppingCart(ShoppingCart cart)
        {
            var sb = cart.Aggregate(new StringBuilder(new string('-', 66) + "\n"),
                (builder, product) => builder.AppendLine($"| {product.Id,5} | {product.Title,-35} | {product.Price,15:#####.00}$ |"));
            sb.AppendLine(new string('-', 66));
            sb.AppendLine($"TOTAL : {cart.TotalAmount,55:#####.00}$");
            _output.WriteLine(sb.ToString());
        }

        public void DisplayCounter(int count)
        {
            _output.WriteLine($"Loading... {count}");
        }

        public ConsoleUi ClearScreen()
        {
            Console.Clear();
            return this;
        }

        public void DisplayAvailableCommands(IEnumerable<ICommand> commands)
        {

            _output.WriteLine($" TYPE :");
            foreach (var command in commands)
            {
                _output.WriteLine(command.Help);
            }
            _output.Write($" >>  ");
        }
    }
}