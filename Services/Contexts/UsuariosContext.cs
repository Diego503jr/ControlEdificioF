using ControlEdificioF.Model;
using ControlEdificioF.Models;
using ControlEdificioF.Services.Abstractions;
using ControlEdificioF.Services.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace ControlEdificioF.Services.Contexts
{
    /// <summary>
    /// Contexto de base de datos para operaciones CRUD de usuarios
    /// Implementa la interfaz genérica IBaseContext para operaciones estándar
    /// </summary>
    internal class UsuariosContext : DbContextMySql, ICRUD<UsuarioModel>
    {
        /// <summary>
        /// Constructor que inicializa el contexto con la configuración de base de datos
        /// </summary>
        public UsuariosContext(ConfigDb config) : base(config) { }

        /// <summary>
        /// Crea un nuevo registro de usuario en la base de datos
        /// </summary>
        /// <param name="usuario">Datos del usuario a crear, incluyendo información personal y rol</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Create(UsuarioModel usuario)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPCreateUsuario";

                    command.Parameters.AddWithValue("u_nombre", usuario.Nombre_Usuario);
                    command.Parameters.AddWithValue("u_apellido", usuario.Apellido_Usuario);
                    command.Parameters.AddWithValue("u_dui", usuario.DUI_Usuario);
                    command.Parameters.AddWithValue("u_rolid", usuario.RolID);
                    command.Parameters.AddWithValue("u_estadoid", usuario.EstadoID);

                    res = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return res;
        }

        /// <summary>
        /// Obtiene todos los usuarios desde la vista vusuario con sus roles y estados
        /// </summary>
        /// <returns>Colección observable de usuarios o colección vacía en caso de error</returns>
        public ObservableCollection<UsuarioModel> Read()
        {
            ObservableCollection<UsuarioModel> lstUsuario = new ObservableCollection<UsuarioModel>();
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM vusuario";

                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstUsuario.Add(new UsuarioModel
                            {
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lstUsuario;
        }

        /// <summary>
        /// Actualiza los datos de un usuario existente
        /// </summary>
        /// <param name="usuario">Datos actualizados del usuario, incluyendo información personal y rol</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Update(UsuarioModel usuario)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPUpdateUsuario";

                    command.Parameters.AddWithValue("u_usuarioid", usuario.UsuarioID);
                    command.Parameters.AddWithValue("u_nombre", usuario.Nombre_Usuario);
                    command.Parameters.AddWithValue("u_apellido", usuario.Apellido_Usuario);
                    command.Parameters.AddWithValue("u_dui", usuario.DUI_Usuario);
                    command.Parameters.AddWithValue("u_rolid", usuario.RolID);
                    command.Parameters.AddWithValue("u_estadoid", usuario.EstadoID);

                    res = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return res;
        }

        /// <summary>
        /// Elimina un usuario específico de la base de datos
        /// </summary>
        /// <param name="usuario">Modelo que contiene el ID del usuario a eliminar</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Delete(UsuarioModel usuario)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPDeleteUsuario";

                    command.Parameters.AddWithValue("u_usuarioid", usuario.UsuarioID);

                    res = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return res;
        }
    }
}
