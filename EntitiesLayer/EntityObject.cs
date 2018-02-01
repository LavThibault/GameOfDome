using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public abstract class EntityObject
    {
        private static int NumberOfObject { get; set; }
        private int Id { get; set; }


        protected EntityObject()
        {
            Id = NumberOfObject;
            NumberOfObject++;
        }


    }
}
