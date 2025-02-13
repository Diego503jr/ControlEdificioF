using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ControlEdificioF.Services.Commands
{
    /// <summary>
    /// Implementación del patrón Command que facilita la vinculación entre la UI y la lógica de negocio
    /// </summary>
    internal class RelayCommand : ICommand
    {
        /// <summary>
        /// Delegado que encapsula la acción a ejecutar
        /// </summary>
        private readonly Action<object> _execute;

        /// <summary>
        /// Delegado opcional que determina si la acción puede ejecutarse
        /// </summary>
        private readonly Predicate<object> _canExecute;

        /// <summary>
        /// Constructor que inicializa el comando con la acción a ejecutar y una condición de ejecución
        /// </summary>
        /// <param name="execute">Acción que se ejecutará cuando se invoque el comando</param>
        /// <param name="canExecute">Predicado que determina si el comando puede ejecutarse</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Constructor simplificado que inicializa el comando sin restricciones de ejecución
        /// </summary>
        /// <param name="execute">Acción que se ejecutará cuando se invoque el comando</param>
        public RelayCommand(Action<object> execute) : this(execute, null)
        { }

        /// <summary>
        /// Determina si el comando puede ejecutarse en su estado actual
        /// </summary>
        /// <returns>true si no hay predicado de validación o si este retorna true</returns>
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// Ejecuta la acción asociada al comando
        /// </summary>
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        /// <summary>
        /// Evento que se dispara cuando cambian las condiciones que determinan
        /// si el comando puede ejecutarse
        /// </summary>
        public event EventHandler? CanExecuteChanged;
    }
}
