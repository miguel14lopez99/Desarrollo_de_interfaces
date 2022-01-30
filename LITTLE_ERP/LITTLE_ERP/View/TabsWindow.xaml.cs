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
using LITTLE_ERP.Domain;

namespace LITTLE_ERP
{
    /// <summary>
    /// Lógica de interacción para TabsWindow.xaml
    /// </summary>
    public partial class TabsWindow : Window
    {
        private static User setUser;
        private static DataGrid setDataGrid;
        internal static User SetUser { get => setUser; set => setUser = value; }
        internal static DataGrid SetDataGrid { get => setDataGrid; set => setDataGrid = value; }

        private static Boolean isCustomerMod;
        private static int idCustomerMod;

        private static Boolean isProductMod;
        private static int idProductMod;

        public TabsWindow()
        {
            DateTime ahora = DateTime.Now;

            InitializeComponent();

            //set the connected user name and time
            lblUserName.Content = "Name: " + SetUser.name;
            lblDate.Content = "Date: " + ahora.ToString("G");
            lblUsername.Content = SetUser.name;

            //the use of the application is restricted to different users
            if (setUser.idUser != 1) //root
            {
                if (!setUser.userPermissions.usersAccess)
                    tabUsers.IsEnabled = false;
                else
                {
                    if (!setUser.userPermissions.addUser)
                        btnAdd.IsEnabled = false;
                    if (!setUser.userPermissions.deleteUser)
                        btnDelete.IsEnabled = false;
                    if (!setUser.userPermissions.editUser)
                        btnModify.IsEnabled = false;
                }
                
            }
            if (setUser.userPermissions.showUser || setUser.idUser == 1)
            {
                User aux = new User();
                aux.readAll();
                dgrUsers.ItemsSource = aux.manage.list;
            }
            if (setUser.userPermissions.showCustomers)
            {
                btnNewCustomer.IsEnabled = false;
                btnDeleteCustomer.IsEnabled = false;
                btnSave.IsEnabled = false;
            }
            if (setUser.userPermissions.showProducts)
            {
                btnP_New.IsEnabled = false;
                btnP_Del.IsEnabled = false;
                btnP_Save.IsEnabled = false;
            }

            //update roles
            String sRoles = "";

            foreach (Rol rol in setUser.rolesList)
            {
                sRoles += rol.description + "\n";
            }
            LblRoles.Content = sRoles;

            ///
            /// CUSTOMERS
            ///

            //Recuperar regiones
            //mientras no elijas un region los demás combos estarian deshabilitados

            Region auxR = new Region();
            auxR.ReadAll();
            cmbRegion.ItemsSource = auxR.manage.listR;

            Customer auxC = new Customer();
            auxC.ReadAll();
            dgrCustomers.ItemsSource = auxC.manage.list;
            
            //inicializo el id del customer selecionado a 0
            idCustomerMod = 0;

            ///
            /// PRODUCTS
            ///

            Product auxP = new Product();
            auxP.ReadAll();
            dgrProducts.ItemsSource = auxP.manage.list;

            Form auxF = new Form();
            auxF.ReadAll();
            cmbP_Form.ItemsSource = auxF.manage.listF;

            Ingredient auxI = new Ingredient();
            auxI.ReadAll();
            cmbP_Ingredient.ItemsSource = auxI.manage.listI;

            //inicializo el id del customer selecionado a 0
            idProductMod = 0;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }

        ///
        /// USERS
        ///

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewUser.SetUser = setUser;
            NewUser.IsMod = false;
            User aux = new User();

            aux.readAll();

            //show the new user window
            NewUser newUserWindow = new NewUser(this);
            newUserWindow.Show();

