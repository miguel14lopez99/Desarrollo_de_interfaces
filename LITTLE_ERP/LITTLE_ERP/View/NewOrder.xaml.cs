using LITTLE_ERP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LITTLE_ERP.View
{
    /// <summary>
    /// Lógica de interacción para NewOrder.xaml
    /// </summary>  
    public partial class NewOrder : Window
    {
        private static Order order;

        private TabsWindow tabsWindow = null;

        private static Product product;
        private static Customer customer;
        private static User user;
        private static Boolean newInvoice;

        internal static Product Product { get => product; set => product = value; }
        internal static Customer Customer { get => customer; set => customer = value; }
        internal static User User { get => user; set => user = value; }
        internal static Order Order { get => order; set => order = value; }
        public static bool NewInvoice { get => newInvoice; set => newInvoice = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewOrder"/> class.
        /// 
        /// Without parameters only shows the order data
        /// </summary>
        public NewOrder()
        {
            InitializeComponent();

            //disable some controls
            btnSearchC.IsEnabled = false;
            btnSearchP.IsEnabled = false;
            cmbPayment.IsEnabled = true;
            txtPrepaid.IsEnabled = false;
            btnP_New.IsEnabled = false;
            btnP_Del.IsEnabled = false;
            chkGeneric.IsEnabled = false;
            txtPrice.IsEnabled = false;
            txtAmount.IsEnabled = false;
            btnSaveProduct.IsEnabled = false;
            btnSaveOrder.IsEnabled = false;

            //load the data
            txtID.Text = Order.idOrder.ToString();
            txtCustomer.Text = Order.customer.name;
            cmbPayment.Items.Add(Order.payment);
            cmbPayment.SelectedItem = Order.payment;
            txtPrepaid.Text = Order.prepaid.ToString();
            dgrProducts.ItemsSource = Order.listOP;   

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewOrder"/> class.
        /// 
        /// Initializes the form to create orders but if this window 
        /// is created from the Invoice tab, is modified to create invoices
        /// </summary>
        /// <param name="callingForm">The calling form.</param>
        public NewOrder(Window callingForm)
        {
            InitializeComponent();

            tabsWindow = callingForm as TabsWindow;

            //put id
            Order aux = new Order();
            int maximun = aux.manage.getMaxOrderID();
            Int64 orderID = Convert.ToInt64(DateTime.Today.ToString("yyyyMMdd") + maximun.ToString("0000"));
            Order = new Order(orderID);           

            txtID.Text = orderID.ToString();

            //load combo
            PaymentMethod auxP = new PaymentMethod();
            auxP.ReadAll();
            cmbPayment.ItemsSource = auxP.manage.listP;

            //initialize the order
            Order = new Order();

            //If this window is open from the invoice tab, it changes the id format
            if (NewInvoice)
            {
                maximun = aux.manage.getMaxInvoiceID();
                Int64 invoiceID = Convert.ToInt64(DateTime.Today.ToString("yyyy") + maximun.ToString("0000"));

                txtID.Text = invoiceID.ToString();
            }
      
        }

        /// <summary>
        /// Handles the Click event of the btnSearchC control.
        /// 
        /// Opens the customers tab to select a customer
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSearchC_Click(object sender, RoutedEventArgs e)
        {
            TabsWindow tabsWindow2 = new TabsWindow();

            tabsWindow2.isSelectingCustomers = true;

            tabsWindow2.tabHome.Visibility = Visibility.Collapsed;
            tabsWindow2.tabProfile.Visibility = Visibility.Collapsed;
            tabsWindow2.tabUsers.Visibility = Visibility.Collapsed;
            tabsWindow2.tabProduct.Visibility = Visibility.Collapsed;
            tabsWindow2.tabSupliers.Visibility = Visibility.Collapsed;
            tabsWindow2.tabOrder.Visibility = Visibility.Collapsed;
            tabsWindow2.tabCustomers.IsSelected = true;
            tabsWindow2.Hide();
            tabsWindow2.ShowDialog();

            txtCustomer.Text = customer.name;
        }

        /// <summary>
        /// Handles the Click event of the btnSearchP control.
        /// 
        /// Opens the products tab to select a product
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnSearchP_Click(object sender, RoutedEventArgs e)
        {
            TabsWindow tabsWindow3 = new TabsWindow();

            tabsWindow3.isSelectingProducts = true;

            tabsWindow3.tabHome.Visibility = Visibility.Collapsed;
            tabsWindow3.tabProfile.Visibility = Visibility.Collapsed;
            tabsWindow3.tabUsers.Visibility = Visibility.Collapsed;
            tabsWindow3.tabCustomers.Visibility = Visibility.Collapsed;
            tabsWindow3.tabSupliers.Visibility = Visibility.Collapsed;
            tabsWindow3.tabOrder.Visibility = Visibility.Collapsed;
            tabsWindow3.tabProduct.IsSelected = true;
            tabsWindow3.Hide();
            tabsWindow3.ShowDialog();

            txtProduct.Text = product.ToString();
            txtPrice.Text = product.price.ToString();

        }

        /// <summary>
        /// Handles the Click event of the btnSaveProduct control.
        /// 
        /// Add the product to the order datagrid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            OrderProducts orderProduct = new OrderProducts();

            orderProduct.idOrder = Order.idOrder; //Convert.ToInt64(txtID.Text);

            if (chkGeneric.IsChecked.Value == true)
            {
                orderProduct.idProduct = -1;
            }
            else
            {
                orderProduct.idProduct = product.idProduct;
            }

            orderProduct.description = txtProduct.Text;
            orderProduct.pricesale = Convert.ToDouble(txtPrice.Text);
            orderProduct.amount = Convert.ToInt32(txtAmount.Text);

            //display de product in the datagrid
            Order.listOP.Add(orderProduct);

            dgrProducts.ItemsSource = null;
            dgrProducts.ItemsSource = Order.listOP;
        }

        /// <summary>
        /// Handles the Checked event of the chkGeneric control.
        /// 
        /// Modify the form to add generic products
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private void chkGeneric_Checked(object sender, RoutedEventArgs e)
        {
            btnSearchP.Visibility = Visibility.Hidden;
            txtProduct.Text = "";
            txtPrice.Text = "";
            txtAmount.Text = "1";
            lblProduct.Content = "Description:";
            txtProduct.Height = 90;
            txtProduct.IsEnabled = true;
        }

        /// <summary>
        /// Handles the Unchecked event of the chkGeneric control.
        /// 
        /// Modify the form to add products from the database
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private void chkGeneric_Unchecked(object sender, RoutedEventArgs e)
        {
            btnSearchP.Visibility = Visibility.Visible;
            txtProduct.Text = "";
            txtPrice.Text = "";
            txtAmount.Text = "1";
            lblProduct.Content = "Product:";
            txtProduct.Height = 20;
            txtProduct.IsEnabled = false;
        }

        /// <summary>
        /// Handles the Click event of the btnP_New control.
        /// 
        /// Empty the form to introduce a new product
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private void btnP_New_Click(object sender, RoutedEventArgs e)
        {
            txtProduct.Text = "";
            txtPrice.Text = "";
            txtAmount.Text = "1";
        }

        /// <summary>
        /// Handles the Click event of the btnP_Del control.
        /// 
        /// Delete the selected product from the order datagrid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnP_Del_Click(object sender, RoutedEventArgs e)
        {
            List<OrderProducts> data = new List<OrderProducts>();
            int indice = 0;
            if (dgrProducts.SelectedItems.Count > 0)
            {
                data = (List<OrderProducts>)dgrProducts.ItemsSource;

                for (int i = 0; i < dgrProducts.SelectedItems.Count; i++)
                {
                    indice = dgrProducts.Items.IndexOf(dgrProducts.SelectedItems[i]);
                    data.RemoveAt(indice);
                }
                dgrProducts.ItemsSource = null;
                dgrProducts.ItemsSource = data;
                Order.listOP = data;
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSaveOrder control.
        /// 
        /// Save the order in the orders datagrid, but if the window 
        /// has been called from the invoices tab, it also saves the 
        /// invoice in the invoices datagrid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            int maximun = Order.manage.getMaxOrderID();
            Int64 orderID = Convert.ToInt64(DateTime.Today.ToString("yyyyMMdd") + maximun.ToString("0000"));

            Order.idOrder = orderID;
            Order.idCustomer = customer.idCustomer;
            Order.idUser = user.idUser;
            Order.datetime = DateTime.Today;
            if(txtPrepaid.Text.Length != 0)
                Order.prepaid = Convert.ToDouble(txtPrepaid.Text);
            Order.customer = customer;
            Order.user = user;

            //payment
            PaymentMethod paymentMethod = (PaymentMethod)cmbPayment.SelectedItem;
            Order.payment = paymentMethod;
            Order.idPaymentMethod = paymentMethod.id;

            //total
            double sum = 0;
            foreach (OrderProducts product in Order.listOP)
            {
                sum = sum + (product.amount * product.pricesale);
            }
            Order.total = sum - Order.prepaid;

            //status
            if (paymentMethod.name.Equals("Cash on Delivery"))
            {  
                Order.status.confirmed = true;
            }

            Order.Insert();

            Order.ReadAll();
            tabsWindow.dgrOrders.ItemsSource = Order.manage.list;

            //If this window is open from the invoice tab...
            if (NewInvoice)
            {
                Order.status.confirmed = true;
                Order.status.labeled = true;
                Order.status.sent = true;
                Order.status.invoiced = true;

                Order.UpdateOrderStatus();

                Invoice invoice = new Invoice();
                invoice.id = Convert.ToInt64(txtID.Text);
                invoice.date = Order.datetime;
                invoice.order = Order;

                invoice.Insert();
                invoice.ReadAll();
                tabsWindow.dgrInvoices.ItemsSource = invoice.manage.listI;

                NewInvoice = false;
            }

            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }


}
