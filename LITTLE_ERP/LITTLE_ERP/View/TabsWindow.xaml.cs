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
using LITTLE_ERP.View;

namespace LITTLE_ERP
{
    /// <summary>
    /// Lógica de interacción para TabsWindow.xaml
    /// </summary>
    public partial class TabsWindow : Window
    {
        private static User setUser;
        internal static User SetUser { get => setUser; set => setUser = value; }

        private static Boolean isCustomerMod;
        private static int idCustomerMod;

        private static Boolean isProductMod;
        private static int idProductMod;

        public Boolean isSelectingProducts { get; set; }
        public Boolean isSelectingCustomers { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TabsWindow"/> class.
        /// 
        /// Initialize the forms of each of the tabs and load all
        /// the necessary data from the database
        /// </summary>
        public TabsWindow()
        {
            DateTime ahora = DateTime.Now;

            InitializeComponent();

            //
            // USERS
            //

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
            if (setUser.userPermissions.showOrders)
            {
                btnO_New.IsEnabled = false;
                btnO_Del.IsEnabled = false;
            }
            if (setUser.userPermissions.showInvoices)
            {
                btnI_Add.IsEnabled = false;
                btnI_Delete.IsEnabled = false;
            }

            //update roles
            String sRoles = "";

            foreach (Rol rol in setUser.rolesList)
            {
                sRoles += rol.description + "\n";
            }
            LblRoles.Content = sRoles;

            //
            // CUSTOMERS
            //

            //Retrieve regions
            //as long as you don't choose a region the other combos would be disabled

            Region auxR = new Region();
            auxR.ReadAll();
            cmbRegion.ItemsSource = auxR.manage.listR;

            Customer auxC = new Customer();
            auxC.ReadAll();
            dgrCustomers.ItemsSource = auxC.manage.list;

            //I initialize the id of the selected customer to 0
            idCustomerMod = 0;

            //
            // PRODUCTS
            //

            Product auxP = new Product();
            auxP.ReadAll();
            dgrProducts.ItemsSource = auxP.manage.list;

            Form auxF = new Form();
            auxF.ReadAll();
            cmbP_Form.ItemsSource = auxF.manage.listF;

            Ingredient auxI = new Ingredient();
            auxI.ReadAll();
            cmbP_Ingredient.ItemsSource = auxI.manage.listI;

            //I initialize the id of the selected customer to 0
            idProductMod = 0;

            //
            // SUPLIERS
            //

            Suplier auxS = new Suplier();
            auxS.ReadAll();
            dgrSupliers.ItemsSource = auxS.manage.list;

            //
            // ORDERS
            //

            Order auxO = new Order();
            auxO.ReadAll();
            dgrOrders.ItemsSource = auxO.manage.list;

            //
            // INVOICES
            //

            Invoice auxIn = new Invoice();
            auxIn.ReadAll();
            dgrInvoices.ItemsSource = auxIn.manage.listI;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            this.Close();
        }

        //
        // USERS
        //

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// 
        /// Open the form to create a new user
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the btnDelete control.
        /// 
        /// Delete the selected user
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the btnModify control.
        /// 
        /// Open the form to modify the user
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the TextChanged event of the txtU_Search control.
        /// 
        /// Search among the database users
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void txtU_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            User aux = new User();

            if (txtU_Search.Text.Length != 0)
            {
                String pattern = txtU_Search.Text;

                aux.manage.setSelectedList(pattern);
                dgrUsers.ItemsSource = aux.manage.selectedList;
            }
            else
            {
                aux.readAll();
                dgrUsers.ItemsSource = aux.manage.list;
            }
        }

        //
        // PROFILE
        //

        /// <summary>
        /// Handles the Click event of the btnChangePwd control.
        /// 
        /// Change the password of the logged in user
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        //
        // CUSTOMERS
        //

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// 
        /// Save the customer in the database and in the datagrid customer
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the SelectionChanged event of the cmbRegion control.
        /// 
        /// Assign client region
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void cmbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Region region = (Region)cmbRegion.SelectedItem;

            State auxS = new State();
            auxS.ReadAll(region);
            cmbState.ItemsSource = auxS.manage.listS;

        }

        /// <summary>
        /// Handles the SelectionChanged event of the cmbState control.
        /// 
        /// Assign client state 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private void cmbState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            State state = (State)cmbState.SelectedItem;

