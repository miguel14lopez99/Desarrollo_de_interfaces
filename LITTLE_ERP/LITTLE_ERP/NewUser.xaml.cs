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

namespace LITTLE_ERP
{
    /// <summary>
    /// Lógica de interacción para NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        public NewUser()
        {
            InitializeComponent();

            //no mostrar cuando se abre la ventana
            lblError.Visibility = Visibility.Hidden;
        }

        private TabsWindow tabsWindow = null;
        public NewUser(Window callingForm)
        {
            tabsWindow = callingForm as TabsWindow;
            InitializeComponent();

            //no mostrar cuando se abre la ventana
            lblError.Visibility = Visibility.Hidden;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Resources.useful useful = new Resources.useful();

            //verificamos si ha introducido bien la contraseña

            if (txtPass.Password.Equals(txtRepPass.Password))
            {
                User aux = new User();

                aux.name = txtName.Text;

                aux.password = useful.getHashSha256(txtPass.Password);

                aux.insert();
                //actualizamos el data grid
                aux.readAll();
                this.tabsWindow.dgrUsers.ItemsSource = aux.manage.list;

                //cerrar la ventana cuando se crea el usuario
                this.Close();
            }
            else
            {
                lblError.Visibility = Visibility.Visible;
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
