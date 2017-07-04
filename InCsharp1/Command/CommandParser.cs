using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CsharpEvolve.Command;

namespace CsharpEvolve
{
    public class CommandParser
    {
        private readonly TextReader _input;

        public CommandParser(TextReader input)
        {
            _input = input;
        }

        public bool TryParse(IEnumerable<ICommand> availableCommands, out ICommand command)
        {
            var input = _input.ReadLine().ToUpperInvariant();
            command = availableCommands.FirstOrDefault(c => c.TryParse(input));

            return command != null;
        }
    }
}