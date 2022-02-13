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

        internal static Product Product { get => product; set => product = value; }
        internal static Customer Customer { get => customer; set => customer = value; }
        internal static User User { get => user; set => user = value; }
        internal static Order Order { get => order; set => order = value; }

        public NewOrder()
        {
            InitializeComponent();

            //disable some controls
            btnSearchC.IsEnabled = false;
            btnSearchP.IsEnabled = false;
            cmbPayment.IsEnabled = false;
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
            cmbPayment.SelectedItem = Order.payment;
            txtPrepaid.Text = Order.prepaid.ToString();
            dgrProducts.ItemsSource = Order.listOP;   

        }

        public NewOrder(Window callingForm)
        {
            InitializeComponent();

            tabsWindow = callingForm as TabsWindow;

            //put id
            Order aux = new Order();
            int maximun = aux.manage.getTodayMaxID();
            Int64 orderID = Convert.ToInt64(DateTime.Today.ToString("yyyyMMdd") + maximun.ToString("0000"));

            txtID.Text = orderID.ToString();

            //load combo
            PaymentMethod auxP = new PaymentMethod();
            auxP.ReadAll();
            cmbPayment.ItemsSource = auxP.manage.listP;

            //initialize the order
            Order = new Order();
        }

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

        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            OrderProducts orderProduct = new OrderProducts();

            orderProduct.idOrder = Convert.ToInt64(txtID.Text);

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

        private void btnP_New_Click(object sender, RoutedEventArgs e)
        {
            txtProduct.Text = "";
            txtPrice.Text = "";
            txtAmount.Text = "1";
        }

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
                    /*OrderProducts row = (OrderProducts)dgrProducts.SelectedItems[i];
                    int listIndex = order.listOP.IndexOf(row);
                    order.listOP = order.listOP;
                    order.listOP.RemoveAt(listIndex);*/
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

        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            Order.idOrder = Convert.ToInt64(txtID.Text);
            Order.idCustomer = customer.idCustomer;
            Order.idUser = user.idUser;
            Order.datetime = DateTime.Now;
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
            Order.InsertOrderProducts();
            Order.InsertOrderStatus();

            Order.ReadAll();
            tabsWindow.dgrOrders.ItemsSource = Order.manage.list;

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }


}
