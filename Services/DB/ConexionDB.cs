using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ControlEdificioF.Services.DB
{
    public class ConexionDB : IConexionDB
    {
        private readonly ConfigDB _config;
        private MySqlConnection _connection;

        public ConexionDB(ConfigDB config)
        {
            _config = config;
        }

        //Metodo para abrir la conexion DB
        public void ConnectToDB()
        {
            try
            {
                if (_connection == null)
                {
                    _connection = new MySqlConnection(_config.configConexion());
                }

                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                    MessageBox.Show("Se pudo conectar");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"No se pudo conectar a la base de datos. Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Metodo para cerrar la conexion de la DB
        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State != System.Data.ConnectionState.Closed)
                {
                    _connection.Close();
                }
                _connection.Dispose();
            }
        }

    }
}
