using DAL;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using MySql.Data.MySqlClient;

namespace Repositories
{
    public class ProductRepository
    {
        public static async Task<List<Products>> Get()
        {
            string query = "SELECT prod.id,"
                + "prod.code,"
                + "prod.name,"
                + "prod.amount,"
                + "cat.id as categoryId,"
                + "cat.code categoryCode,"
                + "cat.name categoryName "
                + "FROM companydb.products as prod "
                + "LEFT JOIN categories as cat on prod.category_id = cat.id;";

            DatabaseAccess db = new DatabaseAccess();
            var products = await db.ExecuteAsync(query);

            return (from DataRow row in products.Rows
                    select new Products
                    {
                        id = Convert.ToInt32(row["id"]),
                        code = WebUtility.HtmlEncode(row["code"].ToString()),
                        name = WebUtility.HtmlEncode(row["name"].ToString()),
                        amount = WebUtility.HtmlEncode(row["amount"].ToString()),
                        category = new Categories
                        {
                            id = Convert.ToInt32(row["categoryId"]),
                            code = WebUtility.HtmlEncode(row["categoryCode"].ToString()),
                            name = WebUtility.HtmlEncode(row["categoryName"].ToString()),
                        }
                    })
                    .OrderBy(f => f.id)
                    .ToList();
        }
        public static async Task<string> Getid(int id)
        {
            string query = "SELECT prod.id,"
                + "prod.code,"
                + "prod.name,"
                + "prod.amount,"
                + "cat.id as categoryId,"
                + "cat.code categoryCode,"
                + "cat.name categoryName "
                + "FROM companydb.products as prod "
                + "LEFT JOIN categories as cat on prod.category_id = cat.id"
                 + " WHERE prod.id=@prodId;";

            DatabaseAccess db = new DatabaseAccess();
            DataTable dTable = await db.ExecuteAsync(query, new List<MySqlParameter>
            {
                new MySqlParameter
                {
                    ParameterName = "prodId",
                    Value = id,
                    MySqlDbType = MySqlDbType.VarChar,
                    Size = 36
                }
            });
            string deger = "";
            foreach (DataRow row in dTable.Rows)
            {
                deger = row["amount"].ToString();
                               }
                  
            return (deger);
        }
    }
}
