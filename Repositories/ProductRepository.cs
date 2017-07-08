using DAL;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        code = row["code"].ToString(),
                        name = row["name"].ToString(),
                        amount = row["amount"].ToString(),
                        category = new Categories
                        {
                            id = Convert.ToInt32(row["categoryId"]),
                            code = row["categoryCode"].ToString(),
                            name = row["categoryName"].ToString(),
                        }
                    })
                    .OrderBy(f => f.id)
                    .ToList();
        }
    }
}
