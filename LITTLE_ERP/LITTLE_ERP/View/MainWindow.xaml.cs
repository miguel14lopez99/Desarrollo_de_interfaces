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
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// 
        /// Checks if the user exists in the database, if exist open the program, 
        /// but otherwise an error is thrown
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        public void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
