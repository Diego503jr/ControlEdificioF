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
    /// Contexto de base de datos para operaciones CRUD de centros de cómputo
    /// Implementa la interfaz genérica IBaseContext para operaciones estándar
    /// </summary>
    internal class CentroComputoContext : DbContextMySql, ICRUD<CentroComputoModel>
    {
        /// <summary>
        /// Constructor que inicializa el contexto con la configuración de base de datos
        /// </summary>
        public CentroComputoContext(ConfigDb configDb) : base(configDb) { }

        /// <summary>
        /// Crea un nuevo registro de centro de cómputo en la base de datos
        /// </summary>
        /// <param name="centroComputo">Datos del centro de cómputo a crear</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Create(CentroComputoModel centroComputo)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPCreateCentroComputo";

                    command.Parameters.AddWithValue("cc_centrocomputo", centroComputo.Centro_Computo);
                    command.Parameters.AddWithValue("cc_estadoid", centroComputo.EstadoID);

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
        /// Obtiene todos los centros de cómputo desde la vista vcentrocomputo
        /// </summary>
        /// <returns>Colección observable de centros de cómputo o colección vacía en caso de error</returns>
        public ObservableCollection<CentroComputoModel> Read()
        {
            ObservableCollection<CentroComputoModel> lstComputo = new ObservableCollection<CentroComputoModel>();
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM vcentrocomputo";

                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstComputo.Add(new CentroComputoModel
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
            return lstComputo;
        }

        /// <summary>
        /// Actualiza los datos de un centro de cómputo existente
        /// </summary>
        /// <param name="centroComputo">Datos actualizados del centro de cómputo</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Update(CentroComputoModel centroComputo)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPUpdateCentroComputo";

                    command.Parameters.AddWithValue("cc_centrocomputoid", centroComputo.Centro_ComputoID);
                    command.Parameters.AddWithValue("cc_centrocomputo", centroComputo.Centro_Computo);
                    command.Parameters.AddWithValue("cc_estadoid", centroComputo.EstadoID);

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
        /// Elimina un centro de cómputo específico de la base de datos
        /// </summary>
        /// <param name="centroComputo">Modelo que contiene el ID del centro de cómputo a eliminar</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Delete(CentroComputoModel centroComputo)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPDeleteCentroComputo";

                    command.Parameters.AddWithValue("cc_centrocomputoid", centroComputo.Centro_ComputoID);

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
