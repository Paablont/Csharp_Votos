using Csharp_Votos.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void addParties(string acronym, string name,string presidentName)
        {
            listParties.Add(new Parties(acronym, name, presidentName));
        }
    }
}
