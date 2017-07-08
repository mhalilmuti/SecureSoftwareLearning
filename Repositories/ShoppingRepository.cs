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
    public class ShoppingRepository
    {
        public static async Task<int> Create(Shopping shopping)
        {
            string shoppingId = Guid.NewGuid().ToString();
            string command = "INSERT INTO `companydb`.`shopping` "
                 + "(`id`,"
                 + "`customer_id`,"
                 + "`product_id`,"
                 + "`total_amount`,"
                 + "`record_date`)"
                + " VALUES("
                + "'" + shoppingId + "',"
                + "'" + shopping.customerId + "',"
                + "" + shopping.productId + ","
                + "'" + shopping.totalAmount + "',"
                + "'" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "'"
                + ");";

            DatabaseAccess db = new DatabaseAccess();
            return await db.ExecuteNonQueryAsync(command);
        }

        public static async Task<int> CreateUnsafe(Shopping shopping)
        {
            string shoppingId = Guid.NewGuid().ToString();
            string command = "INSERT INTO `companydb`.`shopping`"
                + " VALUES("
                + "'" + shoppingId + "',"
                + "'" + shopping.customerId + "',"
                + "" + shopping.productId + ","
                + "'" + shopping.totalAmount + "',"
                + "'" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "'"
                + ");";

            DatabaseAccess db = new DatabaseAccess();
            return await db.ExecuteNonQueryAsync(command);
        }

        public static async Task<dynamic> Get()
        {
            string query = "SELECT "
                + " shopping.id,"
                + " customers.name,"
                + " customers.surname,"
                + " customers.username,"
                + " products.code as productCode,"
                + " products.name as productName,"
                + " total_amount as amount"
                + " FROM companydb.shopping"
                + " LEFT JOIN customers on customers.id = shopping.customer_id"
                + " LEFT JOIN products on products.id = shopping.product_id";

            DatabaseAccess db = new DatabaseAccess();
            DataTable dTable = await db.ExecuteAsync(query);

            return (from DataRow row in dTable.Rows
                    select new
                    {
                        id = row["id"].ToString(),
                        name = row["name"].ToString(),
                        surname = row["surname"].ToString(),
                        username = row["username"].ToString(),
                        productCode = row["productCode"].ToString(),
                        productName = row["productName"].ToString(),
                        amount = row["amount"].ToString()
                    });
        }
        public static async Task<dynamic> GetById(string id)
        {
            string query = "SELECT "
                + " shopping.id,"
                + " customers.name,"
                + " customers.surname,"
                + " customers.username,"
                + " products.code as productCode,"
                + " products.name as productName,"
                + " products.amount as amount"
                + " FROM companydb.shopping"
                + " LEFT JOIN customers on customers.id = shopping.customer_id"
                + " LEFT JOIN products on products.id = shopping.product_id"
                + " WHERE shopping.id=@shoppingId;";

            DatabaseAccess db = new DatabaseAccess();
            DataTable dTable = await db.ExecuteAsync(query, new List<MySqlParameter>
            {
                new MySqlParameter
                {
                    ParameterName = "shoppingId",
                    Value = id,
                    MySqlDbType = MySqlDbType.VarChar,
                    Size = 36
                }
            });

            return (from DataRow row in dTable.Rows
                    select new
                    {
                        name = row["name"].ToString(),
                        surname = row["surname"].ToString(),
                        username = row["username"].ToString(),
                        productCode = row["productCode"].ToString(),
                        productName = row["productName"].ToString(),
                        amount = row["amount"].ToString()
                    });
        }

        public static async Task<dynamic> GetByCustomerIdUnsafe(string customerId)
        {
            string query = "SELECT "
                + " shopping.id,"
                + " customers.name,"
                + " customers.surname,"
                + " customers.username,"
                + " products.code as productCode,"
                + " products.name as productName,"
                + " products.amount as amount"
                + " FROM companydb.shopping"
                + " LEFT JOIN customers on customers.id = shopping.customer_id"
                + " LEFT JOIN products on products.id = shopping.product_id"
                + " WHERE shopping.customer_id=" + customerId + ";";

            DatabaseAccess db = new DatabaseAccess();
            DataTable dTable = await db.ExecuteAsync(query);
            return (from DataRow row in dTable.Rows
                    select new
                    {
                        name = row["name"].ToString(),
                        surname = row["surname"].ToString(),
                        username = row["username"].ToString(),
                        productCode = row["productCode"].ToString(),
                        productName = row["productName"].ToString(),
                        amount = row["amount"].ToString()
                    });
        }

        public static async Task<dynamic> GetByCustomerId(string customerId)
        {
            string query = "SELECT "
                + " shopping.id,"
                + " customers.name,"
                + " customers.surname,"
                + " customers.username,"
                + " products.code as productCode,"
                + " products.name as productName,"
                + " products.amount as amount"
                + " FROM companydb.shopping"
                + " LEFT JOIN customers on customers.id = shopping.customer_id"
                + " LEFT JOIN products on products.id = shopping.product_id"
                + " WHERE shopping.customer_id=@customerId;";

            DatabaseAccess db = new DatabaseAccess();
            DataTable dTable = await db.ExecuteAsync(query, new List<MySqlParameter>
            {
                new MySqlParameter
                {
                    ParameterName = "customerId",
                    Value = customerId,
                    MySqlDbType = MySqlDbType.VarChar,
                    Size = 36
                }
            });

            return (from DataRow row in dTable.Rows
                    select new
                    {
                        name = row["name"].ToString(),
                        surname = row["surname"].ToString(),
                        username = row["username"].ToString(),
                        productCode = row["productCode"].ToString(),
                        productName = row["productName"].ToString(),
                        amount = row["amount"].ToString()
                    }).ToList();
        }

        public static async void Delete(string id)
        {
            string command = "Delete From shopping Where id='" + id+"'";

            DatabaseAccess db = new DatabaseAccess();
            await db.ExecuteNonQueryAsync(command);
        }
    }
}
