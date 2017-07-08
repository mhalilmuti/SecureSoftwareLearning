using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Collections;
using Repositories.Models;
using System.Data;
using System.Net;

namespace Repositories
{
    public class ContactRepository
    {
        public static async Task<List<Countries>> GetCountries()
        {
            string query = "SELECT * FROM countries";
            DatabaseAccess db = new DatabaseAccess();
            var countires = await db.ExecuteAsync(query);

            return (from DataRow row in countires.Rows
                    select new Countries
                    {
                        id = Convert.ToInt32(row["id"]),
                        code = WebUtility.HtmlEncode(row["code"].ToString()),
                        name = WebUtility.HtmlEncode(row["name"].ToString())
                    })
                    .OrderBy(f => f.name)
                    .ToList();
        }

        public static async Task<List<Cities>> GetCities(int countryId)
        {
            string query = String.Format("SELECT * FROM cities WHERE country_id={0}", countryId);

            DatabaseAccess db = new DatabaseAccess();
            var countires = await db.ExecuteAsync(query);

            return (from DataRow row in countires.Rows
                    select new Cities
                    {
                        id = Convert.ToInt32(row["id"]),
                        code = WebUtility.HtmlEncode(row["code"].ToString()),
                        name = WebUtility.HtmlEncode(row["name"].ToString())
                    })
                    .OrderBy(f => f.name)
                    .ToList();
        }

        public static async Task<List<Districts>> GetDistricts(int cityId)
        {
            string query = String.Format("SELECT * FROM districts WHERE city_id={0}", cityId);

            DatabaseAccess db = new DatabaseAccess();
            var countires = await db.ExecuteAsync(query);

            return (from DataRow row in countires.Rows
                    select new Districts
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
