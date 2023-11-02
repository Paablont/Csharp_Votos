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
        
        public String name {  get; set; }
        public String acronym { get; set; }
        public String presidentName {  get; set; }

        public int votesParty {  get; set; }

        //I use this aux variable to calculate the seats for each party
        public int votesPartyAux {  get; set; }
        public int seat {  get; set; }

        
        //Constructor
        public Parties(string acronym,string name,string presidentName, int votesParty, int seat, int votesPartyAux)
        {
            this.name = name;
            this.acronym = acronym;
            this.presidentName = presidentName;
            this.votesParty = votesParty;
            this.seat = seat;
            this.votesPartyAux = votesPartyAux;


        }   





        



    }
}
