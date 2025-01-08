using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Model
{
    public class TecnicoModel
    {
        private int _TecnicoID;
        private string _Nombre_Tecnico;
        private int _Carnet_Tecnico;

        public int TecnicoID 
        {
            get => _TecnicoID;

            set => _TecnicoID = value;
        }

        public string NombreTecnico 
        {
            get => _Nombre_Tecnico;

            set
            {
                if (_Nombre_Tecnico != value)
                {
                    _Nombre_Tecnico = value;
                }
            }
        }

        public int CarnetTecnico 
        {
            get => _Carnet_Tecnico;

            set => _Carnet_Tecnico = value;
        }
    }
}
