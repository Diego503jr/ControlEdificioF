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
        private int _MarcaID;
        private int _ModeloID;
        private int _CategoriaID;
        private int _EstadoID;

        public int HerramientaID
        {
            get => _HerramientaID;

            set => _HerramientaID = value;
        }

        public int CodigoBarraHerramienta
        {
            get => _Codigo_Barra_Herramienta;

            set => _Codigo_Barra_Herramienta = value;
        }

        public string NombreHerramienta
        {
            get => _Nombre_Herramienta;

            set
            {
                if (_Nombre_Herramienta != value)
                {
                    _Nombre_Herramienta = value;
                }
            }
        }

        public string DescripcionHerramienta
        {
            get => _Descripcion_Herramienta;

            set
            {
                if (_Descripcion_Herramienta != value)
                {
                    _Descripcion_Herramienta = value;
                }
            }
        }

        public int CantidadDisponible
        {
            get => _Cantidad_Disponible;

            set => _Cantidad_Disponible = value;
        }

        public int MarcaID
        {
            get => _MarcaID;

            set => _MarcaID = value;
        }

        public int ModeloID
        {
            get => _ModeloID;

            set => _ModeloID = value;
        }

        public int CategoriaID
        {
            get => _CategoriaID;

            set => _CategoriaID = value;
        }

        public int EstadoID
        {
            get => _EstadoID;

            set => _EstadoID = value;
        }
    }
}
