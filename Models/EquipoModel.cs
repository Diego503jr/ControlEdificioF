using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public class EquipoModel
    {
        private int _EquipoID;
        private int _Equipo;
        private int _ModeloID;
        private string _Codigo;
        private string _Serie;
        private string _Microprocesador;
        private string _RAM;
        private string _Disco;
        private string _Detalle;
        private int _EstadoID;
        private int _Centro_ComputoID;

        public int EquipoID { get => _EquipoID; set => _EquipoID = value; }
        public int Equipo { get => _Equipo; set => _Equipo = value; }
        public int ModeloID { get => _ModeloID; set => _ModeloID = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Microprocesador { get => _Microprocesador; set => _Microprocesador = value; }
        public string RAM { get => _RAM; set => _RAM = value; }
        public string Disco { get => _Disco; set => _Disco = value; }
        public string Detalle { get => _Detalle; set => _Detalle = value; }
        public int EstadoID { get => _EstadoID; set => _EstadoID = value; }
        public int Centro_ComputoID { get => _Centro_ComputoID; set => _Centro_ComputoID = value; }
    }
}
