using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Services.Abstractions
{
    internal interface ICreate<T>
    {
        int Create(T obj);
    }
}
