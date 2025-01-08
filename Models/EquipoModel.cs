using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public class EquipoModel
    {
        private int _Codigo_Barra_Equipo;
        private string _Nombre_Equipo;
        private int _Estado_EquipoID;
        private int _Centro_ComputoID;

        public int CodigoBarraEquipo
        {
            get => _Codigo_Barra_Equipo;

            set => _Codigo_Barra_Equipo = value;
        }

        public string NombreEquipo
        {
            get => _Nombre_Equipo;

            set
            {
                if (_Nombre_Equipo != value)
                {
                    _Nombre_Equipo = value;
                }
            }
        }

        public int EstadoEquipoID
        {
            get => _Estado_EquipoID;

            set => _Estado_EquipoID = value;
        }

        public int CentroComputoID
        {
            get => _Centro_ComputoID;

            set => _Centro_ComputoID = value;
        }
    }
}
