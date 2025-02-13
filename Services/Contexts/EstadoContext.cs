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
    internal class EstadoContext : DbContextMySql, IBaseContext<EstadoModel>
    {
        public EstadoContext(ConfigDb config) : base(config) { }

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

        public ObservableCollection<EstadoModel> Read() 
        {
            ObservableCollection<EstadoModel> lstEstado = new ObservableCollection<EstadoModel>();

            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "vestado";

                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstEstado.Add(new EstadoModel
                            {
                                EstadoID = int.Parse(ddr["EstadoID"].ToString()),
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

            return lstEstado;
        }

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

        public int Delete(EstadoModel estadoModel) 
        {
            int res = -1;
            return res;
        }
    }
}
