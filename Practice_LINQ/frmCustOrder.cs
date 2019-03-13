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
        public frmCustOrder()
        {
            InitializeComponent();
        }

        private void frmCustOrder_Load(object sender, EventArgs e)
        {
            var orders = OrderDB.GetOrders();
            var customers = CustomerDB.GetCustomers();
            // bind data grid view
            
            // bind detailed customer textboxes
            customerBindingSource.DataSource = customers;


            // joining tables
            var invoices = from c in customers
                           join o in orders
                           on c.CustomerID equals o.CustomerID
                           orderby c.ContactName, o.OrderDate descending
                           select new { };

            //foreach (var c in customers)
            //{
            //    Debug.WriteLine(c.CustomerID.ToString());
            //}
        }
    }
}
