using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
   
    public partial class MainWindow : Window
    {
        const int TOTALPOPULATION = 6921267;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += totalPopulationChange;
            //When change the tbxAbsent, change tbxNull
            tbxAbsent.TextChanged += nullVoteChange;
        }

        //When click on Button saves data
        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            //When  you press the button change to the second tab
            MessageBox.Show("Data save properly");
            tabControl.SelectedIndex = 1;

        }

        //Change the field in total Population 
        private void totalPopulationChange(object sender, RoutedEventArgs e)
        {
            tbxPopulation.Text = TOTALPOPULATION.ToString();
        }
        //Change the field in null votes
        private void nullVoteChange(object sender, RoutedEventArgs e)
        {
            tbxNull.Text = nullCalculate().ToString();
        }

        //Calculate the null votes
        private int nullCalculate()
        {
            int votes = voteCalculate();
            int nullvotes = votes / 20;

            return nullvotes;
        }

        //Calculate the valid votes
        private int voteCalculate()
        {
            int votes = 0;
            try
            {
                int absentionVotes = int.Parse(tbxAbsent.Text);
                if(absentionVotes <= 0 || absentionVotes >=TOTALPOPULATION)
                {
                    MessageBox.Show("The value of absention votes cant be less than 0 or greater than total population");
                }
                else
                {
                    votes = TOTALPOPULATION - absentionVotes;

                }
               
                
            }
            catch (FormatException f)
            {
                MessageBox.Show("Please, absetion votes must be a number");
            }
           
            return votes;

        }



    }
}
