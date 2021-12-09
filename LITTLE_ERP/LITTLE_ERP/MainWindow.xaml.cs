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

            //Domain.User user = new Domain.User();
            //user.name = "Luis";
            //user.password = "ssss";
            //user.insert();
        }

        public void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Resources.useful useful = new Resources.useful();

            Domain.User user = new Domain.User();

            TabsWindow frm = null;

            user.name = txtLogin.Text;
            user.password = useful.getHashSha256(pwdPassword.Password);

            Boolean exist = user.check();

            if (exist)
            {
                //asigna el usuario introducido al usuario conectado

                TabsWindow.SetUser = user;
                frm = new TabsWindow();
                frm.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("User not found");
                txtLogin.Text = user.password;
            }

        }

        public void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
