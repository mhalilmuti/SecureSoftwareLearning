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
                        id = row["id"].ToString(),
                        name = row["name"].ToString(),
                        surname = row["surname"].ToString(),
                        username = row["username"].ToString(),
                        password = row["password"].ToString(),
                        phone = row["phone"].ToString(),
                        address = row["address"].ToString(),
                        district = row["district"].ToString(),
                        city = row["city"].ToString(),
                        country = row["country"].ToString(),
                        description = row["description"].ToString()
                    });
        }

        public static async Task<int> UpdateUnsafe(CustomerUpdateRequestModel customer)
        {
            string command = "UPDATE customers"
                + " SET "
                + "name='" + customer.name + "',"
                + "surname='" + customer.surname + "',"
                + "username='" + customer.username + "' "
                + " WHERE id='" + customer.id + "'";

            DatabaseAccess db = new DatabaseAccess();
            return await db.ExecuteNonQueryAsync(command);
        }

        public static async Task<int> CreateUnsafe(Customers customer)
        {
            string customerId = Guid.NewGuid().ToString();
            string contactId = Guid.NewGuid().ToString();

            string command = "INSERT INTO customers VALUES("
                + "'" + customerId + "',"
                + "'" + customer.name + "',"
                + "'" + customer.surname + "',"
                + "'" + customer.username + "',"
                + "'" + customer.password + "',"
                + "'" + contactId + "')";

            DatabaseAccess db = new DatabaseAccess();
            int result = await db.ExecuteNonQueryAsync(command);

            if (result == 1)
            {
                command = "Insert Into contact VALUES("
                    + "'" + contactId + "',"
                    + customer.contact.countryId + ","
                    + customer.contact.cityId + ","
                    + customer.contact.districtId + ","
                    + "'" + customer.contact.address + "',"
                    + "'" + customer.contact.phone + "',"
                    + "'" + customer.contact.description + "')"; //olmamalı

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
