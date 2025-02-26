using ControlEdificioF.Model;
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
    /// Contexto de base de datos para operaciones CRUD de estudiantes
    /// Implementa la interfaz genérica ICRUD para operaciones estándar
    /// </summary>
    internal class EstudianteContext : DbContextMySql, ICRUD<EstudianteModel>
    {
        /// <summary>
        /// Constructor que inicializa el contexto con la configuración de base de datos
        /// </summary>
        public EstudianteContext(ConfigDb configDb) : base(configDb)
        {
        }

        /// <summary>
        /// Crea un nuevo registro de estudiante en la base de datos
        /// </summary>
        /// <param name="estudiante">Datos del estudiante a crear</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Create(EstudianteModel estudiante)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPCreateEstudiante";
                    command.Parameters.AddWithValue("e_nombre", estudiante.Nombre_Estudiante);
                    command.Parameters.AddWithValue("e_apellido", estudiante.Apellido_Estudiante);
                    command.Parameters.AddWithValue("e_carnetid", estudiante.Carnet_Estudiante);
                    command.Parameters.AddWithValue("e_carreraid", estudiante.CarreraId);
                    command.Parameters.AddWithValue("e_estadoid", estudiante.EstadoID);
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
        /// Obtiene todos los estudiantes desde la vista vestudiante
        /// </summary>
        /// <returns>Colección observable de estudiantes o colección vacía en caso de error</returns>
        public ObservableCollection<EstudianteModel> Read()
        {
            ObservableCollection<EstudianteModel> lstEstudiante = new ObservableCollection<EstudianteModel>();
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "SELECT * FROM vestudiante";
                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstEstudiante.Add(new EstudianteModel
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
            return lstEstudiante;
        }

        /// <summary>
        /// Actualiza los datos de un estudiante existente
        /// </summary>
        /// <param name="estudiante">Datos actualizados del estudiante</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Update(EstudianteModel estudiante)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPUpdateEstudiante";
                    command.Parameters.AddWithValue("e_estudianteid", estudiante.EstudianteID);
                    command.Parameters.AddWithValue("e_nombre", estudiante.Nombre_Estudiante);
                    command.Parameters.AddWithValue("e_apellido", estudiante.Apellido_Estudiante);
                    command.Parameters.AddWithValue("e_carnetid", estudiante.Carnet_Estudiante);
                    command.Parameters.AddWithValue("e_carreraid", estudiante.CarreraId);
                    command.Parameters.AddWithValue("e_estadoid", estudiante.EstadoID);
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
        /// Elimina un registro de estudiante de la base de datos
        /// </summary>
        /// <param name="estudiante">Modelo con el ID del estudiante a eliminar</param>
        /// <returns>Número de filas afectadas o -1 en caso de error</returns>
        public int Delete(EstudianteModel estudiante)
        {
            int res = -1;
            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPDeleteEstudiante";
                    command.Parameters.AddWithValue("e_estudianteid", estudiante.EstudianteID);
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
