using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindData
{
    public static class CustomerDB
    {
        static string str = @"Data Source=localhost\sqlexpress;Initial Catalog=Northwind;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(str);

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            var sqlText = "SELECT * FROM Customers";
            SqlCommand selectCmd = new SqlCommand(sqlText, connection);
            // execute
            connection.Open();
            SqlDataReader dr = selectCmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                var c = new Customer();
                c.CustomerID = (string)dr[0];
                c.CompanyName = (string)dr[1];
                c.ContactName = dr[2] == DBNull.Value ? "" : (string)dr[2];
                c.ContactTitle = dr[3] == DBNull.Value ? "" : (string)dr[3];
                c.Address = dr[4] == DBNull.Value ? "" : (string)dr[4];
                c.City = dr[5] == DBNull.Value ? "" : (string)dr[5];
                c.Region = dr[6] == DBNull.Value ? "" : (string)dr[6];
                c.PostalCode = dr[7] == DBNull.Value ? "" : (string)dr[7];
                c.Country = dr[8] == DBNull.Value ? "" : (string)dr[8];
                c.Phone = dr[9] == DBNull.Value ? "" : (string)dr[9];
                c.Fax = dr[10] == DBNull.Value ? "" : (string)dr[10];

                customers.Add(c);
            }
            dr.Close();

            return customers;
        }
    }
}
