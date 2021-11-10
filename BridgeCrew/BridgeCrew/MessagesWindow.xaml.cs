using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BridgeCrew
{
    /// <summary>
    /// Lógica de interacción para MessagesWindow.xaml
    /// </summary>
    public partial class MessagesWindow : Window
    {
        public MessagesWindow()
        {
            
            InitializeComponent();
            pbMsgsBackup.Value = 0;
            BackgroundWorker msgWorker = new BackgroundWorker();
            msgWorker.WorkerReportsProgress = true;
            msgWorker.DoWork +=msgWork;
            msgWorker.ProgressChanged += msgWorkChange;
            msgWorker.RunWorkerCompleted += saveToFile;
            msgWorker.RunWorkerAsync(20);
            
        }

        void msgWork(object sender, DoWorkEventArgs e) {

            int result = 0;

            while (true)
            {
                int max = (int)e.Argument;
                for (int i = 0; i < max; i++)
                {
                    int progressPercentage = Convert.ToInt32(((double)i / max) * 100);
                    (sender as BackgroundWorker).ReportProgress(progressPercentage);
                    System.Threading.Thread.Sleep(1000);

                }
            }

        }
        void msgWorkChange(object sender, ProgressChangedEventArgs e) {
            pbMsgsBackup.Value = e.ProgressPercentage;
            if (pbMsgsBackup.Value == 95) {
                Message.saveMsgs();
            }
        }

        void saveToFile(object sender, RunWorkerCompletedEventArgs e)
        {
            Message.saveMsgs();
            
        }
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (checkMsgIntegrity())
            {
                Message msg = new Message(cboFrom.Text, cboTo.Text, txtMsgContent.Text);
                Message.add(msg);
                txtStatus.Text = "Message sended Successfully";
                DispatcherTimer Timer = new DispatcherTimer();
                Timer.Tick += new EventHandler(resetTXTStatus);
                Timer.Interval = new TimeSpan(0, 0, 2);
                Timer.Start();

            }

        }

        private Boolean checkMsgIntegrity()
        {
            Boolean correct = true;
            if (String.IsNullOrEmpty(cboFrom.Text))
            {
                MessageBox.Show("Please, select a Sender");
                correct = false;
            }
            else if (String.IsNullOrEmpty(cboTo.Text))
            {
                MessageBox.Show("Please, select a recipient");
                correct = false;
            }
            else if (String.IsNullOrEmpty(txtMsgContent.Text))
            {
                MessageBox.Show("The content of the message can´t be empty");
                correct = false;

            }
            else if (String.Equals(cboFrom.Text, cboTo.Text))
            {
                MessageBox.Show("Sender and Reicipient can´t be the same");
                correct = false;
            }
            return correct;
        }

        private void cboFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cboFrom.SelectedIndex) {
                case 0:
                    imgFrom.Source = (new BitmapImage(new Uri("/imgPlanets/Arrakis.png", UriKind.Relative)));
                    break;
                case 1:
                    imgFrom.Source = (new BitmapImage(new Uri("/imgPlanets/Bela.png", UriKind.Relative)));
                    break;
                case 2:
                    imgFrom.Source = (new BitmapImage(new Uri("/imgPlanets/Caladan.png", UriKind.Relative)));
                    break;
                default:
                    imgFrom.Source = (new BitmapImage(new Uri("/imgPlanets/missing.png", UriKind.Relative)));
                    break;
            }
        }

        private void cboTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cboTo.SelectedIndex)
            {
                
                case 0:
                    imgTo.Source = (new BitmapImage(new Uri("/imgPlanets/Arrakis.png", UriKind.Relative)));
                    break;
                case 1:
                    imgTo.Source = (new BitmapImage(new Uri("/imgPlanets/Bela.png", UriKind.Relative)));
                    break;
                case 2:
                    imgTo.Source = (new BitmapImage(new Uri("/imgPlanets/Caladan.png", UriKind.Relative)));
                    break;
            }

        }

        private void txtMsgContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void resetTXTStatus(object sender, EventArgs e)
        {
            txtStatus.Text = "";
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            RMsgWindow RmessagesWindow = new RMsgWindow();
            RmessagesWindow.Show();
        }
    }
}
