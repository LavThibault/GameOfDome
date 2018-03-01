using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Territory
    {
        public TerritoryType TerritoryType { get; private set; }
        private House Owner { get; set; }
        public String Name { get; private set; }

        public Territory(String Name,House Owner,TerritoryType type) : base()
        {
            this.Name = Name;
            TerritoryType = type;
            this.Owner = Owner;
        }

        public Territory(String Name,TerritoryType type) : base()
        {
            this.Name = Name;
            TerritoryType = type;
            this.Owner = null;
        }

        public Territory(String Name,House Owner) : base()
        {
            this.Name = Name;
            TerritoryType = TerritoryType.LAND ;
            this.Owner = Owner;
        }

        public Territory(String Name) : base()
        {
            this.Name = Name;
            TerritoryType = TerritoryType.LAND ;
            this.Owner = null;
        }




    }
}
