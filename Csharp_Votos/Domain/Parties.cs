using Csharp_Votos.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Votos.Domain
{
   
    internal class Parties
    {
        public String Name {  get; set; }
        public String Acronym { get; set; }
        public String PresidentName {  get; set; }

        public PartiesManager pm { get; set; }

        //Constructor
        public Parties(string name, string acronym,string presidentName)
        {
            this.Name = name;
            this.Acronym = acronym;
            this.PresidentName = presidentName;
           
        }
        


    }
}
