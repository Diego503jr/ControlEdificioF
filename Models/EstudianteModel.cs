using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Model
{
    public class StudentModel
    {
        private int _EstudianteID;
        private string _Nombre_Estudiante;
        private string _Apellido_Estudiante;
        private int _Carnet_Estudiante;

        public int EstudianteID
        {
            get => _EstudianteID;

            set => _EstudianteID = value;
        }

        public string NombreEstudiante
        {
            get => _Nombre_Estudiante;

            set
            {
                if (_Nombre_Estudiante != value)
                {
                    _Nombre_Estudiante = value;
                }
            }
        }

        public string ApellidoEstudiante
        {
            get => _Apellido_Estudiante;

            set
            {
                if (_Apellido_Estudiante != value)
                {
                    _Apellido_Estudiante = value;
                }
            }
        }

        public int CarnetEstudiante
        {
            get => _Carnet_Estudiante;

            set => _Carnet_Estudiante = value;
        }
    }
}
