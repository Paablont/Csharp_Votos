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
        public void addParties(string acronym, string name,string presidentName)
        {
            try
            {
                if(acronym.Equals("") || name.Equals("") || presidentName.Equals(""))
                {
                    MessageBox.Show("Please fill all the fields");

                }
                else
                {
                    listParties.Add(new Parties(acronym, name, presidentName,0,0));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Something was wrong");
            }
            
        }

        public void deleteParties(Parties p)
        {
            listParties.Remove(p);
        }

    }
}
