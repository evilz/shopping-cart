using System;
using System.Linq;
using System.Threading.Tasks;
using CsharpEvolve.Command;

namespace CsharpEvolve
{

    public class Program
    {
        private static ConsoleUi UI;
        private static ICatalogLoader CatalogLoader;
        private static CommandParser CommandParser;
        private static CommandManager CommandManager;

        public static void Main()
        {
            // Configure Application (config file + service init)
            UI = new ConsoleUi(Console.Out);
            CatalogLoader = new CatalogLoaderWithCache(new CatalogLoader());

            var shoppingCart = new ShoppingCart(new SimplePricer());

            CommandParser = new CommandParser(Console.In);
            CommandManager = new CommandManager(UI,CatalogLoader,shoppingCart );
            
            MainLoop().Wait();
        }

        private static async Task MainLoop()
        {
            var availablesCommands = CommandManager.InitialCommands;

            while (availablesCommands.Any())
            {
                UI.DisplayAvailableCommands(availablesCommands);

                if (CommandParser.TryParse(availablesCommands,out ICommand command))
                {
                    availablesCommands = await CommandManager.ExecuteCommand(command);
                }
            }
        }
    }
}
