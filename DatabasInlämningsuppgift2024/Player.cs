using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasInlämningsuppgift2024
{
    public class Player
    {
       

        public int Id {  get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }


        public Player(int id, string name, int age, string nationality, string position)
        {
            Id = id;
            Name = name;
            Age = age;
            Nationality = nationality;
            Position = position;
        }


    }
}
