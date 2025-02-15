using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Services.Abstractions
{
    internal interface IDelete<T>
    {
        int Delete(T obj);
    }
}
