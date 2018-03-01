using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGoD.Models
{
    public class FightDto
    {
        public int Hof1 { get; set; }
        public int Hof2 { get; set; }
        public int WinningHouse { get; set; }

        public FightDto(int h1, int h2) : base()
        {
            Hof1 = h1;
            Hof2 = h2;
            WinningHouse = -1;
        }
    }
}