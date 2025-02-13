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
using System.Windows.Media.Media3D;

namespace ControlEdificioF.Services.Contexts
{
    /// <summary>
    /// Contexto de base de datos para operaciones CRUD de modelos de equipos
    /// Implementa la interfaz genérica IBaseContext para operaciones estándar
    /// </summary>
    internal class ModeloContext : DbContextMySql, IBaseContext<ModeloModel>
    {
        /// <summary>
        /// Constructor que inicializa el contexto con la configuración de base de datos
        /// </summary>
        public ModeloContext(ConfigDb configDb) : base(configDb)
        {
        }

        /// <summary>
        /// Crea un nuevo registro de modelo en la base de datos
        /// </summary>
        /// <param name="modelo">Datos del modelo a crear</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Create(ModeloModel modelo)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPCreateModelo";
                    command.Parameters.AddWithValue("m_modelo", modelo.Modelo);
                    command.Parameters.AddWithValue("m_estadoid", modelo.EstadoId);
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
        /// Obtiene todos los modelos desde la vista vmodelo
        /// </summary>
        /// <returns>Colección observable de modelos o colección vacía en caso de error</returns>
        public ObservableCollection<ModeloModel> Read()
        {
            ObservableCollection<ModeloModel> lstCarrera = new ObservableCollection<ModeloModel>();
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "vmodelo";
                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstCarrera.Add(new ModeloModel
                            {
                                ModeloID = int.Parse(ddr["Id"].ToString()),
                                Modelo = ddr["Modelo"].ToString(),
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
        /// Actualiza los datos de un modelo existente
        /// </summary>
        /// <param name="modelo">Datos actualizados del modelo</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Update(ModeloModel modelo)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPUpdateModelo";
                    command.Parameters.AddWithValue("m_modeloid", modelo.ModeloID);
                    command.Parameters.AddWithValue("m_modelo", modelo.Modelo);
                    command.Parameters.AddWithValue("m_estadoid", modelo.EstadoId);
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
        /// Elimina un modelo específico de la base de datos
        /// </summary>
        /// <param name="modelo">Modelo que contiene el ID del modelo a eliminar</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Delete(ModeloModel modelo)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPDeleteModelo";
                    command.Parameters.AddWithValue("m_modeloid", modelo.ModeloID);
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
