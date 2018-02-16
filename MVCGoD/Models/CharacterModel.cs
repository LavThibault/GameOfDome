using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCGoD.Models
{
    public class CharacterModel
    {
        static Random r = new Random();
        private static List<String> prenoms = new List<string>() { "Gerard", "Marlène", "Michel", "Jacques", "Daniel", "Richard", "Marc-Emmanuel", "Thibault", "Lancelot", "Bertrand", "Bernard", "Balthazard", "Brigitte", "Gertrude", "Bertrude", "Barnabé", "Arnaud", "Arnold", "Gaspard", "Melchior" };
        private static List<String> noms = new List<string>() { "d'Adhémar", "d'Agoult", "d'Albon", "d'Ardennes", "de Rosne", "Bentivogolo", "de Brienne", "Pequenaud", "de Bouligne", "de Bourbon", "de Namur", "Cardaillac", "Byzantine", "de Ponthieu", "du Puiset", "Da Polenta", "de Rieux", "de Rohan", "de Gondor", "de Mordor", "du Puiset" };


        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Pv { get; set; }
        public int Bravoury { get; set; }
        public int Crazyness { get; set; }
        public string HouseId { get; set; }
        public HouseModel House { get; set; }
        public CharacterModel() : base()
        { }

        public CharacterModel(string firstName, string lastName, int pv, int bravoury, int crazyness, string houseId) : this(firstName, lastName, pv, bravoury, crazyness)
        {
            HouseId = houseId;
        }

        public CharacterModel(string firstName, string lastName, int pv, int bravoury, int crazyness) : this(firstName, lastName, pv)
        {
            Bravoury = bravoury;
            Crazyness = crazyness;
        }

        public CharacterModel(String fName, String lName, int Pv) : this()
        {
            FirstName = fName;
            LastName = lName;
            this.Pv = Pv;
            Bravoury = 0;
            Crazyness = 0;
        }

        public static CharacterModel HeroGenerator(int HouseId)
        {
            prenoms.ElementAt(r.Next()%prenoms.Count);
            return new CharacterModel(prenoms.ElementAt(r.Next() % prenoms.Count), noms.ElementAt(r.Next() % prenoms.Count), r.Next() % 50 + r.Next() % 50 + r.Next() % 50 + r.Next() % 50, r.Next() % 20 + r.Next() % 20, r.Next() % 30, ""+HouseId);
        }
    }
}