using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Repositories.Models;

namespace Repositories
{
    public class EmployeeRepository
    {
       
        public static async Task<dynamic> GetEmployeeUnSafe(string id)
        {
            string query = "SELECT"
                           + " employee.id as employeeId,"
                           + " employee.name,"
                           + " employee.surname,"
                           + " employee.username,"
                           + " employee.password,"
                           + " country.name as country,"
                           + " city.name as city,"
                           + " dist.name as district,"
                           + " contact.phone,"
                           + " contact.address,"
                           + " contact.description"  //olmamalı
                           + " FROM employees as employee"
                           + " LEFT JOIN contact as contact on contact.id = employee.contact_id"
                           + " LEFT JOIN countries as country on contact.country_id = country.id"
                           + " LEFT JOIN cities as city on contact.city_id = city.id"
                           + " LEFT JOIN districts as dist on contact.district_id = dist.id"
                           + " WHERE employee.id=" + id;


            DatabaseAccess db = new DatabaseAccess();
            DataTable employeeContact = await db.ExecuteAsync(query);

            return (from DataRow row in employeeContact.Rows
                    select new
                    {
                        id = WebUtility.HtmlEncode(row["employeeId"].ToString()),
                        name = WebUtility.HtmlEncode(row["name"].ToString()),
                        surname = WebUtility.HtmlEncode(row["surname"].ToString()),
                        username = row["username"],
                        password = row["password"],
                        address = WebUtility.HtmlEncode(row["address"].ToString()),
                        district = WebUtility.HtmlEncode(row["district"].ToString()),
                        city = WebUtility.HtmlEncode(row["city"].ToString()),
                        country = WebUtility.HtmlEncode(row["country"].ToString()),
                        description = WebUtility.HtmlEncode(row["description"].ToString()), //olmamalı
                        phone = WebUtility.HtmlEncode(row["phone"].ToString()),
                    });
        }

        public static async Task<int> CreateUnsafe(Employees employee)
        {
            string employeeId = Guid.NewGuid().ToString();
            string contactId = Guid.NewGuid().ToString();

            string command = "Insert Into Employees VALUES("
                + "'" + employeeId + "',"
                + "'" + WebUtility.HtmlEncode(employee.name) + "',"
                + "'" + WebUtility.HtmlEncode(employee.surname) + "',"
                + "'" + WebUtility.HtmlEncode(employee.username) + "',"
                + "'" + WebUtility.HtmlEncode(employee.password) + "',"  
                + "'" + contactId + "'"
                + ")";

            DatabaseAccess db = new DatabaseAccess();
            int result = await db.ExecuteNonQueryAsync(command);

            if (result == 1)
            {
                command = "Insert Into Contact VALUES("
                    + "'" + contactId + "',"
                    + employee.contact.countryId + ","
                    + employee.contact.cityId + ","
                    + employee.contact.districtId + ","
                    + "'" + WebUtility.HtmlEncode(employee.contact.address) + "',"
                    + "'" + WebUtility.HtmlEncode(employee.contact.phone) + "',"
                    + "'" + WebUtility.HtmlEncode(employee.contact.description) + "'" //olmamalı
                    + ")";

                result = await db.ExecuteNonQueryAsync(command);
            }

            return result;
        }

        private void CheckUniqParameters(string value)
        {

        }
    }
}
