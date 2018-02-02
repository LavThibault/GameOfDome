using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCGoD.Models
{
    public class HouseModel
    {


        public int Id { get; set; }
        public List<CharacterModel> Housers { get; set; }
        public String Name { get; set; }
        public int NumberOfUnities { get; set; }
        public int Gold { get; set; }
        

        public HouseModel(String Name) : base()
        {
            this.Name = Name;
            NumberOfUnities = 0;
            Housers = new List<CharacterModel>();

        }


        public HouseModel(String Name, int Gold, int numberOfUnities) : this(Name)
        {
            this.Gold = Gold;
            this.NumberOfUnities = numberOfUnities;
        }

        public HouseModel()
        {
        }
    }
}