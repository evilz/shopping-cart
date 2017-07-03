using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsharpEvolve.Command
{
    public class ShowCatalogCommand : ICommand
    {
      public async Task Execute(CommandContext commandContext)
        {
            var counter = 0;
            var progress = new Progress<Product>(p =>
            {
                counter++;
                commandContext.Ui.ClearScreen().DisplayCounter(counter);
            });

            commandContext.Ui.ClearScreen();
            var catalog = await commandContext.Loader.LoadCatalog(progress);
            commandContext.Ui.ClearScreen().DisplayCatalog(catalog);
        }

        public string Help => "C : Show catalog";
        public bool TryParse(string input)
        {
            return Regex.IsMatch(input, "C");
        }
        
    }
}
