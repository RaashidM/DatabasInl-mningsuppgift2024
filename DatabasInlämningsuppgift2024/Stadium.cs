using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabasInlämningsuppgift2024
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string City { get; set; }

        public Stadium(int id, string name, int capacity, string city)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
            City = city;
        }

    }
}
