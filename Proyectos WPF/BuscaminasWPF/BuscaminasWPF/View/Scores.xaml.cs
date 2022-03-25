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

namespace BuscaminasWPF.View
{
    /// <summary>
    /// Lógica de interacción para Scores.xaml
    /// </summary>
    public partial class Scores : Window
    {
        private int score;
        public Scores()
        {
            InitializeComponent();

        }

        public Scores(int score)
        {
            InitializeComponent();
            this.score = score;

            btnSave.IsEnabled = true;

            lblScore.Text = "Score: " + score.ToString();

            Player aux = new Player();
            aux.ReadAll();
            dgrPlayers.ItemsSource = aux.manage.list;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Player aux = new Player();
            aux.name = txtName.Text;
            aux.score = this.score;
            aux.Insert();

            btnSave.IsEnabled = false;

            aux.ReadAll();
            dgrPlayers.ItemsSource = aux.manage.list;
        }

    }
}
