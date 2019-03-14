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
            // bind detailed customer textboxes
            customerBindingSource.DataSource = customers;
        }

        private void customerBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            // 1: LINQ Way
            var customerOrders = from o in orders
                                 where o.CustomerID == customerIDComboBox.Text
                                 orderby o.OrderDate
                                 select o;

            // 2: foreach Way
            /*var ordersOfCurrentCust = new List<Order>();
            foreach (var o in orders)
            {
                if (o.CustomerID == customerIDComboBox.Text)
                    ordersOfCurrentCust.Add(o);
            }*/

            ordersBindingSource.DataSource = customerOrders;
        }

    }
}
