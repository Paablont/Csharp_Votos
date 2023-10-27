using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Csharp_Votos.Domain
{
    public class DatesVotes
    {
        public const int TOTALPOPULATION = 6921267;

        public int Votes { get; set; }
        public int VotesAbst { get; set; }
        public int VotesNull { get; set; }

        public int VotesValid { get; set; }

        

        public DatesVotes(int votesValid, int votesAbst, int votesNull)
        {
            Votes = votesValid;
            VotesAbst = votesAbst;
            VotesNull = votesNull;
        }

        //Empty construct
        public DatesVotes()
        {
        }

        //Calculate the votes
        public int voteCalculate(String absentString)
        {
            int votes = 0;
            
                try
                {
                    int absentionVotes = int.Parse(absentString);
                    if (absentionVotes >= TOTALPOPULATION)
                    {
                        MessageBox.Show("The value of absention votes cant be less than 0 or greater than total population");
                    }
                    else
                    {
                        votes = TOTALPOPULATION - absentionVotes;

                    }
                }catch (FormatException e)
                {
                    MessageBox.Show("The value of absent votes can not be alphabetic character or void");
                }
                
            return votes;

        }
        //Calculate the null votes        
        public int votesNullCalculate(String nullString)
        {
            int votes = voteCalculate(nullString);
            int nullvotes = votes / 20;

            return nullvotes;
        }

        //Calculate the valid votes
        public int votesValidCalculate(int votes,int votesNull)
        {
            return votes - votesNull;
        }

        public override string? ToString()
        {
            return "Valid votes: " + Votes +
                "\n" + "Abstent votes: " + VotesAbst +
                "\n" + "Null votes: " + VotesNull;
        }
    }
}
