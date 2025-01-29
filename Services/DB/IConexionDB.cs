using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Services.DB
{
    //Se usa la interfaz disposable para cerrar todos los recursos de la conexion a la DB
    public interface IConexionDB : IDisposable
    {
        void ConnectToDB();
        new void Dispose();
    }
}
