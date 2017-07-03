using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CsharpEvolve.Command
{
    public class ExitCommand : ICommand
    {
        public Task Execute(CommandContext commandContext)
        {
            return Task.FromResult(0);
        }

        public string Help => "Q : To quit";
        public bool TryParse(string input)
        {
            return Regex.IsMatch(input, "Q");
        }
    }
}