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
        private TabsWindow tabsWindow = null;
        private Int64 orderID;

        public NewOrder(Window callingForm)
        {
            InitializeComponent();

            tabsWindow = callingForm as TabsWindow;

            //poner la id
            Order aux = new Order();
            int maximun = aux.manage.getTodayMaxID();
            orderID = Convert.ToInt64(DateTime.Today.ToString("yyyyMMdd") + maximun.ToString("0000"));

            txtID.Text = orderID.ToString();

            //cargar el combo
            PaymentMethod auxP = new PaymentMethod();
            auxP.ReadAll();
            cmbPayment.ItemsSource = auxP.manage.listP;
        }

        private void btnSearchC_Click(object sender, RoutedEventArgs e)
        {
            TabsWindow tabsWindow2 = new TabsWindow();
            tabsWindow2.tabHome.Visibility = Visibility.Collapsed;
            tabsWindow2.tabProfile.Visibility = Visibility.Collapsed;
            tabsWindow2.tabUsers.Visibility = Visibility.Collapsed;
            tabsWindow2.tabProduct.Visibility = Visibility.Collapsed;
            tabsWindow2.tabSupliers.Visibility = Visibility.Collapsed;
            tabsWindow2.tabOrder.Visibility = Visibility.Collapsed;
            tabsWindow2.tabCustomers.IsSelected = true;
            tabsWindow2.Hide();
            tabsWindow2.ShowDialog();
        }

        private void btnSearchP_Click(object sender, RoutedEventArgs e)
        {
            TabsWindow tabsWindow3 = new TabsWindow();
            tabsWindow3.tabHome.Visibility = Visibility.Collapsed;
            tabsWindow3.tabProfile.Visibility = Visibility.Collapsed;
            tabsWindow3.tabUsers.Visibility = Visibility.Collapsed;
            tabsWindow3.tabCustomers.Visibility = Visibility.Collapsed;
            tabsWindow3.tabSupliers.Visibility = Visibility.Collapsed;
            tabsWindow3.tabOrder.Visibility = Visibility.Collapsed;
            tabsWindow3.tabProduct.IsSelected = true;
            tabsWindow3.Hide();
            tabsWindow3.ShowDialog();
        }
    }


}
