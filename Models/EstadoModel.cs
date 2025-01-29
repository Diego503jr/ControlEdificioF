using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public class EstadoModel
    {
        private int _EstadoID;
        private string _Estado;

        public int EstadoID { get => _EstadoID; set => _EstadoID = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
    }
}
