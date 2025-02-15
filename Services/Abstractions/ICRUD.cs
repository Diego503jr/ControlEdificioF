using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Services.Abstractions
{
    internal interface ICRUD<T> : ICreate<T>, IRead<T>, IUpdate<T>, IDelete<T>
    {
        public int Create(T obj);
        public ObservableCollection<T> Read();
        public int Update(T obj);
        public int Delete(T obj);
    }
}
