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

namespace Csharp_Votos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int TOTALPOPULATION = 6921267;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += totalPopulation;
        }

        //Metodo para establecer el texto de la poblacion mundial
        private void totalPopulation(object sender, RoutedEventArgs e)
        {
            tbxPopulation.Text = TOTALPOPULATION.ToString();
        }

        
    }
}
