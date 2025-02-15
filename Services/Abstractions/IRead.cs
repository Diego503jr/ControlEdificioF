using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Services.Abstractions
{
    internal interface IRead<T>
    {
        ObservableCollection<T> Read();
    }
}
