using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public class HerramientaModel
    {
        private int _HerramientaID;
        private int _Codigo_Barra_Herramienta;
        private string _Nombre_Herramienta;
        private string _Descripcion_Herramienta;
        private int _Cantidad_Disponible;
        private int _ModeloID;
        private string _Modelo;
        private int _MarcaID;
        private string _Marca;
        private int _EstadoID;
        private string _Estado;


        public int HerramientaID { get => _HerramientaID; set => _HerramientaID = value; }
        public int Codigo_Barra_Herramienta { get => _Codigo_Barra_Herramienta; set => _Codigo_Barra_Herramienta = value; }
        public string Nombre_Herramienta { get => _Nombre_Herramienta; set => _Nombre_Herramienta = value; }
        public string Descripcion_Herramienta { get => _Descripcion_Herramienta; set => _Descripcion_Herramienta = value; }
        public int Cantidad_Disponible { get => _Cantidad_Disponible; set => _Cantidad_Disponible = value; }
        public int ModeloID { get => _ModeloID; set => _ModeloID = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public int MarcaID { get => _MarcaID; set => _MarcaID = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public int EstadoID { get => _EstadoID; set => _EstadoID = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
    }
}
