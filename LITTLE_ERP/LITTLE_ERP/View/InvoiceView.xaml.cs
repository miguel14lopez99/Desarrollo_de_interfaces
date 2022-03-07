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
    /// Lógica de interacción para InvoiceView.xaml
    /// </summary>
    public partial class InvoiceView : Window
    {
        private static Invoice invoice;
        internal static Invoice Invoice { get => invoice; set => invoice = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceView"/> class.
        /// </summary>
        public InvoiceView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Loaded event of the Grid control.
        /// 
        /// Load all the invoice data to the report
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Invoice.MakeInvoiceDataTable();
            Invoice.MakeOrdersDataTable();

            //Load the values ​​in the report
            InvoiceReport mireporte = new InvoiceReport();

            mireporte.Database.Tables["Invoices"].SetDataSource(Invoice.manage.tInvoices);
            mireporte.Database.Tables["Orders"].SetDataSource(Invoice.manage.tOrders);
            CR1.ViewerCore.ReportSource = mireporte;
        }
    }
}
