using DAL;
using MySql.Data.MySqlClient;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
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
            //Fixed SQL injection to authentication we use mysql parameter
            string query = "SELECT * FROM customers Where password=@password and username=@username;";
            DatabaseAccess db = new DatabaseAccess();
            DataTable dTable = await db.ExecuteAsync(query, new List<MySqlParameter>
            {
                new MySqlParameter
                {
                    ParameterName="username",
                    Value=username,
                    MySqlDbType=MySqlDbType.VarChar
                },
                 new MySqlParameter
                {
                    ParameterName="password",
                    Value=password,
                    MySqlDbType=MySqlDbType.VarChar
                }
            });

            return SetCredential(dTable);
        }

        public static async Task<Credentials> GetEmployee(string username,string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }

            string query = "SELECT * FROM employees Where password=@password and username=@username;";
            DatabaseAccess db = new DatabaseAccess();
            DataTable dTable = await db.ExecuteAsync(query, new List<MySqlParameter>
            {
              new MySqlParameter
                {
                    ParameterName="username",
                    Value=username,
                    MySqlDbType=MySqlDbType.VarChar
                },
                 new MySqlParameter
                {
                    ParameterName="password",
                    Value=password,
                    MySqlDbType=MySqlDbType.VarChar
                }
            });

            return SetCredential(dTable);
        }

        private static Credentials SetCredential(DataTable dataTable)
        {
            return (from DataRow row in dataTable.Rows
                    select new Credentials
                    {
                        username = WebUtility.HtmlEncode(row["username"].ToString()),
                        password = WebUtility.HtmlEncode(row["password"].ToString()),
                        id = WebUtility.HtmlEncode(row["id"].ToString()),
                        name = WebUtility.HtmlEncode(row["name"].ToString()),
                        surname = WebUtility.HtmlEncode(row["surname"].ToString())
                    }).FirstOrDefault();
        }
    }
}
