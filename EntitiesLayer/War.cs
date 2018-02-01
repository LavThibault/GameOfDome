using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class War : EntityObject
    {
        private String Nom { get; set; }
        private List<Fight> Liste { get; set; }

        public  War(String Nom) : base()
        {
            Liste = new List<Fight>();
            this.Nom = Nom;
        }
    }
}
