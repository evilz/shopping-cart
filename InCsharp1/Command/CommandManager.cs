using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolve.Command
{
    public class CommandManager
    {
        private CommandContext _commandContext;

        private readonly ICommand ShowCatalogCmd = new ShowCatalogCommand();
        private readonly ICommand ExitCmd = new ExitCommand();
        private readonly ICommand AddToCartCmd = new AddToCartCommand();



        private Dictionary<Type, ICommand[]> _nextCommands;
        private Dictionary<Type, ICommand> _allCommands;

        public ICommand[] InitialCommands => new[] { ShowCatalogCmd, ExitCmd };

        public CommandManager(ConsoleUi ui, ICatalogLoader catalogLoader, ShoppingCart shoppingCart)
        {
           _nextCommands = new Dictionary<Type, ICommand[]>
            {
                { ShowCatalogCmd.GetType(), new[]{ AddToCartCmd, ExitCmd } },
                { ExitCmd.GetType(), new ICommand[0] },
                { AddToCartCmd.GetType(), new[]{ ShowCatalogCmd, AddToCartCmd, ExitCmd } },
            };

            _commandContext = new CommandContext(ui, catalogLoader, shoppingCart);
        }

        public async Task<ICommand[]> ExecuteCommand(ICommand command)
        {
            await command.Execute(_commandContext);
            return _nextCommands[command.GetType()];
        }
    }
}
