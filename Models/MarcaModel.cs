using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public class MarcaModel
    {
        private int _MardaID;
        private string _Marca;

        public int MardaID { get => _MardaID; set => _MardaID = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
    }
}
