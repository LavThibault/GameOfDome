using System;
using System.Collections.Generic;

namespace EntitiesLayer
{

    public class Character : EntityObject
    {
        public int Bravoury { get; set; }
        public int Crazyness { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public CharacterType Classe { get;set; }
        public int Pv { get; set; }
        public Dictionary<String, Relationship> Relationships { get; set; }

        public void AddRelatives(String caracName,Relationship value)
        {
            Relationships.Add(caracName, value);
        }

        public Character() : base()
        {
            
        }

        public Character(String fName, String lName, int Pv) : this()
        {
            FirstName=fName;
            LastName = lName;
            this.Pv = Pv;
            Bravoury = 0;
            Crazyness = 0;
            Relationships = new Dictionary<string, Relationship>();
        }

        public Character(String fName,String lName,int Pv ,int Bravoury,int Crazyness) : this(fName,lName,Pv)
        {
            this.Bravoury = Bravoury;
            this.Crazyness = Crazyness;
            Relationships = new Dictionary<string, Relationship>();

        }

        public override String ToString()
        {
            return "Je suis "+FirstName+" "+LastName;
        }
    }



}
