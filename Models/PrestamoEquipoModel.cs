using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Models
{
    public class PrestamoEquipoModel
    {
        private int _Prestamo_EquipoID;
        private DateOnly _Fecha_Prestamo_Equipo;
        private int _Carnet_EntregadoID;
        private int _Carnet_RecibidoID;
        private int _CarreraID;
        private TimeOnly _Hora_Entrada;
        private TimeOnly _Hora_Salida;
        private int _Estado_Prestamo_Equipo;
        private int _EquipoID;

        public int Prestamo_EquipoID { get => _Prestamo_EquipoID; set => _Prestamo_EquipoID = value; }
        public DateOnly Fecha_Prestamo_Equipo { get => _Fecha_Prestamo_Equipo; set => _Fecha_Prestamo_Equipo = value; }
        public int Carnet_EntregadoID { get => _Carnet_EntregadoID; set => _Carnet_EntregadoID = value; }
        public int Carnet_RecibidoID { get => _Carnet_RecibidoID; set => _Carnet_RecibidoID = value; }
        public int CarreraID { get => _CarreraID; set => _CarreraID = value; }
        public TimeOnly Hora_Entrada { get => _Hora_Entrada; set => _Hora_Entrada = value; }
        public TimeOnly Hora_Salida { get => _Hora_Salida; set => _Hora_Salida = value; }
        public int Estado_Prestamo_Equipo { get => _Estado_Prestamo_Equipo; set => _Estado_Prestamo_Equipo = value; }
        public int EquipoID { get => _EquipoID; set => _EquipoID = value; }
    }
}
