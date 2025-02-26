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
    /// Contexto de base de datos para operaciones CRU de detalles de préstamo de herramientas
    /// Implementa la interfaz genérica ICRU para operaciones estándar sin Delete
    /// </summary>
    internal class DetallePrestamoHerramientaContext : DbContextMySql, ICRU<DetallePrestamoHerramientaModel>
    {
        /// <summary>
        /// Constructor que inicializa el contexto con la configuración de base de datos
        /// </summary>
        public DetallePrestamoHerramientaContext(ConfigDb configDb) : base(configDb) { }

        /// <summary>
        /// Crea un nuevo registro de detalle de préstamo de herramienta en la base de datos
        /// </summary>
        /// <param name="detallePrestamoHerramienta">Datos del detalle de préstamo de herramienta a crear</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Create(DetallePrestamoHerramientaModel detallePrestamoHerramienta)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPCreateDetallePrestamoHerramienta";
                    command.Parameters.AddWithValue("dph_prestamoherramientaid", detallePrestamoHerramienta.Prestamo_HerramientaID);
                    command.Parameters.AddWithValue("dph_herramientaid", detallePrestamoHerramienta.HerramientaID);
                    command.Parameters.AddWithValue("dph_cantidad", detallePrestamoHerramienta.Cantidad);
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
        /// Obtiene todos los detalles de préstamo de herramientas desde la vista vdetalleprestamoherramienta
        /// </summary>
        /// <returns>Colección observable de detalles de préstamo de herramientas o colección vacía en caso de error</returns>
        public ObservableCollection<DetallePrestamoHerramientaModel> Read()
        {
            ObservableCollection<DetallePrestamoHerramientaModel> lstDPH = new ObservableCollection<DetallePrestamoHerramientaModel>();
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM vdetalleprestamoherramienta";
                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstDPH.Add(new DetallePrestamoHerramientaModel
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
            return lstDPH;
        }

        /// <summary>
        /// Actualiza los datos de un detalle de préstamo de herramienta existente
        /// </summary>
        /// <param name="detallePrestamoHerramienta">Datos actualizados del detalle de préstamo de herramienta</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Update(DetallePrestamoHerramientaModel detallePrestamoHerramienta)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPUpdateDetallePrestamoHerramienta";
                    command.Parameters.AddWithValue("dph_detalleprestamoherramientaid", detallePrestamoHerramienta.Detalle_Prestamo_HerramientaID);
                    command.Parameters.AddWithValue("dph_prestamoherramientaid", detallePrestamoHerramienta.Prestamo_HerramientaID);
                    command.Parameters.AddWithValue("dph_herramientaid", detallePrestamoHerramienta.HerramientaID);
                    command.Parameters.AddWithValue("dph_cantidad", detallePrestamoHerramienta.Cantidad);
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
