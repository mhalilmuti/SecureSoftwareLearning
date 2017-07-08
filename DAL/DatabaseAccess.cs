using DAL.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace DAL
{
    public class DatabaseAccess : IDatabaseAccessLayer
    {
        private string _connectionString;

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        public DatabaseAccess()
        {
            this.ConnectionString = WebConfigurationManager.ConnectionStrings["companyDbConnectionString"].ToString();
        }

        public DatabaseAccess(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public async Task<DataTable> ExecuteAsync(string query)
        {
            return await MySql.ExecuteAsync(this.ConnectionString, query);
        }

        public async Task<DataTable> ExecuteAsync(string query, List<MySqlParameter> parameters)
        {
            return await MySql.ExecuteAsync(this.ConnectionString, query, parameters);
        }

        public async Task<int> ExecuteNonQueryAsync(string command)
        {
            return await MySql.ExecuteNonQueryAsync(this.ConnectionString, command);
        }

        public async Task<int> ExecuteNonQueryAsync(string command, List<MySqlParameter> parameters)
        {
            return await MySql.ExecuteNonQueryAsync(this.ConnectionString, command, parameters);
        }
    }
}
