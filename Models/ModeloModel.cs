using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public  class ModeloModel
    {
        private int _ModeloID;
        private string _Modelo;

        public int ModeloID { get => _ModeloID; set => _ModeloID = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
    }
}
