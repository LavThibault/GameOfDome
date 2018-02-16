using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCGoD.Models
{
    public class CharacterModel
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Pv { get; set; }
        public int Bravoury { get; set; }
        public int Crazyness { get; set; }

        public CharacterModel()
        {
        }

        public CharacterModel(String fName, String lName, int Pv) : this()
        {
            FirstName = fName;
            LastName = lName;
            this.Pv = Pv;
            Bravoury = 0;
            Crazyness = 0;
        }

        public CharacterModel(String fName, String lName, int Pv, int Bravoury, int Crazyness) : this(fName, lName, Pv)
        {
            this.Bravoury = Bravoury;
            this.Crazyness = Crazyness;
        }
    }
}