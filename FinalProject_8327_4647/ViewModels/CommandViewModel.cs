using FinalProject_8327_4647.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalProject_8327_4647
{
    class CommandViewModel
    {
        public ICommand buttonClickCommand
        {
            get
            {
                return new ButtonClickCommand();
            }
        }
    }
}
