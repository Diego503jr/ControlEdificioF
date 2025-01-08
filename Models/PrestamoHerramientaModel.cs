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
        private TimeOnly _Hora_Entrada_Herramienta;
        private TimeOnly _Hora_Salida_Herramienta;
        private int _DocenteID;
        private int _DUI_RecibidoID;
        private int _DUI_EntregadoID;
        private int _Estado_PrestamoID;
        private int _HerramientaID;
        private int _Tecnico_EntregaID;
        private int _Tecnico_RecibeID;
        private int _Centro_ComputoID;



        public int PrestamoHerramientaID
        {
            get => _Prestamo_HerramientaID;

            set => _Prestamo_HerramientaID = value;
        }

        public DateOnly FechaPrestamoHerramienta
        {
            get => _Fecha_Prestamo_Herramienta;

            set => _Fecha_Prestamo_Herramienta = value;
        }

        public TimeOnly HoraEntradaPrestamoHerramienta
        {
            get => _Hora_Entrada_Herramienta;

            set => _Hora_Entrada_Herramienta = value;
        }

        public TimeOnly HoraSalidaHerramienta
        {
            get => _Hora_Salida_Herramienta;

            set => _Hora_Salida_Herramienta = value;
        }

        public int DocenteID
        {
            get => _DocenteID;

            set => _DocenteID = value;
        }

        public int DUIRecibidoID
        {
            get => _DUI_RecibidoID;

            set => _DUI_RecibidoID = value;
        }

        public int DUIEntregadoID
        {
            get => _DUI_EntregadoID;

            set => _DUI_EntregadoID = value;
        }

        public int EstadoPrestamoID
        {
            get => _Estado_PrestamoID;

            set => _Estado_PrestamoID = value;
        }

        public int HerramientaID
        {
            get => _HerramientaID;

            set => _HerramientaID = value;
        }

        public int TecnicoEntregaID
        {
            get => _Tecnico_EntregaID;

            set => _Tecnico_EntregaID = value;
        }

        public int TecnicoRecibeID
        {
            get => _Tecnico_RecibeID;

            set => _Tecnico_RecibeID = value;
        }

        public int CentroComputoID
        {
            get => _Centro_ComputoID;

            set => _Centro_ComputoID = value;
        }
    }
}
