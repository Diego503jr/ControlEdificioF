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
    internal class CarreraContext : DbContextMySql, IBaseContext<CarreraModel>
    {
        public CarreraContext(ConfigDb configDb) : base(configDb)
        {
            
        }

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
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }

            return res;
        }

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
