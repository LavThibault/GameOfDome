using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCGoD.Models
{
    public class HouseModel
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int NumberOfUnities { get; set; }
        public int Gold { get; set; }
        public List<CharacterModel> Housers { get; set; }


        public HouseModel(String name, int numberOfUnities, int gold) : this(name)
        {
            Gold = gold;
            NumberOfUnities = numberOfUnities;
            Housers = new List<CharacterModel>();
        }



        public HouseModel(String Name) : base()
        {
            this.Name = Name;
            NumberOfUnities = 0;
            Housers = new List<CharacterModel>();

        }


        public HouseModel()
        {
            Housers = new List<CharacterModel>();
        }
    }
}