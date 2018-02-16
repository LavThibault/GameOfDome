using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGoD.Models
{
    public class HouseDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int NumberOfUnits { get; set; }
        public int Gold { get; set; }

        public HouseDTO(int id, String name, int numberOfUnits, int gold)
        {
            Id = id;
            Name = name;
            NumberOfUnits = numberOfUnits;
            Gold = gold;
        }
    }
}