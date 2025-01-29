using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public class CentroComputoModel
    {
        private int _Centro_ComputoID;
        private string _Centro_Computo;
        private bool _Estado;

        public int Centro_ComputoID { get => _Centro_ComputoID; set => _Centro_ComputoID = value; }
        public string Centro_Computo { get => _Centro_Computo; set => _Centro_Computo = value; }
        public bool Estado { get => _Estado; set => _Estado = value; }
    }
}
