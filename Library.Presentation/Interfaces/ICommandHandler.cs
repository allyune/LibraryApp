using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Presentation.Interfaces
{
    public interface ICommandHandler
    {
        void ExecuteCommand(string input);
    }
}
