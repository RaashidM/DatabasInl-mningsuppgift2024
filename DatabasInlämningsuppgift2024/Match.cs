using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasInlämningsuppgift2024
{
    public class Match
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public int Attendance { get; set; }
        public Team Team { get; set; }
        public List<TeamHasMatch> Matches { get; set; } = new List<TeamHasMatch>();

        public Match(int id, DateTime matchDate, int attandance)
        {
            Id = id;
            MatchDate = matchDate;
            Attendance = attandance;
        }
    }
}
