using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlEdificioF.Services.Database
{
    internal interface IDbContextMySql
    {
        MySqlConnection CreateConnection();
    }
}
