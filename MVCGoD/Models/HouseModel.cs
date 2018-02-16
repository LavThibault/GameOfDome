using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCGoD.Models
{
    public class HouseModel
    {
        public int Id { get; set; }
        public String Name { get; private set; }
        public int NumberOfUnities { get; private set; }
        public int Gold { get; set; }

        public HouseModel()
        {
        }

        public HouseModel(String name):this()
        {
            Name = name;
            NumberOfUnities = 0;
        }


        public HouseModel(String name, int numberOfUnities, int gold) : this(name)
        {
            Gold = gold;
            NumberOfUnities = numberOfUnities;
        }

    }
}