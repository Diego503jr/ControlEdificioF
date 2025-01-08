using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Model
{
    public class DocenteModel
    {
        private int _DocenteID;
        private string _Nombre_Docente;
        private int _DUI_Docente;

        public int DocenteID
        {
            get => _DocenteID;

            set => _DocenteID = value;
        }

        public string NombreDocente
        {
            get => _Nombre_Docente;

            set
            {
                if (_Nombre_Docente != value)
                {
                    _Nombre_Docente = value;
                }
            }
        }

        public int DUIDocente
        {
            get => _DUI_Docente;

            set => _DUI_Docente = value;
        }
    }
}
