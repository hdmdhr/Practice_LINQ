using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindData
{
    public static class OrderDB
    {
        static string str = @"Data Source=localhost\sqlexpress;Initial Catalog=Northwind;Integrated Security=True";
        static SqlConnection connection = new SqlConnection(str);

        public static List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            var sqlText = "SELECT * FROM Orders";
            SqlCommand selectCmd = new SqlCommand(sqlText, connection);
            // execute
            connection.Open();
            SqlDataReader dr = selectCmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
                var o = new Order();
                o.OrderID = (int)dr["OrderID"];
                o.CustomerID = dr[1] == DBNull.Value ? "" : dr["CustomerID"].ToString();
                o.EmployeeID = dr[2] == DBNull.Value ? 0 : (int)dr[2];

                if (dr[3] == DBNull.Value)
                    o.OrderDate = null;
                else
                    o.OrderDate = (DateTime)dr[3];

                if (dr[4] == DBNull.Value)
                    o.RequiredDate = null;
                else
                    o.RequiredDate = (DateTime)dr[4];


                if (dr[5] == DBNull.Value)
                    o.ShippedDate = null;
                else
                    o.ShippedDate = (DateTime)dr[5];
                o.ShipVia = dr[6] == DBNull.Value ? 0 : (int)dr[6];
                o.Freight = dr[7] == DBNull.Value ? 0 : (decimal)dr[7];
                o.ShipName = dr[8] == DBNull.Value ? "" : (string)dr[8];
                o.ShipAddress = dr[9] == DBNull.Value ? "" : (string)dr[9];
                o.ShipCity = dr[10] == DBNull.Value ? "" : (string)dr[10];
                o.ShipRegion = dr[11]==DBNull.Value ? "" : (string)dr[11];
                o.ShipPostalCode = dr[12] == DBNull.Value ? "" : (string)dr[12];
                o.ShipCountry = dr[13] == DBNull.Value ? "" : (string)dr[13];

                orders.Add(o);
            }
            dr.Close();


            return orders;
        }
    }
}
