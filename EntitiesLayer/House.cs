using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class House : EntityObject
    {
        private List<Character> Housers { get; set; }
        public String Name { get; private set; }
        public int NumberOfUnities { get; private set; }
        private int Gold { get; set; }

        public void AddHouser(Character c)
        {
            Housers.Add(c);
        }

        public House(String Name) : base()
        {
            this.Name = Name;
            NumberOfUnities = 0;
            Housers = new List<Character>();
            
        }


        public House(String Name,int Gold, int numberOfUnities) : this(Name)
        {
            this.Gold = Gold;
            this.NumberOfUnities = numberOfUnities;
        }
    
         public void AddUnities(int unit)
        {
            NumberOfUnities += unit;
        }

    }
}
