using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Services.Contexts
{
    internal interface IBaseContext<T>
    {
        public int Create(T obj);
        public ObservableCollection<T> Read();
        public int Update(T obj);
        public int Delete(T obj);

    }
}
