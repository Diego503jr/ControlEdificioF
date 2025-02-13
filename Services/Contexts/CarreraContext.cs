using ControlEdificioF.Models;
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
    /// Contexto de base de datos para operaciones CRUD de carreras universitarias
    /// Implementa la interfaz genérica IBaseContext para operaciones estándar
    /// </summary>
    internal class CarreraContext : DbContextMySql, IBaseContext<CarreraModel>
    {
        /// <summary>
        /// Constructor que inicializa el contexto con la configuración de base de datos
        /// </summary>
        public CarreraContext(ConfigDb configDb) : base(configDb)
        {
        }

        /// <summary>
        /// Crea un nuevo registro de carrera en la base de datos
        /// </summary>
        /// <param name="carrera">Datos de la carrera a crear</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Create(CarreraModel carrera)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPCreateCarrera";
                    command.Parameters.AddWithValue("c_carrera", carrera.Carrera);
                    command.Parameters.AddWithValue("c_estadoid", carrera.EstadoId);
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
        /// Obtiene todas las carreras desde la vista vcarrera
        /// </summary>
        /// <returns>Colección observable de carreras o colección vacía en caso de error</returns>
        public ObservableCollection<CarreraModel> Read()
        {
            ObservableCollection<CarreraModel> lstCarrera = new ObservableCollection<CarreraModel>();
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "vcarrera";
                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstCarrera.Add(new CarreraModel
                            {
                                CarreraID = int.Parse(ddr["Id"].ToString()),
                                Carrera = ddr["Carrera"].ToString(),
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
            return lstCarrera;
        }

        /// <summary>
        /// Actualiza los datos de una carrera existente
        /// </summary>
        /// <param name="carrera">Datos actualizados de la carrera</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Update(CarreraModel carrera)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPUpdateCarrera";
                    command.Parameters.AddWithValue("c_carreraid", carrera.CarreraID);
                    command.Parameters.AddWithValue("c_carrera", carrera.Carrera);
                    command.Parameters.AddWithValue("c_estadoid", carrera.EstadoId);
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
        /// Elimina una carrera específica de la base de datos
        /// </summary>
        /// <param name="carrera">Modelo que contiene el ID de la carrera a eliminar</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Delete(CarreraModel carrera)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPDeleteCarrera";
                    command.Parameters.AddWithValue("c_carreraid", carrera.CarreraID);
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
