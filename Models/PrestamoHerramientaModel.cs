using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public class PrestamoHerramientaModel
    {
        private int _Prestamo_HerramientaID;
        private DateOnly _Fecha_Prestamo_Herramienta;
        private TimeOnly _Hora_Entrega;
        private TimeOnly _Hora_Devolucion;
        private int _DocenteID;
        private int _DUI_EntregadoID;
        private int _DUI_RecibidoID;
        private int _Tecnico_EntregaID;
        private int _Tecnico_RecibeID;
        private int _Centro_ComputoID;
        private int _Estado_PrestamoID;

        public int Prestamo_HerramientaID { get => _Prestamo_HerramientaID; set => _Prestamo_HerramientaID = value; }
        public DateOnly Fecha_Prestamo_Herramienta { get => _Fecha_Prestamo_Herramienta; set => _Fecha_Prestamo_Herramienta = value; }
        public TimeOnly Hora_Entrega { get => _Hora_Entrega; set => _Hora_Entrega = value; }
        public TimeOnly Hora_Devolucion { get => _Hora_Devolucion; set => _Hora_Devolucion = value; }
        public int DocenteID { get => _DocenteID; set => _DocenteID = value; }
        public int DUI_EntregadoID { get => _DUI_EntregadoID; set => _DUI_EntregadoID = value; }
        public int DUI_RecibidoID { get => _DUI_RecibidoID; set => _DUI_RecibidoID = value; }
        public int Tecnico_EntregaID { get => _Tecnico_EntregaID; set => _Tecnico_EntregaID = value; }
        public int Tecnico_RecibeID { get => _Tecnico_RecibeID; set => _Tecnico_RecibeID = value; }
        public int Centro_ComputoID { get => _Centro_ComputoID; set => _Centro_ComputoID = value; }
        public int Estado_PrestamoID { get => _Estado_PrestamoID; set => _Estado_PrestamoID = value; }
    }
}
