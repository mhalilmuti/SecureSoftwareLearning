using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDatabaseAccessLayer
    {    
        Task<DataTable> ExecuteAsync(string query);
        Task<DataTable> ExecuteAsync(string query, List<MySqlParameter> parameters);

        Task<int> ExecuteNonQueryAsync(string command);
        Task<int> ExecuteNonQueryAsync(string command, List<MySqlParameter> parameters);
    }
}
