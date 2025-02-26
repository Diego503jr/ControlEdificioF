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

namespace ControlEdificioF.Services.Contexts
{
    /// <summary>
    /// Contexto de base de datos para operaciones CRUD de equipos
    /// Implementa la interfaz genérica ICRUD para operaciones estándar
    /// </summary>
    internal class EquipoContext : DbContextMySql, ICRUD<EquipoModel>
    {
        /// <summary>
        /// Constructor que inicializa el contexto con la configuración de base de datos
        /// </summary>
        public EquipoContext(ConfigDb configDb) : base(configDb)
        {
        }

        /// <summary>
        /// Crea un nuevo registro de equipo en la base de datos
        /// </summary>
        /// <param name="equipo">Datos del equipo a crear</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Create(EquipoModel equipo)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPCreateEquipo";

                    command.Parameters.AddWithValue("e_equipo", equipo.Equipo);
                    command.Parameters.AddWithValue("e_modeloid", equipo.ModeloID);
                    command.Parameters.AddWithValue("e_codigo", equipo.Codigo);
                    command.Parameters.AddWithValue("e_serie", equipo.Serie);
                    command.Parameters.AddWithValue("e_microprocesador", equipo.Microprocesador);
                    command.Parameters.AddWithValue("e_ram", equipo.RAM);
                    command.Parameters.AddWithValue("e_disco", equipo.Disco);
                    command.Parameters.AddWithValue("e_detalles", equipo.Detalle);
                    command.Parameters.AddWithValue("e_estadoid", equipo.EstadoID);
                    command.Parameters.AddWithValue("e_centrocomputoid", equipo.Centro_ComputoID);

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
        /// Obtiene todos los equipos desde la vista vequipo
        /// </summary>
        /// <returns>Colección observable de equipos o colección vacía en caso de error</returns>
        public ObservableCollection<EquipoModel> Read()
        {
            ObservableCollection<EquipoModel> lstEquipo = new ObservableCollection<EquipoModel>();
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM vequipo";

                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstEquipo.Add(new EquipoModel
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
            return lstEquipo;
        }

        /// <summary>
        /// Actualiza los datos de un equipo existente
        /// </summary>
        /// <param name="equipo">Datos actualizados del equipo</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Update(EquipoModel equipo)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SPUpdateEquipo";

                    command.Parameters.AddWithValue("e_equipoid", equipo.EquipoID);
                    command.Parameters.AddWithValue("e_equipo", equipo.Equipo);
                    command.Parameters.AddWithValue("e_modeloid", equipo.ModeloID);
                    command.Parameters.AddWithValue("e_codigo", equipo.Codigo);
                    command.Parameters.AddWithValue("e_serie", equipo.Serie);
                    command.Parameters.AddWithValue("e_microprocesador", equipo.Microprocesador);
                    command.Parameters.AddWithValue("e_ram", equipo.RAM);
                    command.Parameters.AddWithValue("e_disco", equipo.Disco);
                    command.Parameters.AddWithValue("e_detalles", equipo.Detalle);
                    command.Parameters.AddWithValue("e_estadoid", equipo.EstadoID);
                    command.Parameters.AddWithValue("e_centrocomputoid", equipo.Centro_ComputoID);

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
        /// Elimina un registro de equipo de la base de datos
        /// </summary>
        /// <param name="equipo">Modelo con el ID del equipo a eliminar</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Delete(EquipoModel equipo)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPDeleteEquipo";

                    command.Parameters.AddWithValue("e_equipoid", equipo.EquipoID);

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
