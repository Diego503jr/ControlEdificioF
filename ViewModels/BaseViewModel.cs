using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.ViewModels
{
    /// <summary>
    /// Clase base que implementa notificación de cambios de propiedades para patrones MVVM
    /// </summary>
    internal class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Evento que notifica cuando una propiedad cambia su valor
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Método protegido que dispara la notificación de cambio para una propiedad específica
        /// </summary>
        /// <param name="propertyname">Nombre de la propiedad que ha cambiado</param>
        protected virtual void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
