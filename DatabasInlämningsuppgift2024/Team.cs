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

        public Team(int id, string name, int foundedYear, string coach)
        {
            Id = id;
            Name = name;
            FoundedYear = foundedYear;
            Coach = coach;
        }
    }
}
