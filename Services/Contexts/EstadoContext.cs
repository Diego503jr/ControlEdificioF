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
    /// Contexto de base de datos para operaciones CRUD de estados
    /// Implementa la interfaz genérica IBaseContext para operaciones estándar
    /// </summary>
    internal class EstadoContext : DbContextMySql, ICRU<EstadoModel>
    {
        /// <summary>
        /// Constructor que inicializa el contexto con la configuración de base de datos
        /// </summary>
        public EstadoContext(ConfigDb config) : base(config) { }

        /// <summary>
        /// Crea un nuevo registro de estado en la base de datos
        /// </summary>
        /// <param name="estado">Datos del estado a crear</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Create(EstadoModel estado)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPCreateEstado";
                    command.Parameters.AddWithValue("e_estado", estado.Estado);
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
        /// Obtiene todos los estados desde la vista vestado
        /// </summary>
        /// <returns>Colección observable de estados o colección vacía en caso de error</returns>
        public ObservableCollection<EstadoModel> Read()
        {
            ObservableCollection<EstadoModel> lstEstado = new ObservableCollection<EstadoModel>();
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SELECT * FROM vestado";
                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstEstado.Add(new EstadoModel
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
            return lstEstado;
        }

        /// <summary>
        /// Actualiza los datos de un estado existente
        /// </summary>
        /// <param name="estado">Datos actualizados del estado</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Update(EstadoModel estado)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPUpdateEstado";
                    command.Parameters.AddWithValue("e_estadoid", estado.EstadoID);
                    command.Parameters.AddWithValue("e_estado", estado.Estado);
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
        /// Método Delete no Permitido
        /// </summary>
        /// <param name="estadoModel">Modelo del estado</param>
        public int Delete(EstadoModel estadoModel)
        {
            throw new NotImplementedException("Eliminar no esta permitido en esta entidad");
        }
    }
}
