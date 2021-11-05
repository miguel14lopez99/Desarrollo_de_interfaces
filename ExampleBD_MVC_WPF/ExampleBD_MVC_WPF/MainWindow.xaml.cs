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

namespace ExampleBD_MVC_WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Domain.User user = new Domain.User();
            user.name = "Miguel";
            user.password = "Lopez";

            user.insert();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Resources.useful useful = new Resources.useful();

            Domain.User user = new Domain.User();

            user.name = txtLogin.Text;
            user.password = useful.getHashSha256(txtPassw.Password);

            Boolean exist = user.check();

            if (exist)
            {
                MessageBox.Show("You are available in the database");
            }
            else
            {
                MessageBox.Show("User not found");
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
