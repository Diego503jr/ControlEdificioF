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
    internal class DetallePrestamoHerramientaContext : DbContextMySql, ICRU<DetallePrestamoHerramientaModel>
    {
        public DetallePrestamoHerramientaContext(ConfigDb configDb) : base(configDb) { }

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
