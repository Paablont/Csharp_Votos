
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
using Csharp_Votos.Persistence.Manages;

namespace Csharp_Votos
{

    public partial class MainWindow : Window
    {
        public DatesVotes datesPre { get; set; }
        Parties party;
        List<Parties> partyList;
        PartiesManager pm { get; set; }
        int peopleThatVote, votesAbst, votesNull, seatsNumber, votesValid;
        string absentString, nullString, seatString;

        public MainWindow()
        {
            InitializeComponent();
            pm = new PartiesManager();
            datesPre = new DatesVotes();
            this.DataContext = datesPre; //binding
            dvgParties.ItemsSource = pm.getListParties();
            partyList = pm.getListParties();
            Loaded += totalPopulationChange;

            //When the tbxAbsent  changes, tbxNull refresh with update null vote count
            tbxAbsent.TextChanged += nullVoteChange;

            //Disable delete button from the 2nd tab
            btnDeleteParty.Visibility = Visibility.Hidden;

        }

        //*************** TAB CONTROL FUNCTIONS *************** // 

        //When press tab 1 or tab 2, clear the data from the datagrid on tab 3
        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if(tbControlMenu.SelectedIndex == 0 || tbControlMenu.SelectedIndex == 1)
            {
                dvgVotos.ItemsSource = null;
                dvgVotos.Items.Refresh();
                tabItem3.IsEnabled = false;
                foreach(Parties p in pm.getListParties())
                {
                    p.seat = 0;
                    p.votesPartyAux = 0;
                    p.votesParty = 0;
                }
            }
        }

        //*************** FIRST TAB FUNCTIONS *****************//

        //When click on Button saves data
        private void btnSaveData_Click(object sender, RoutedEventArgs e)
        {

            absentString = tbxAbsent.Text;
            nullString = tbxNull.Text;
            peopleThatVote = datesPre.calculatePeopleThatVote(absentString);
            votesAbst = int.Parse(tbxAbsent.Text);
            votesNull = datesPre.votesNullCalculate(absentString);
            votesValid = datesPre.votesValidCalculate(peopleThatVote, votesNull);
            datesPre.PeopleThatVote = peopleThatVote;
            datesPre.VotesAbst = votesAbst;
            datesPre.VotesNull = votesNull;

            if (datesPre.VotesAbst == 0)
            {
                MessageBox.Show("The absent votes can not be 0");
            }
            else
            {
                //When  you press the button change to the second tab
                MessageBox.Show("Data save properly");
                //MessageBox.Show(peopleThatVote.ToString());
                tbControlMenu.SelectedIndex = 1;
                tabItem2.IsEnabled = true;
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
            absentString = tbxAbsent.Text;
            tbxNull.Text = datesPre.votesNullCalculate(absentString).ToString();
        }

        //*************** SECOND TAB FUNCTIONS *****************//

        //Select one field in the Datagrid
        private void dgvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnDeleteParty.Visibility = Visibility.Visible;

            if (dvgParties.SelectedItem == null)
            {
                btnDeleteParty.Visibility = Visibility.Hidden;

            }

        }



        //Button that add a new party to the datagrid
        private void btnSaveParty_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dvgParties.Items.Count == 10)
                {
                    MessageBox.Show("10 parties have been added to the database. The simulation will begin now: ");
                    tbControlMenu.SelectedIndex = 2;
                    dvgVotos.Items.Refresh();
                    
                    tabItem3.IsEnabled = true;
                }
                else
                {
                    pm.addParties(tbxAcronym.Text, tbxPartyName.Text, tbxPresidentName.Text);

                    dvgParties.Items.Refresh();
                    
                    
                    tbxAcronym.Text = "";
                    tbxPartyName.Text = "";
                    tbxPresidentName.Text = "";
                    
                }

            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Something was wrong");
            }

        }

        //Button that delete a new party to the datagrid
        private void btnDeleteParty_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (Parties p in dvgParties.SelectedItems)
                {
                    pm.deleteParties(p);
                }

                dvgParties.Items.Refresh();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Something was wrong");
            }

        }

        //*************** THIRD TAB FUNCTIONS *****************

        //Start simulation button
        private void startSimulation(object sender, RoutedEventArgs e)
        {
             
            try
            {
                seatString = tbxSeats.Text;
                seatsNumber = int.Parse(seatString);
                partyList = pm.getListParties();

                if (seatsNumber <= 0)
                {
                    MessageBox.Show("The value of seats can not be less or equals to 0");


                }
                else
                {
                    dvgVotos.ItemsSource = pm.getListParties();
                    dvgVotos.Items.Refresh();
                    pm.calculateVotesParty(votesValid,partyList);
                    pm.calculateStands(partyList, seatsNumber);
                    
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("The value of seats can not be alphabetic character or 0");
            }
        }

       
        

        



    }
}
