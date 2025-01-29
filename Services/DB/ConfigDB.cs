using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Services.DB
{
    //Configuracion base para establecer los datos para la conexion a la DB
    public class ConfigDB
    {
        private string _serv;
        private string _db;
        private string _user;
        private string _password;


        //Getters y Setters de la Clase configuracion de la DB
        public string Server
        {
            get => _serv;
            set { _serv = value; }
        }

        public string DB
        {
            get => _db;
            set { _db = value; }
        }

        public string User
        {
            get => _user;
            set { _user = value; }
        }

        public string Password
        {
            get => _password;
            set { _password = value; }
        }

        //Metodo para establecer la cadena de conexion
        public string configConexion()
        {
            return $"Server={Server};Database={DB};Uid={User};Pwd={Password}";
        }
    }
}
