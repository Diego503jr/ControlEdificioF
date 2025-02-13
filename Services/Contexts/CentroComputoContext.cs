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
    internal class CentroComputoContext :  DbContextMySql, IBaseContext<CentroComputoModel>
    {
        public CentroComputoContext(ConfigDb configDb) : base(configDb) { }

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
        public ObservableCollection<CentroComputoModel> Read()
        {
            ObservableCollection<CentroComputoModel> lstComputo = new ObservableCollection<CentroComputoModel>();

            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "vcentrocomputo";

                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstComputo.Add(new CentroComputoModel
                            {
                                Centro_ComputoID = int.Parse(ddr["Id"].ToString()),
                                Centro_Computo = ddr["Computo"].ToString(),
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

            return lstComputo;
        }

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
