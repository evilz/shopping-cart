using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolve.Command
{
    public interface ICommand
    {
        Task Execute(CommandContext commandContext);
        string Help { get; }
        bool TryParse(string input);
    }
}
