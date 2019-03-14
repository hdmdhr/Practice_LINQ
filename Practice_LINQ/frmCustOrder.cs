using NorthwindData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_LINQ
{
    public partial class frmCustOrder : Form
    {
        List<Order> orders = OrderDB.GetOrders();
        List<Customer> customers = CustomerDB.GetCustomers();

        public frmCustOrder()
        {
            InitializeComponent();
        }

        private void frmCustOrder_Load(object sender, EventArgs e)
        {
            // bind data grid view
            
            // bind detailed customer textboxes
            customerBindingSource.DataSource = customers;


            // joining tables
            //var invoices = from c in customers
            //               join o in orders
            //               on c.CustomerID equals o.CustomerID
            //               orderby c.ContactName, o.OrderDate descending
            //               select new
            //               {
            //                   c.ContactName,
            //                   o.OrderID,
            //                   o.EmployeeID,
            //                   o.OrderDate,
            //                   o.ShippedDate
            //               };

        }

        private void customerBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(customerIDComboBox.Text);
            //var customerOrders = from o in orders
            //           where o.CustomerID == customerIDComboBox.Text
            //           orderby o.OrderDate
            //           select new
            //           {
            //               o.OrderID,
            //               o.CustomerID,
            //               o.EmployeeID,
            //               o.OrderDate,
            //               o.RequiredDate,
            //               o.ShippedDate,
            //               o.ShipVia,
            //               o.Freight,
            //               o.ShipName,
            //               o.ShipAddress,
            //               o.ShipCity,
            //               o.ShipRegion,
            //               o.ShipPostalCode,
            //               o.ShipCountry
            //           };

            var ordersOfCurrentCust = new List<Order>();
            foreach (var o in orders)
            {
                if (o.CustomerID == customerIDComboBox.Text)
                    ordersOfCurrentCust.Add(o);
            }
            ordersBindingSource.DataSource = ordersOfCurrentCust;
        }
    }
}