            //update the user list
            dgrUsers.ItemsSource = aux.manage.list;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {          
            List<User> data = new List<User>();
            int indice = 0;
            if (dgrUsers.SelectedItems.Count > 0)
            {
                data = (List<User>)dgrUsers.ItemsSource;

                for (int i = 0; i < dgrUsers.SelectedItems.Count; i++)
                {
                    indice = dgrUsers.Items.IndexOf(dgrUsers.SelectedItems[i]);
                    data.RemoveAt(indice);
                    User row = (User)dgrUsers.SelectedItems[i];
                    row.delete();
                }
                dgrUsers.ItemsSource = null;
                dgrUsers.ItemsSource = data;
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            if (dgrUsers.SelectedItems.Count == 1)
            {
                User modUser = (User)dgrUsers.SelectedItem;
                if (SetUser.idUser != modUser.idUser)
                {
                    NewUser.SetUser = setUser;
                    NewUser.IsMod = true;
                    NewUser.UserMod = modUser;

                    //show new user window with changes
                    NewUser newUserWindow = new NewUser(this);
                    newUserWindow.Show();
                } 
                else
                {
                    MessageBox.Show("You can't modify your data");
                }

            }
            else
            {
                MessageBox.Show("You must select only one row");
            }
        }

        ///
        /// PROFILE
        ///

        private void btnChangePwd_Click(object sender, RoutedEventArgs e)
        {
            //check if the previous password is the same as the user password
            if (!SomeResources.Useful.getHashSha256(pwdPrevious.Password).Equals(setUser.password))
            {
                MessageBox.Show("The previous password is incorrect");
            }
            //check if the new password matches
            else if (!pwdNew.Password.Equals(pwdRepeat.Password))
            {
                MessageBox.Show("The new password must match");
            }
            else
            {
                setUser.updatePass(pwdNew.Password);
                MessageBox.Show("Password Changed");
                pwdPrevious.Password = "";
                pwdNew.Password = "";
                pwdRepeat.Password = "";
            }      
        }

        ///
        /// CUSTOMERS
        ///

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Customer aux = new Customer();

            if (isCustomerMod)
                aux.idCustomer = idCustomerMod;

            aux.NIF = txtNIF.Text;
            aux.name = txtName.Text;
            aux.surname = txtSurname.Text;
            aux.address = txtAddress.Text;
            aux.phone = txtPhone.Text;
            aux.email = txtEmail.Text;

            aux.zipcode = (ZipCode) cmbZipCode.SelectedItem;

            if (!isCustomerMod)
                aux.Insert();
            else
                aux.Update();
            
            aux.ReadAll();
            dgrCustomers.ItemsSource = aux.manage.list;

        }

        private void cmbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Region region = (Region)cmbRegion.SelectedItem;

            State auxS = new State();
            auxS.ReadAll(region);
            cmbState.ItemsSource = auxS.manage.listS;

        }

        private void cmbState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            State state = (State)cmbState.SelectedItem;

