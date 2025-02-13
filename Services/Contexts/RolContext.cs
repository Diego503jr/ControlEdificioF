using ControlEdificioF.Models;
using ControlEdificioF.Services.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Services.Contexts
{
    /// <summary>
    /// Contexto de base de datos específico para operaciones CRUD de roles
    /// Hereda la funcionalidad base de conexión MySQL
    /// </summary>
    internal class RolContext : DbContextMySql, IBaseContext<RolModel>
    {
        /// <summary>
        /// Constructor que requiere configuración de base de datos para inicializar la conexión base
        /// </summary>
        public RolContext(ConfigDb configDb) : base(configDb)
        {
        }

        /// <summary>
        /// Crea un nuevo rol en la base de datos
        /// </summary>
        /// <param name="rolModel">Modelo con la información del rol a crear</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Create(RolModel rol)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPCreateRol";

                    command.Parameters.AddWithValue("r_rol", rol.Rol);
                    command.Parameters.AddWithValue("r_estadoid", rol.EstadoId);

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
        /// Obtiene la lista completa de roles desde la base de datos
        /// </summary>
        /// <returns>Colección observable de roles o colección vacía en caso de error</returns>
        public ObservableCollection<RolModel> Read()
        {
            ObservableCollection<RolModel> lstRol = new ObservableCollection<RolModel>();
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "vrol";

                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstRol.Add(new RolModel
                            {
                                RolID = int.Parse(ddr["Id"].ToString()),
                                Rol = ddr["Rol"].ToString(),
                                Estado = ddr["Estado"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lstRol;
        }

        /// <summary>
        /// Actualiza la información de un rol existente
        /// </summary>
        /// <param name="rolModel">Modelo con la información actualizada del rol</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Update(RolModel rol)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPUpdateRol";

                    command.Parameters.AddWithValue("r_rolid", rol.RolID);
                    command.Parameters.AddWithValue("r_rol", rol.Rol);
                    command.Parameters.AddWithValue("r_estadoid", rol.EstadoId);

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
        /// Elimina un rol específico de la base de datos
        /// </summary>
        /// <param name="rolModel">Modelo que contiene el ID del rol a eliminar</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Delete(RolModel rol)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPDeleteRol";

                    command.Parameters.AddWithValue("r_rolid", rol.RolID);

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
