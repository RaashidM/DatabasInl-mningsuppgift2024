using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasInlämningsuppgift2024
{
    public class TeamHasMatch
    {
        public bool IsHomeTeam { get; set; }
        public string Result { get; set; }
        public Team Team { get; set; }
        public Match Match { get; set; }


        public TeamHasMatch(bool isHomeTeam, string result, Team team, Match match)
        {
            IsHomeTeam = isHomeTeam;
            Result = result;
            Team = team;
            Match = match;
        }
    }
}
