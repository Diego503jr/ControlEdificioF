using ControlEdificioF.Models;
using ControlEdificioF.Services.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Services.Contexts
{
    /// <summary>
    /// Contexto de base de datos para operaciones CRUD de marcas.
    /// Implementa la interfaz genérica IBaseContext para operaciones estándar.
    /// </summary>
    internal class MarcaContext : DbContextMySql, IBaseContext<MarcaModel>
    {
        /// <summary>
        /// Constructor que inicializa el contexto con la configuración de base de datos.
        /// </summary>
        public MarcaContext(ConfigDb configDb) : base(configDb)
        {
        }

        /// <summary>
        /// Crea una nueva marca en la base de datos mediante el procedimiento almacenado SPCreateMarca.
        /// </summary>
        /// <param name="marca">Datos de la marca a crear.</param>
        /// <returns>Número de filas afectadas o -1 en caso de error.</returns>
        public int Create(MarcaModel marca)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPCreateMarca";
                    command.Parameters.AddWithValue("m_marca", marca.Marca);
                    command.Parameters.AddWithValue("m_estadoid", marca.Estado);
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
        /// Obtiene todas las marcas desde la vista vmarca.
        /// </summary>
        /// <returns>Colección observable de marcas o colección vacía en caso de error.</returns>
        public ObservableCollection<MarcaModel> Read()
        {
            ObservableCollection<MarcaModel> lstMarca = new ObservableCollection<MarcaModel>();
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "vmarca";
                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstMarca.Add(new MarcaModel
                            {
                                MarcaID = int.Parse(ddr["Id"].ToString()),
                                Marca = ddr["Marca"].ToString(),
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
            return lstMarca;
        }

        /// <summary>
        /// Actualiza los datos de una marca existente mediante el procedimiento almacenado SPUpdateMarca.
        /// </summary>
        /// <param name="marca">Datos actualizados de la marca.</param>
        /// <returns>Número de filas afectadas o -1 en caso de error.</returns>
        public int Update(MarcaModel marca)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPUpdateMarca";
                    command.Parameters.AddWithValue("m_id", marca.MarcaID);
                    command.Parameters.AddWithValue("m_marca", marca.Marca);
                    command.Parameters.AddWithValue("m_estadoid", marca.Estado);
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
        /// Elimina una marca específica mediante el procedimiento almacenado SPDeleteMarca.
        /// </summary>
        /// <param name="marca">Modelo que contiene el ID de la marca a eliminar.</param>
        /// <returns>Número de filas afectadas o -1 en caso de error.</returns>
        public int Delete(MarcaModel marca)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPDeleteMarca";
                    command.Parameters.AddWithValue("m_id", marca.MarcaID);
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
