using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace BridgeCrew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Queue<Officer> officers;

        public MainWindow()
        {
            InitializeComponent();

            int starDate = Useful.randomStarDate();
            lblStarDate = 
            
            officers = Useful.initOfficerQueue();

            CambiaOficial();

            //OFFICERS WORKER
            pbOfficers.Value = 0;
            BackgroundWorker workerOfficer = new BackgroundWorker();
            workerOfficer.WorkerReportsProgress = true;
            workerOfficer.DoWork += worker_DoWork;
            workerOfficer.ProgressChanged += worker_ProgressChanged;
            workerOfficer.RunWorkerCompleted += worker_RunWorkerCompleted;
            workerOfficer.RunWorkerAsync(60);

         

        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int result = 0;

            while (true)
            {
                int max = (int)e.Argument;
                for (int i = 0; i < max; i++)
                {
                    int progressPercentage = Convert.ToInt32(((double)i / max) * 100);
                    (sender as BackgroundWorker).ReportProgress(progressPercentage);
                    System.Threading.Thread.Sleep(100);

                }

            }

        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbOfficers.Value = e.ProgressPercentage;
            
            if (pbOfficers.Value > 97)
            {
                CambiaOficial();
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            CambiaOficial();
        
        }

        private void btnEvery1min_Click(object sender, RoutedEventArgs e)
        {
            CambiaOficial();
        }
        void CambiaOficial()
        {
            Officer officer = officers.Dequeue();
            officers.Enqueue(officer);

            lblName.Content =        " Name: " + officer.Name;
            lblOfficialKey.Content = " Official Key: " + officer.OfficialKey.ToString();
            lblPlanet.Content =      " Planet: " + officer.Planet.ToString();
            lblGraduation.Content =  " Graduation: " + officer.Graduation.ToString();
            imgOfficer.Source = (new BitmapImage(new Uri(officer.ImgSource, UriKind.Relative)));
            pbOfficers.Value = 0;
        }

        private void btnMessages_Click(object sender, RoutedEventArgs e)
        {
            MessagesWindow messagesWindow = new MessagesWindow();
            messagesWindow.Show();
        }
    }
}
