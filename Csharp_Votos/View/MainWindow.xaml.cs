
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using Csharp_Votos.Domain;

namespace Csharp_Votos
{

    public partial class MainWindow : Window
    {
        public DatesVotes datesPre { get; set; }

        public MainWindow()
        {

            InitializeComponent();
            datesPre = new DatesVotes();
            this.DataContext = datesPre; //binding
            Loaded += totalPopulationChange;
            

            //When the tbxAbsent  changes, tbxNull refresh with update null vote count
            tbxAbsent.TextChanged += nullVoteChange;



        }

        //When click on Button saves data
        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {
            int votesValid, votesAbst, votesNull;
            string absentString = tbxAbsent.Text;
            string nullString = tbxAbsent.Text;

            votesValid = datesPre.voteCalculate(absentString);
            votesAbst  = int.Parse(tbxAbsent.Text);
            votesNull = datesPre.votesNullCalculate(nullString);

            datesPre.VotesValid = votesValid;
            datesPre.VotesAbst = votesAbst;
            datesPre.VotesNull = votesNull;
            if(datesPre.VotesAbst == 0) {
                MessageBox.Show("The absent votes can not be 0");
            }
            else
            {
                MessageBox.Show(datesPre.ToString());

                //When  you press the button change to the second tab
                MessageBox.Show("Data save properly");
                tabControl.SelectedIndex = 1;
            }
           
            
        }

        //Change the field in total Population 
        private void totalPopulationChange(object sender, RoutedEventArgs e)
        {
            tbxPopulation.Text = DatesVotes.TOTALPOPULATION.ToString();
        }
        //Change the field in null votes
        private void nullVoteChange(object sender, RoutedEventArgs e)
        {
            string absentString = tbxAbsent.Text;
            tbxNull.Text = datesPre.votesNullCalculate(absentString).ToString();
        }

        //***************************************************//
        //Datagrid functions
        private void dgvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