            City auxC = new City();
            auxC.ReadAll(state);
            cmbCity.ItemsSource = auxC.manage.listC;

        }

        private void cmbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            City city = (City)cmbCity.SelectedItem;

            ZipCode auxZ = new ZipCode();
            auxZ.ReadAll(city);
            cmbZipCode.ItemsSource = auxZ.manage.listZ;
            
            if(auxZ.manage.listZ.Count == 1)
            {
                txtZipCode.Text = auxZ.manage.listZ[0].name.ToString();
                cmbZipCode.SelectedItem = auxZ.manage.listZ[0];
            }
            
        }

        private void cmbZipCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ZipCode zipCode = (ZipCode)cmbZipCode.SelectedItem;

            if(zipCode != null)
            {
                txtZipCode.Text = zipCode.name.ToString();
            }

        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            List<Customer> data = new List<Customer>();
            int indice = 0;
            if (dgrCustomers.SelectedItems.Count > 0)
            {
                data = (List<Customer>)dgrCustomers.ItemsSource;

                for (int i = 0; i < dgrCustomers.SelectedItems.Count; i++)
                {
                    indice = dgrCustomers.Items.IndexOf(dgrCustomers.SelectedItems[i]);
                    data.RemoveAt(indice);
                    Customer row = (Customer)dgrCustomers.SelectedItems[i];
                    row.Delete();
                }
                dgrCustomers.ItemsSource = null;
                dgrCustomers.ItemsSource = data;
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }

        private void dgrCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Customer aux = (Customer)dgrCustomers.SelectedItem;

            if(aux != null)
            {
                idCustomerMod = aux.idCustomer;

                txtNIF.Text = aux.NIF;
                txtName.Text = aux.name;
                txtSurname.Text = aux.surname;
                txtPhone.Text = aux.phone;
                txtEmail.Text = aux.email;
                txtAddress.Text = aux.address;

                List<Region> lRegions = (List<Region>)cmbRegion.ItemsSource;
                cmbRegion.SelectedIndex = lRegions.IndexOf(aux.region);

                List<State> lStates = (List<State>)cmbState.ItemsSource;
                cmbState.SelectedIndex = lStates.IndexOf(aux.state);

                List<City> lCities = (List<City>)cmbCity.ItemsSource;
                cmbCity.SelectedIndex = lCities.IndexOf(aux.city);

                List<ZipCode> lZipCodes = (List<ZipCode>)cmbZipCode.ItemsSource;
                cmbZipCode.SelectedIndex = lZipCodes.IndexOf(aux.zipcode);
                txtZipCode.Text = aux.zipcode.name;

                isCustomerMod = true;
            }
           
        }

        private void txtZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtZipCode.Text.Length == 5)
            {
                Customer aux = new Customer();
                ZipCode zip = new ZipCode();
                zip.name = txtZipCode.Text;
                aux.setZipCodesCities(zip); //set refZipCodesCities

                if(aux.refZipCodesCities != 0)
                {
                    aux.setZipCityStateRegion(); //set Zip, City, State and Region

                    List<Region> lRegions = (List<Region>)cmbRegion.ItemsSource;
                    cmbRegion.SelectedIndex = lRegions.IndexOf(aux.region);

                    List<State> lStates = (List<State>)cmbState.ItemsSource;
                    cmbState.SelectedIndex = lStates.IndexOf(aux.state);

                    List<City> lCities = (List<City>)cmbCity.ItemsSource;
                    cmbCity.SelectedIndex = lCities.IndexOf(aux.city);

                    List<ZipCode> lZipCodes = (List<ZipCode>)cmbZipCode.ItemsSource;
                    cmbZipCode.SelectedIndex = lZipCodes.IndexOf(aux.zipcode);
                }

            }

        }

        private void btnNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            txtNIF.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            cmbRegion.SelectedItem = null;
            cmbState.SelectedItem = null;
            cmbCity.SelectedItem = null;
            cmbZipCode.SelectedItem = null;
            txtZipCode.Text = "";

            isCustomerMod = false;

        }

        ///
        /// PRODUCTS
        ///

        private void dgrProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product aux = (Product)dgrProducts.SelectedItem;

            if (aux != null)
            {
                idProductMod = aux.idProduct;

                txtP_Price.Text = aux.price.ToString();

                //List<Form> lForms = (List<Form>)cmbP_Form.ItemsSource;
                cmbP_Form.SelectedIndex = aux.idForm - 1; //lForms.IndexOf(aux.form);

                //List<Ingredient> lIngredients = (List<Ingredient>)cmbP_Ingredient.ItemsSource;
                cmbP_Ingredient.SelectedIndex = aux.idIngredient - 1; //lIngredients.IndexOf(aux.ingredient);

                isProductMod = true;
            }
        }

        private void btnP_Save_Click(object sender, RoutedEventArgs e)
        {
            Product aux = new Product();

            if (isProductMod)
                aux.idProduct = idProductMod;

            aux.price = Convert.ToDouble(txtP_Price.Text);
            aux.idForm = cmbP_Form.SelectedIndex + 1;
            aux.idIngredient = cmbP_Ingredient.SelectedIndex + 1;

            if (!isProductMod)
                aux.Insert();
            else
                aux.Update();

            aux.ReadAll();
            dgrProducts.ItemsSource = aux.manage.list;
        }

        private void btnP_New_Click(object sender, RoutedEventArgs e)
        {
            txtP_Price.Text = "";
            cmbP_Form.SelectedItem = null;
            cmbP_Ingredient.SelectedItem = null;

            isProductMod = false;
        }

        private void btnP_Del_Click(object sender, RoutedEventArgs e)
        {
            List<Product> data = new List<Product>();
            int indice = 0;
            if (dgrProducts.SelectedItems.Count > 0)
            {
                data = (List<Product>)dgrProducts.ItemsSource;

                for (int i = 0; i < dgrProducts.SelectedItems.Count; i++)
                {
                    indice = dgrProducts.Items.IndexOf(dgrProducts.SelectedItems[i]);
                    data.RemoveAt(indice);
                    Product row = (Product)dgrProducts.SelectedItems[i];
                    row.Delete();
                }
                dgrProducts.ItemsSource = null;
                dgrProducts.ItemsSource = data;
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }
    }
}
