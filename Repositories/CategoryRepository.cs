﻿using DAL;
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
    public class CategoryRepository
    {
        public static async Task<List<Categories>> Get()
        {
            string query = "SELECT * FROM categories";
            DatabaseAccess db = new DatabaseAccess();
            var categories = await db.ExecuteAsync(query);

            return (from DataRow row in categories.Rows
                    select new Categories
                    {
                        id = Convert.ToInt32(row["id"]),
                        code = WebUtility.HtmlEncode(row["code"].ToString()),
                        name = WebUtility.HtmlEncode(row["name"].ToString())
                    })
                    .OrderBy(f => f.name)
                    .ToList();
        }
    }
}
