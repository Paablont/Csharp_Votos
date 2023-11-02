using Csharp_Votos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;


namespace Csharp_Votos.Persistence.Manages
{

    internal class PartiesManager
    {
        public List<Parties> listParties { get; set; }

        public PartiesManager()
        {
            listParties = new List<Parties>();
        }

        public List<Parties> getListParties()
        {
            return listParties;
        }

        public void setListParties(List<Parties> newList)
        {
            listParties = newList;
        }
        public void addParties(string acronym, string name, string presidentName)
        {
            try
            {
                if (acronym.Equals("") || name.Equals("") || presidentName.Equals(""))
                {
                    MessageBox.Show("Please fill all the fields");

                }
                else
                {
                    listParties.Add(new Parties(acronym, name, presidentName, 0, 0,0));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something was wrong");
            }

        }

        public void deleteParties(Parties p)
        {
            listParties.Remove(p);
        }


        //Calculate the votes each party has
        public void calculateVotesParty(int votesValid, List<Parties> partyList)
        {
            double[] percentages = { 35.25, 24.75, 15.75, 14.25, 3.75, 3.25, 1.5, 0.5, 0.25, 0.25 };

            for (int i = 0; i < partyList.Count; i++)
            {
                partyList[i].votesParty = (int)Math.Round(votesValid * (percentages[i] / 100));
                partyList[i].votesPartyAux = (int)Math.Round(votesValid * (percentages[i] / 100));
                   
            }


        }

        //Calculate stands to each party (pasar a clase PartiesManager¿?)
        public void calculateStands(List<Parties> partyList, int seatsNumber)
        {
            
            int posMaxValue, maxVotes;
            
            for (int i = 0; i < seatsNumber; i++)
            {
                maxVotes = partyList.Max(x => x.votesPartyAux);
                posMaxValue = partyList.FindIndex(p => p.votesPartyAux == maxVotes);
                partyList[posMaxValue].seat += 1;
                partyList[posMaxValue].votesPartyAux  = partyList[posMaxValue].votesParty/ (partyList[posMaxValue].seat + 1);

            }
            
        }

        

    }
}
