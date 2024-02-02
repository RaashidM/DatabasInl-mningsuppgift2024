using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasInlämningsuppgift2024
{
    public class Team
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public int FoundedYear { get; set; }
        public string Coach {  get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
        public List<TeamHasMatch> Matches { get; set; } = new List<TeamHasMatch>();

        public Team(int id, string name, int foundedYear, string coach)
        {
            Id = id;
            Name = name;
            FoundedYear = foundedYear;
            Coach = coach;
        }

        public string GetInfo()
        {
            return "Team Id: " + Id + ", Team Name: " + Name + ", Founded Year: " + FoundedYear + ", Coach: " + Coach;
        }
       
    }
}
