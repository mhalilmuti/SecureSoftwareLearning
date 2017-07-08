using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class MySql
    {
        public static async Task<DataTable> ExecuteAsync(string connectionString, string query)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = query;

                if (connection.State == ConnectionState.Broken
                    || connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                DataTable dTable = new DataTable();
                DbDataReader dReader = await command.ExecuteReaderAsync();

                dTable.Load(dReader);
                connection.Close();

                return dTable;
            }
        }

        public static async Task<DataTable> ExecuteAsync(string connectionString, string query, List<MySqlParameter> parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand();
                command.Connection = connection;
                command.CommandText = query;

                if (connection.State == ConnectionState.Broken
                    || connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                if (parameters.Count > 0)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }

                DataTable dTable = new DataTable();
                DbDataReader dReader = await command.ExecuteReaderAsync();

                dTable.Load(dReader);
                connection.Close();

                return dTable;
            }
        }

        public static async Task<int> ExecuteNonQueryAsync(string connectionString, string command)
        {
            int result = -1;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = command;

                    result = await cmd.ExecuteNonQueryAsync();
                }
            }

            return result;
        }

        public static async Task<int> ExecuteNonQueryAsync(string connectionString, string command, List<MySqlParameter> parameters)
        {
            int result = -1;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = command;

                    if (parameters.Count > 0)
                    {
                        cmd.Parameters.AddRange(parameters.ToArray());
                    }

                    result = await cmd.ExecuteNonQueryAsync();
                }
            }

            return result;
        }
    }
}
