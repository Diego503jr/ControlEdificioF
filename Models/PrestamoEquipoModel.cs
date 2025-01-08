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
        private int _EstudianteID;
        private TimeOnly _Hora_Entrada_Equipo;
        private TimeOnly _Hora_Salida_Equipo;
        private int _EquipoID;

        public int PrestamoEquipoID
        {
            get => _Prestamo_EquipoID;

            set => _Prestamo_EquipoID = value;
        }

        public DateOnly FechaPrestamoEquipo
        {
            get => _Fecha_Prestamo_Equipo;

            set => _Fecha_Prestamo_Equipo = value;
        }

        public int EstudianteID
        {
            get => _EstudianteID;

            set => _EstudianteID = value;
        }

        public TimeOnly HoraEntradaEquipo
        {
            get => _Hora_Entrada_Equipo;

            set => _Hora_Entrada_Equipo = value;
        }

        public TimeOnly HoraSalidaEquipo
        {
            get => _Hora_Salida_Equipo;

            set => _Hora_Salida_Equipo = value;
        }

        public int EquipoID
        {
            get => _EquipoID;

            set => _EquipoID = value;
        }
    }
}
