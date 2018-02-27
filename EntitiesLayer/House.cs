using System;
using System.Collections.Generic;

namespace EntitiesLayer
{
    public class House : EntityObject
    {
        public List<Character> Housers { get; set; }
        public String Name { get; set; }
        public int NumberOfUnities { get; set; }
        public int Gold { get; set; }

        public void AddHouser(Character c)
        {
            Housers.Add(c);
        }

        public House(int id, String name) : base(id)
        {
            Name = name;
            NumberOfUnities = 0;
            Housers = new List<Character>();
        }


        public House(int id, String name, int numberOfUnities, int gold) : this(id, name)
        {
            Gold = gold;
            NumberOfUnities = numberOfUnities;
        }
    
         public void AddUnities(int unit)
        {
            NumberOfUnities += unit;
        }

    }
}
