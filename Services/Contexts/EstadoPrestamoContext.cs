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
    /// Contexto de base de datos para operaciones CRUD de estados de préstamo
    /// Implementa la interfaz genérica IBaseContext para operaciones estándar
    /// </summary>
    internal class EstadoPrestamoContext : DbContextMySql, ICRU<EstadoPrestamoModel>
    {
        /// <summary>
        /// Constructor que inicializa el contexto con la configuración de base de datos
        /// </summary>
        public EstadoPrestamoContext(ConfigDb configDb) : base(configDb) { }

        /// <summary>
        /// Crea un nuevo registro de estado de préstamo en la base de datos
        /// </summary>
        /// <param name="estadoPrestamo">Datos del estado de préstamo a crear</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Create(EstadoPrestamoModel estadoPrestamo)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPCreateEstadoPrestamo";
                    command.Parameters.AddWithValue("ep_estadoprestamo", estadoPrestamo.Estado_Prestamo);
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
        /// Obtiene todos los estados de préstamo desde la vista vestadopretamo
        /// </summary>
        /// <returns>Colección observable de estados de préstamo o colección vacía en caso de error</returns>
        public ObservableCollection<EstadoPrestamoModel> Read()
        {
            ObservableCollection<EstadoPrestamoModel> lstEstado = new ObservableCollection<EstadoPrestamoModel>();
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SELECT * FROM vestadopretamo";
                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstEstado.Add(new EstadoPrestamoModel
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
        /// Actualiza los datos de un estado de préstamo existente
        /// </summary>
        /// <param name="estadoPrestamo">Datos actualizados del estado de préstamo</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Update(EstadoPrestamoModel estadoPrestamo)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPUpdateEstadoPrestamo";
                    command.Parameters.AddWithValue("ep_estadoprestamoid", estadoPrestamo.Estado_PrestamoID);
                    command.Parameters.AddWithValue("ep_estadoprestamo", estadoPrestamo.Estado_Prestamo);
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
        /// <param name="estadoPrestamo">Modelo del estado de préstamo</param>
        public int Delete(EstadoPrestamoModel estadoPrestamo)
        {
            throw new NotImplementedException("Eliminar no esta permitido en esta entidad");
        }
    }
}
