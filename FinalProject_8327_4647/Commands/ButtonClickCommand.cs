using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalProject_8327_4647.Commands
{
    class ButtonClickCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var viewModel = (CommandViewModel)parameter;
            //viewModel.ShowMessagebox("Hello decoupled command!");
        }
    }
}
