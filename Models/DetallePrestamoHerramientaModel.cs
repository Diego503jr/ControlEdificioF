using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public class DetallePrestamoHerramientaModel
    {
        private int _Detalle_Prestamo_HerramientaID;
        private int _Prestamo_HerramientaID;
        private int _HerramientaID;
        private int _Cantidad;

        public int Detalle_Prestamo_HerramientaID { get => _Detalle_Prestamo_HerramientaID; set => _Detalle_Prestamo_HerramientaID = value; }
        public int Prestamo_HerramientaID { get => _Prestamo_HerramientaID; set => _Prestamo_HerramientaID = value; }
        public int HerramientaID { get => _HerramientaID; set => _HerramientaID = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
    }
}
