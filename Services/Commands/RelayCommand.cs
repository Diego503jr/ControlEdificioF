using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ControlEdificioF.Services.Commands
{
    internal class RelayCommand : ICommand
    {
        //Declaracion de delegados para las interacciones con la UI
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute) : this(execute, null)
        { }

        //Metodo para verificar si se  puede realizar el evento
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        //Metodo para realizar el evento
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        //Evento que se produce cuando hay cambios que afectan al comando que debe ejecutarse
        public event EventHandler? CanExecuteChanged;
    }
}
