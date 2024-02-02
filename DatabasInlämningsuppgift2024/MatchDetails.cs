using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasInlämningsuppgift2024
{
    public class MatchDetails
    {
        public int MatchId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string Stadium { get; set; }
        public string Result { get; set; }
        public int Attendance { get; set; }

      
        public MatchDetails()
        {
        }

        public MatchDetails(int matchId, string homeTeam, string awayTeam, string stadium, string result, int attendance)
        {
            MatchId = matchId;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            Stadium = stadium;
            Result = result;
            Attendance = attendance;
        }
    }

}
