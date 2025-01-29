using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public class EstadoPrestamoModel
    {
        private int _Estado_PrestamoID;
        private string _Estado_Prestamo;

        public int Estado_PrestamoID { get => _Estado_PrestamoID; set => _Estado_PrestamoID = value; }
        public string Estado_Prestamo { get => _Estado_Prestamo; set => _Estado_Prestamo = value; }
    }
}
