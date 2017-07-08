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
    public class CustomerRepository
    {
        public static async Task<dynamic> GetUnsafe(string id)
        {
            string query = "SELECT"
                        + " customers.id,"
                        + " customers.name,"
                        + " customers.surname,"
                        + " customers.username,"
                        + " customers.password,"
                        + " contact.phone,"
                        + " contact.address,"
                        + " districts.id as district,"
                        + " cities.id as city,"
                        + " countries.id as country,"
                        + " contact.description"
                        + " FROM companydb.customers"
                        + " LEFT JOIN contact on contact.id = customers.contact_id"
                        + " LEFT JOIN countries on countries.id = contact.country_id"
                        + " LEFT JOIN cities on cities.id = contact.city_id"
                        + " LEFT JOIN districts on districts.id = contact.district_id"
                        + " WHERE customers.id='" + id+"'";

            DatabaseAccess db = new DatabaseAccess();
            DataTable customer = await db.ExecuteAsync(query);

            return (from DataRow row in customer.Rows
                    select new
                    {
                        id = WebUtility.HtmlEncode(row["id"].ToString()),
                        name = WebUtility.HtmlEncode(row["name"].ToString()),
                        surname = WebUtility.HtmlEncode(row["surname"].ToString()),
                        username = WebUtility.HtmlEncode(row["username"].ToString()),
                        password = WebUtility.HtmlEncode(row["password"].ToString()),
                        phone = WebUtility.HtmlEncode(row["phone"].ToString()),
                        address = WebUtility.HtmlEncode(row["address"].ToString()),
                        district = WebUtility.HtmlEncode(row["district"].ToString()),
                        city = WebUtility.HtmlEncode(row["city"].ToString()),
                        country = WebUtility.HtmlEncode(row["country"].ToString()),
                        description = WebUtility.HtmlEncode(row["description"].ToString())
                    });
        }

        public static async Task<int> UpdateUnsafe(CustomerUpdateRequestModel customer)
        {
            string command = "UPDATE customers"
                + " SET "
                + "name='" + WebUtility.HtmlEncode(customer.name) + "',"
                + "surname='" + WebUtility.HtmlEncode(customer.surname) + "',"
                + "username='" + WebUtility.HtmlEncode(customer.username) + "' "
                + " WHERE id='" + WebUtility.HtmlEncode(customer.id) + "'";

            DatabaseAccess db = new DatabaseAccess();
            return await db.ExecuteNonQueryAsync(command);
        }

        public static async Task<int> CreateUnsafe(Customers customer)
        {
            string customerId = Guid.NewGuid().ToString();
            string contactId = Guid.NewGuid().ToString();

            string command = "INSERT INTO customers VALUES("
                + "'" + WebUtility.HtmlEncode(customerId) + "',"
                + "'" + WebUtility.HtmlEncode(customer.name) + "',"
                + "'" + WebUtility.HtmlEncode(customer.surname) + "',"
                + "'" + WebUtility.HtmlEncode(customer.username) + "',"
                + "'" + WebUtility.HtmlEncode(customer.password) + "',"
                + "'" + WebUtility.HtmlEncode(contactId) + "')";

            DatabaseAccess db = new DatabaseAccess();
            int result = await db.ExecuteNonQueryAsync(command);

            if (result == 1)
            {
                command = "Insert Into contact VALUES("
                    + "'" + WebUtility.HtmlEncode(contactId) + "',"
                    + customer.contact.countryId + ","
                    + customer.contact.cityId + ","
                    + customer.contact.districtId + ","
                    + "'" + WebUtility.HtmlEncode(customer.contact.address) + "',"
                    + "'" + WebUtility.HtmlEncode(customer.contact.phone) + "',"
                    + "'" + WebUtility.HtmlEncode(customer.contact.description) + "')"; //olmamalı

                result = await db.ExecuteNonQueryAsync(command);
            }

            return result;
        }

        public static async Task<dynamic> Create(Customers customer)
        {
            throw new NotImplementedException();
        }
    }
}
