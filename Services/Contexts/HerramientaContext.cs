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
    /// Contexto de base de datos para operaciones CRUD de herramientas
    /// Implementa la interfaz genérica ICRUD para operaciones estándar
    /// </summary>
    internal class HerramientaContext : DbContextMySql, ICRUD<HerramientaModel>
    {
        /// <summary>
        /// Constructor que inicializa el contexto con la configuración de base de datos
        /// </summary>
        public HerramientaContext(ConfigDb configDb) : base(configDb)
        {
        }

        /// <summary>
        /// Crea un nuevo registro de herramienta en la base de datos
        /// </summary>
        /// <param name="herramienta">Datos de la herramienta a crear</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Create(HerramientaModel herramienta)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPCreateHerramienta";

                    command.Parameters.AddWithValue("h_codigobarra", herramienta.Codigo_Barra_Herramienta);
                    command.Parameters.AddWithValue("h_nombre", herramienta.Nombre_Herramienta);
                    command.Parameters.AddWithValue("h_descripcion", herramienta.Descripcion_Herramienta);
                    command.Parameters.AddWithValue("h_cantidaddisponible", herramienta.Cantidad_Disponible);
                    command.Parameters.AddWithValue("h_modeloid", herramienta.ModeloID);
                    command.Parameters.AddWithValue("h_marcaid", herramienta.MarcaID);
                    command.Parameters.AddWithValue("h_estadoid", herramienta.EstadoID);

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
        /// Obtiene todas las herramientas desde la vista vherramienta
        /// </summary>
        /// <returns>Colección observable de herramientas o colección vacía en caso de error</returns>
        public ObservableCollection<HerramientaModel> Read()
        {
            ObservableCollection<HerramientaModel> lstHerramienta = new ObservableCollection<HerramientaModel>();
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM vherramienta";

                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstHerramienta.Add(new HerramientaModel
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
            return lstHerramienta;
        }

        /// <summary>
        /// Actualiza los datos de una herramienta existente
        /// </summary>
        /// <param name="herramienta">Datos actualizados de la herramienta</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Update(HerramientaModel herramienta)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPUpdateHerramienta";

                    command.Parameters.AddWithValue("h_herramientaid", herramienta.HerramientaID);
                    command.Parameters.AddWithValue("h_codigobarra", herramienta.Codigo_Barra_Herramienta);
                    command.Parameters.AddWithValue("h_nombre", herramienta.Nombre_Herramienta);
                    command.Parameters.AddWithValue("h_descripcion", herramienta.Descripcion_Herramienta);
                    command.Parameters.AddWithValue("h_cantidaddisponible", herramienta.Cantidad_Disponible);
                    command.Parameters.AddWithValue("h_modeloid", herramienta.ModeloID);
                    command.Parameters.AddWithValue("h_marcaid", herramienta.MarcaID);
                    command.Parameters.AddWithValue("h_estadoid", herramienta.EstadoID);

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
        /// Elimina un registro de herramienta de la base de datos
        /// </summary>
        /// <param name="herramienta">Modelo con el ID de la herramienta a eliminar</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Delete(HerramientaModel herramienta)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPDeleteHerramienta";

                    command.Parameters.AddWithValue("h_herramientaid", herramienta.HerramientaID);

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
