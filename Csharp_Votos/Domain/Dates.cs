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

        public int PeopleThatVote { get; set; }
        public int VotesAbst { get; set; }
        public int VotesNull { get; set; }

        public int VotesValid { get; set; }

        

        public DatesVotes(int votesValid, int votesAbst, int votesNull)
        {
            PeopleThatVote = votesValid;
            VotesAbst = votesAbst;
            VotesNull = votesNull;
        }

        //Empty construct
        public DatesVotes()
        {
        }

        //Calculate the peopleThatVote
        public int calculatePeopleThatVote(String absentString)
        {
            int people = 0;
            
                try
                {
                    int absentionVotes = int.Parse(absentString);
                    if (absentionVotes >= TOTALPOPULATION)
                    {
                        MessageBox.Show("The absetion votes values can not be higher than total population");
                    }
                    else
                    {
                        people = TOTALPOPULATION - absentionVotes;

                    }
                }catch (FormatException e)
                {
                    MessageBox.Show("The value of absent votes can not be alphabetic character");
                }
                
            return people;

        }
        //Calculate the null votes        
        public int votesNullCalculate(String absentString)
        {
            int people = calculatePeopleThatVote(absentString);
            int nullvotes =(people / 20);

            return nullvotes;
        }

        //Calculate the valid votes
        public int votesValidCalculate(int peopleThatVote,int votesNull)
        {
            return peopleThatVote - votesNull;
        }

        public override string? ToString()
        {
            return "Valid votes: " + PeopleThatVote +
                "\n" + "Abstent votes: " + VotesAbst +
                "\n" + "Null votes: " + VotesNull;
        }
    }
}
