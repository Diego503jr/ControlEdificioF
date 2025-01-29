using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Model
{
    public class UsuarioModel
    {
        private int _UsuarioID;
        private string _Nombre_Usuario;
        private string _Apellido_Usuario;
        private string _DUI_Usuario;
        private int _RolID;
        private int _EstadoID;

        public int UsuarioID { get => _UsuarioID; set => _UsuarioID = value; }
        public string Nombre_Usuario { get => _Nombre_Usuario; set => _Nombre_Usuario = value; }
        public string Apellido_Usuario { get => _Apellido_Usuario; set => _Apellido_Usuario = value; }
        public string DUI_Usuario { get => _DUI_Usuario; set => _DUI_Usuario = value; }
        public int RolID { get => _RolID; set => _RolID = value; }
        public int EstadoID { get => _EstadoID; set => _EstadoID = value; }
    }
}
