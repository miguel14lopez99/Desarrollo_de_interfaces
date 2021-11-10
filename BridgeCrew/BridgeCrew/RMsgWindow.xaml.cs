using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BridgeCrew
{
    /// <summary>
    /// Lógica de interacción para RMsgWindow.xaml
    /// </summary>
    public partial class RMsgWindow : Window
    {
        public RMsgWindow()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text = String.Empty;
            String msg = Message.ReadMsg();
            String[] msgsplit = msg.Split('#');
            for (int i = 0; i < msgsplit.Length; i++) {
                txtContent.Text = txtContent.Text + msgsplit[i]+"\n";
            }
            txtContent.Text = txtContent.Text + "------ END OF FILE -----";

            /*txtContent.Text = Message.ReadMsg();*/
        }

        private void btnClearFile_Click(object sender, RoutedEventArgs e)
        {
            txtContent.Text = String.Empty;
            Message.ClearFile();

        }
    }
}
