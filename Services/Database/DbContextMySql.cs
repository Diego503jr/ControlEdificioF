using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Services.Database
{
    /// <summary>
    /// Clase base abstracta que proporciona funcionalidad básica para conexiones MySQL
    /// </summary>
    internal abstract class DbContextMySql : IDbContextMySql
    {
        // Configuración de base de datos inyectada a través del constructor
        protected readonly ConfigDb _configDb;

        /// <summary>
        /// Constructor que recibe la configuración necesaria para establecer conexiones
        /// </summary>
        protected DbContextMySql(ConfigDb configDb)
        {
            _configDb = configDb;
        }

        /// <summary>
        /// Crea y abre una nueva conexión MySQL usando la configuración proporcionada
        /// </summary>
        /// <returns>Conexión MySQL activa y abierta</returns>
        public MySqlConnection CreateConnection()
        {
            var connection = new MySqlConnection(_configDb.GetConnectionString());
            connection.Open();
            return connection;
        }
    }
}
