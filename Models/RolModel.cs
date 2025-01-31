using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public class RolModel
    {
        private int _RolID;
        private string _Rol;
        private int _EstadoId;
        private string _Estado;

        public int RolID { get => _RolID; set => _RolID = value; }
        public string Rol { get => _Rol; set => _Rol = value; }
        public int EstadoId { get => _EstadoId; set => _EstadoId = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
    }
}
