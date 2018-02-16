using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Fight : EntityObject
    {
        private House Hof1 { get; set; }
        private House Hof2 { get; set; }
        private House WinningHouse { get; set; }

       public Fight(House h1,House h2) : base()
        {
            Hof1 = h1;
            Hof2 = h2;
            WinningHouse = null;
        }
    }
}
