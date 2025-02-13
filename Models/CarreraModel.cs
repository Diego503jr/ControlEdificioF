using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public class CarreraModel
    {
        private int _CarreraID;
        private string _Carrera;
        private string _Estado;
        private int _EstadoId;

        public int CarreraID { get => _CarreraID; set => _CarreraID = value; }
        public string Carrera { get => _Carrera; set => _Carrera = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public int EstadoId { get => _EstadoId; set => _EstadoId = value; }
    }
}
