using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGoD.Models
{
    public class HouseDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int NumberOfUnities { get; set; }
        public int Gold { get; set; }

        public HouseDto(int id, String name, int numberOfUnits, int gold)
        {
            Id = id;
            Name = name;
            NumberOfUnities = numberOfUnits;
            Gold = gold;
        }
    }
}