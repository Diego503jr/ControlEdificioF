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
        private int _CarreraId;
        private string _Carrera;
        private int _EstadoID;
        private string _Estado;

        public int EstudianteID { get => _EstudianteID; set => _EstudianteID = value; }
        public string Nombre_Estudiante { get => _Nombre_Estudiante; set => _Nombre_Estudiante = value; }
        public string Apellido_Estudiante { get => _Apellido_Estudiante; set => _Apellido_Estudiante = value; }
        public int Carnet_Estudiante { get => _Carnet_Estudiante; set => _Carnet_Estudiante = value; }
        public int CarreraId { get => _CarreraId; set => _CarreraId = value; }
        public string Carrera { get => _Carrera; set => _Carrera = value; }
        public int EstadoID { get => _EstadoID; set => _EstadoID = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
    }
}
