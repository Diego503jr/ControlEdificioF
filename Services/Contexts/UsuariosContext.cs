using ControlEdificioF.Model;
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
    internal class UsuariosContext : DbContextMySql, IBaseContext<UsuarioModel>
    {
        public UsuariosContext(ConfigDb config) : base(config) { }

        public int Create(UsuarioModel usuario)
        {
            int res = -1;

            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPCreateUsuario";

                    command.Parameters.AddWithValue("u_nombre", usuario.Nombre_Usuario);
                    command.Parameters.AddWithValue("u_apellido", usuario.Apellido_Usuario);
                    command.Parameters.AddWithValue("u_dui", usuario.DUI_Usuario);
                    command.Parameters.AddWithValue("u_rolid", usuario.RolID);
                    command.Parameters.AddWithValue("u_estadoid", usuario.EstadoID);


                    res = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return res;
        }

        public ObservableCollection<UsuarioModel> Read()
        {
            ObservableCollection<UsuarioModel> lstUsuario = new ObservableCollection<UsuarioModel>();

            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "vusuario";

                    using (DbDataReader ddr = command.ExecuteReader())
                    {
                        while (ddr.Read())
                        {
                            lstUsuario.Add(new UsuarioModel
                            {
                                UsuarioID = int.Parse(ddr["Id"].ToString()),
                                Nombre_Usuario = ddr["Nombre"].ToString(),
                                Apellido_Usuario = ddr["Apellido"].ToString(),
                                DUI_Usuario = int.Parse(ddr["DUI"].ToString()),
                                Rol = ddr["Rol"].ToString(),
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

            return lstUsuario;
        }

        public int Update(UsuarioModel usuario)
        {
            int res = -1;

            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPUpdateUsuario";

                    command.Parameters.AddWithValue("u_usuarioid", usuario.UsuarioID);
                    command.Parameters.AddWithValue("u_nombre", usuario.Nombre_Usuario);
                    command.Parameters.AddWithValue("u_apellido", usuario.Apellido_Usuario);
                    command.Parameters.AddWithValue("u_dui", usuario.DUI_Usuario);
                    command.Parameters.AddWithValue("u_rolid", usuario.RolID);
                    command.Parameters.AddWithValue("u_estadoid", usuario.EstadoID);


                    res = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return res;
        }

        public int Delete(UsuarioModel usuario)
        {
            int res = -1;

            try
            {
                using (var connection = CreateConnection())
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SPDeleteUsuario";

                    command.Parameters.AddWithValue("u_usuarioid", usuario.UsuarioID);


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
