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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LITTLE_ERP.SomeResources;

namespace LITTLE_ERP
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public void btnOK_Click(object sender, RoutedEventArgs e)
        {
            String login = txtLogin.Text;
            String pass = SomeResources.Useful.getHashSha256(pwdPassword.Password);

            User user = new User(login, pass);

            TabsWindow frm = null;

            Boolean exist = user.check(); //Checks if the user exist

            if (exist)
            {
                TabsWindow.SetUser = user;

                frm = new TabsWindow();
                frm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("User not found");
            }

        }

        public void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
