using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public class MarcaModel
    {
        private int _MarcaID;
        private string _Marca;
        private int _EstadoId;
        private string _Estado;

        public int MarcaID { get => _MarcaID; set => _MarcaID = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public int EstadoId { get => _EstadoId; set => _EstadoId = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
    }
}
