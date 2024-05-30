using Checkers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Checkers.Commands
{
    class RelayCommand : ICommand
    {
        private Action<Cell> commandTask;

        public RelayCommand(Action<Cell> workToDo)
        {
            commandTask = workToDo;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            commandTask(parameter as Cell);
        }
    }
}
