using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S7_Filmoteka.Commands
{
    public interface ICommands
    {
        public string CommandsHeader { get; }
        public List<BaseCommand> GetCommands();
    }
}
