using DAL;
using MySql.Data.MySqlClient;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class Credential
    {
        public static async Task<Credentials> GetCustomer(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            string query = "SELECT * FROM customers Where password='"+password+ "' and username='" + username + "';";
            DatabaseAccess db = new DatabaseAccess();
            DataTable dTable = await db.ExecuteAsync(query, new List<MySqlParameter>
            {
            /*    new MySqlParameter
                {
                    ParameterName="username",
                    Value=username,
                    MySqlDbType=MySqlDbType.VarChar
                }*/
            });

            return SetCredential(dTable);
        }

        public static async Task<Credentials> GetEmployee(string username,string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            string query = "SELECT * FROM employees Where password='" + password + "' and username='" + username + "';";
            DatabaseAccess db = new DatabaseAccess();
            DataTable dTable = await db.ExecuteAsync(query, new List<MySqlParameter>
            {
              /*  new MySqlParameter
                {
                    ParameterName="username",
                    Value=username,
                    MySqlDbType=MySqlDbType.VarChar
                }*/
            });

            return SetCredential(dTable);
        }

        private static Credentials SetCredential(DataTable dataTable)
        {
            return (from DataRow row in dataTable.Rows
                    select new Credentials
                    {
                        username = row["username"].ToString(),
                        password = row["password"].ToString(),
                        id = row["id"].ToString(),
                        name = row["name"].ToString(),
                        surname = row["surname"].ToString()
                    }).FirstOrDefault();
        }
    }
}