            City auxC = new City();
            auxC.ReadAll(state);
            cmbCity.ItemsSource = auxC.manage.listC;

        }

        /// <summary>
        /// Handles the SelectionChanged event of the cmbCity control.
        /// 
        /// Assign client city
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Handles the SelectionChanged event of the cmbZipCode control.
        /// 
        /// Assign client zip code
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private void cmbZipCode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ZipCode zipCode = (ZipCode)cmbZipCode.SelectedItem;

            if(zipCode != null)
            {
                txtZipCode.Text = zipCode.name.ToString();
            }

        }

        /// <summary>
        /// Handles the Click event of the btnDeleteCustomer control.
        /// 
        /// Deletes the customer
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the SelectionChanged event of the dgrCustomers control.
        /// 
        /// Load in the form the data of the selected customer
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Handles the TextChanged event of the txtZipCode control.
        /// 
        /// Select the region, the state, the city through the entered zip code
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the btnNewCustomer control.
        /// 
        /// Empty the form to be able to save a new customer
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the TextChanged event of the txtCustomerSearch control.
        /// 
        /// Search among all customers
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void txtCustomerSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Customer aux = new Customer();

            if (txtCustomerSearch.Text.Length != 0)
            {
                String pattern = txtCustomerSearch.Text;

                aux.manage.setSelectedList(pattern);
                dgrCustomers.ItemsSource = aux.manage.selectedList;
            }
            else
            {
                aux.ReadAll();
                dgrCustomers.ItemsSource = aux.manage.list;
            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the CustomerRow control.
        /// 
        /// Load the user selected in the order form
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void CustomerRow_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (isSelectingCustomers)
            {
                DataGridRow row = sender as DataGridRow;

                Customer aux = (Customer)row.Item;
                NewOrder.Customer = aux;

                this.Close();
            }

        }

        /// <summary>
        /// Handles the Click event of the btnFill control.
        /// 
        /// Inserts 10000 customers in the program
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            Customer aux = new Customer();
            aux.manage.Test10000Customers();
            aux.ReadAll();
            dgrCustomers.ItemsSource = aux.manage.list;
        }

        //
        // PRODUCTS
        //

        /// <summary>
        /// Handles the SelectionChanged event of the dgrProducts control.
        /// 
        /// Load the form with the product data
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void dgrProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product aux = (Product)dgrProducts.SelectedItem;

            if (aux != null)
            {
                idProductMod = aux.idProduct;

                txtP_Price.Text = aux.price.ToString();
                txtP_Amount.Text = aux.amount.ToString();

                cmbP_Form.SelectedIndex = aux.idForm - 1;
                cmbP_Ingredient.SelectedIndex = aux.idIngredient - 1;

                isProductMod = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnP_Save control.
        /// 
        /// Save the product in the database and the product datagrid
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnP_Save_Click(object sender, RoutedEventArgs e)
        {
            Product aux = new Product();

            if (isProductMod)
                aux.idProduct = idProductMod;

            aux.price = Convert.ToDouble(txtP_Price.Text);
            aux.amount = Convert.ToInt32(txtP_Amount.Text);
            aux.idForm = cmbP_Form.SelectedIndex + 1;
            aux.idIngredient = cmbP_Ingredient.SelectedIndex + 1;

            if (!isProductMod)
                aux.Insert();
            else
                aux.Update();

            aux.ReadAll();
            dgrProducts.ItemsSource = aux.manage.list;
        }

        /// <summary>
        /// Handles the Click event of the btnP_New control.
        /// 
        /// Empty the form to be able to add a new product
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnP_New_Click(object sender, RoutedEventArgs e)
        {
            txtP_Price.Text = "";
            txtP_Amount.Text = "";
            cmbP_Form.SelectedItem = null;
            cmbP_Ingredient.SelectedItem = null;

            isProductMod = false;
        }

        /// <summary>
        /// Handles the Click event of the btnP_Del control.
        /// 
        /// Delete the selected product
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the TextChanged event of the txtP_Search control.
        /// 
        /// Search among all products
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void txtP_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Product aux = new Product();

            if (txtP_Search.Text.Length != 0)
            {
                String pattern = txtP_Search.Text;

                aux.manage.setSelectedList(pattern);
                dgrProducts.ItemsSource = aux.manage.selectedList;
            }
            else
            {
                aux.ReadAll();
                dgrProducts.ItemsSource = aux.manage.list;
            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the ProductRow control.
        /// 
        /// Load the product selected in the order form
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void ProductRow_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;

            Product aux = (Product)row.Item;

            NewOrder.Product = aux;

            this.Close();
        }

        //
        // SUPLIERS
        //

        /// <summary>
        /// Handles the TextChanged event of the txtS_Search control.
        /// 
        /// Search among all supliers
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void txtS_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Suplier aux = new Suplier();

            if (txtS_Search.Text.Length != 0)
            {
                String pattern = txtS_Search.Text;

                aux.manage.setSelectedList(pattern);
                dgrSupliers.ItemsSource = aux.manage.selectedList;
            }
            else
            {
                aux.ReadAll();
                dgrSupliers.ItemsSource = aux.manage.list;
            }
        }

        //
        // ORDERS
        //

        /// <summary>
        /// Handles the Click event of the btnO_New control.
        /// 
        /// Open the form to create orders
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnO_New_Click(object sender, RoutedEventArgs e)
        {
            NewOrder.User = setUser;
            NewOrder newOrder = new NewOrder(this);
            newOrder.Show();
        }

        /// <summary>
        /// Handles the Click event of the btnO_Del control.
        /// 
        /// Deletes the selected order
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnO_Del_Click(object sender, RoutedEventArgs e)
        {
            List<Order> data = new List<Order>();
            int indice = 0;
            if (dgrOrders.SelectedItems.Count > 0)
            {
                data = (List<Order>)dgrOrders.ItemsSource;

                for (int i = 0; i < dgrOrders.SelectedItems.Count; i++)
                {
                    indice = dgrOrders.Items.IndexOf(dgrOrders.SelectedItems[i]);
                    data.RemoveAt(indice);
                    Order row = (Order)dgrOrders.SelectedItems[i];
                    row.Delete();
                }
                dgrOrders.ItemsSource = null;
                dgrOrders.ItemsSource = data;
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtO_Search control.
        /// 
        /// Search among all the orders
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void txtO_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Order aux = new Order();

            if (txtO_Search.Text.Length != 0)
            {
                String pattern = txtO_Search.Text;

                aux.manage.setSelectedList(pattern);
                dgrOrders.ItemsSource = aux.manage.selectedList;
            }
            else
            {
                aux.ReadAll();
                dgrOrders.ItemsSource = aux.manage.list;
            }
        }

        /// <summary>
        /// Handles the ValueChanged event of the sldStatus control.
        /// 
        /// Select the status of the order
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{System.Double}"/> instance containing the event data.</param>
        private void sldStatus_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Order aux = (Order)dgrOrders.SelectedItem;            

            if(aux != null)
            {
                if (sldStatus.Value == 0)
                {
                    lblStatus.Text = "Status: Unconfirmed";
                    aux.status.confirmed = false;
                    aux.status.labeled = false;
                    aux.status.sent = false;
                    aux.status.invoiced = false;
                }

                if (sldStatus.Value == 10)
                {
                    lblStatus.Text = "Status: Confirmed";
                    aux.status.confirmed = true;
                    aux.status.labeled = false;
                    aux.status.sent = false;
                    aux.status.invoiced = false;
                }

                if (sldStatus.Value == 20)
                {
                    lblStatus.Text = "Status: Labeled";
                    aux.status.confirmed = true;
                    aux.status.labeled = true;
                    aux.status.sent = false;
                    aux.status.invoiced = false;
                }

                if (sldStatus.Value == 30)
                {
                    lblStatus.Text = "Status: Sent";
                    aux.status.confirmed = true;
                    aux.status.labeled = true;
                    aux.status.sent = true;
                    aux.status.invoiced = false;
                }

                if (sldStatus.Value == 40)
                {                 
                    aux.status.confirmed = true;
                    aux.status.labeled = true;
                    aux.status.sent = true;                   

                    if(aux.status.invoiced != true)
                    {
                        MessageBoxResult result = MessageBox.Show("Do you want to invoice this order?", "", MessageBoxButton.OKCancel);
                        switch (result)
                        {
                            case MessageBoxResult.OK:
                                lblStatus.Text = "Status: Invoiced";
                                aux.status.invoiced = true;

                                //INSERT THE INVOICE
                                Invoice invoice = new Invoice();
                                int maximun = aux.manage.getMaxInvoiceID();
                                Int64 invoiceID = Convert.ToInt64(DateTime.Today.ToString("yyyy") + maximun.ToString("0000"));
                                invoice.id = invoiceID;
                                invoice.date = DateTime.Today;
                                invoice.order = aux;

                                invoice.Insert();

                                invoice.ReadAll();
                                dgrInvoices.ItemsSource = invoice.manage.listI;

                                break;
                            case MessageBoxResult.Cancel:
                                sldStatus.Value = 30;
                                break;
                        }
                    }
                    else
                        lblStatus.Text = "Status: Invoiced";
                }

                dgrOrders.SelectedItem = aux;
                dgrOrders.Items.Refresh();

                aux.UpdateOrderStatus();
            }

        }

        /// <summary>
        /// Handles the SelectionChanged event of the dgrOrders control.
        /// 
        /// Show the status of the order in the slider
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void dgrOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Order aux = (Order)dgrOrders.SelectedItem;
            int value = 0;

            if(aux != null)
            {
                if (aux.status.confirmed)
                    value = 10;
                if (aux.status.labeled)
                    value = 20;
                if (aux.status.sent)
                    value = 30;
                if (aux.status.invoiced)
                    value = 40;

                sldStatus.Value = value;
            }
            
        }

        /// <summary>
        /// Handles the Click event of the btnO_Zoom control.
        /// 
        /// Show order details
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnO_Zoom_Click(object sender, RoutedEventArgs e)
        {
            Order aux = (Order)dgrOrders.SelectedItem;
            NewOrder.Order = aux;
            NewOrder newOrder = new NewOrder();
            newOrder.Show();
        }

        //
        // INVOICES
        //

        /// <summary>
        /// Handles the TextChanged event of the txtI_Search control.
        /// 
        /// Search among all the invoices
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void txtI_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Invoice aux = new Invoice();

            if (txtI_Search.Text.Length != 0)
            {
                String pattern = txtI_Search.Text;

                aux.manage.setInvoicesSelectedList(pattern);
                dgrInvoices.ItemsSource = aux.manage.selectedListI;
            }
            else
            {
                aux.ReadAll();
                dgrInvoices.ItemsSource = aux.manage.listI;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnI_Delete control.
        /// 
        /// Delete the invoice
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnI_Delete_Click(object sender, RoutedEventArgs e)
        {
            List<Invoice> data = new List<Invoice>();
            int indice = 0;
            if (dgrInvoices.SelectedItems.Count > 0)
            {
                data = (List<Invoice>)dgrInvoices.ItemsSource;

                for (int i = 0; i < dgrInvoices.SelectedItems.Count; i++)
                {
                    indice = dgrInvoices.Items.IndexOf(dgrInvoices.SelectedItems[i]);
                    data.RemoveAt(indice);
                    Invoice row = (Invoice)dgrInvoices.SelectedItems[i];
                    row.Delete();

                }
                dgrInvoices.ItemsSource = null;
                dgrInvoices.ItemsSource = data;

                Order aux = new Order();
                aux.ReadAll();
                dgrOrders.ItemsSource = aux.manage.list;
            }
            else
            {
                MessageBox.Show("You must select at least one row");
            }
        }

        /// <summary>
        /// Handles the MouseDoubleClick event of the dgrInvoices control.
        /// 
        /// Account the invoice
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void dgrInvoices_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (setUser.userPermissions.accountInvoices)
            {
                Invoice aux = (Invoice)dgrInvoices.SelectedItem;
                Invoice beforeAux = new Invoice();

                int indice = dgrInvoices.Items.IndexOf(aux);

                if ((dgrInvoices.Items.Count - 1) != indice)
                    beforeAux = (Invoice)dgrInvoices.Items.GetItemAt(indice + 1);

                if (beforeAux.accounted == true || (dgrInvoices.Items.Count - 1) == indice)
                {
                    aux.accounted = true;
                    aux.UpdateAccounted();

                    dgrInvoices.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Invoices must be accounted in order");
                }
            }

        }

        /// <summary>
        /// Handles the Click event of the btnI_Add control.
        /// 
        /// Open the form to create an invoice
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnI_Add_Click(object sender, RoutedEventArgs e)
        {
            Invoice aux = (Invoice)dgrInvoices.SelectedItem;
            NewOrder.NewInvoice = true;
            NewOrder.User = setUser;
            NewOrder newOrder = new NewOrder(this);
            newOrder.Show();
        }

        /// <summary>
        /// Handles the Click event of the btnI_Zoom control.
        /// 
        /// Show the invoice data
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnI_Zoom_Click(object sender, RoutedEventArgs e)
        {
            Invoice aux = (Invoice)dgrInvoices.SelectedItem;
            NewOrder.Order = aux.order;
            NewOrder newOrder = new NewOrder();
            newOrder.Show();
        }

        /// <summary>
        /// Handles the Click event of the btnI_Print control.
        /// 
        /// Create the invoice report to be able to print it
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnI_Print_Click(object sender, RoutedEventArgs e)
        {
            Invoice aux = (Invoice)dgrInvoices.SelectedItem;
            InvoiceView.Invoice = aux;
            InvoiceView invoiceView = new InvoiceView();
            invoiceView.Show();
        }

        
    }
}
