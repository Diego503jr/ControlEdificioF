using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ControlEdificioF.Services.Database
{
        /// <summary>
        /// Implementación de IConfigDb que maneja los parámetros de conexión a base de datos
        /// </summary>
    internal class ConfigDb : IConfigDb
    {
        // Campos privados para almacenar credenciales
        private string _server;
        private string _db;
        private string _user;
        private string _pwd;
    
        // Las propiedades públicas son auto-explicativas por sus nombres
        public string Server { get => _server; set => _server = value; }
        public string Db { get => _db; set => _db = value; }
        public string User { get => _user; set => _user = value; }
        public string Pwd { get => _pwd; set => _pwd = value; }
    
        /// <summary>
        /// Genera la cadena de conexión en formato estándar para SQL Server
        /// usando los parámetros almacenados
        /// </summary>
        /// <returns>Cadena de conexión formateada</returns>
        public string GetConnectionString()
        {
            return $"Server={Server};Database={Db};UId={User};Password={Pwd}";
        }
    }
}
