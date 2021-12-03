using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriMania.Infra.Database
{
    public interface IMySqlConnection
    {
        MySqlConnection CreateNewConnection();
    }
}
