﻿using Csharp_Votos.Persistence.Manages;
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
        public int seat {  get; set; }

        
        //Constructor
        public Parties(string name, string acronym,string presidentName)
        {
            this.name = name;
            this.acronym = acronym;
            this.presidentName = presidentName;
            

        }

        public Parties(string name,int votesParty,int seat)
        {
            this.name = name;
            this.votesParty = votesParty;
            this.seat = seat;
        }



        



    }
}
