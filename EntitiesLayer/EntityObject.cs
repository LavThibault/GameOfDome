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
        public int Id { get; private set; }


        protected EntityObject()
        {
            Id = NumberOfObject;
            NumberOfObject++;
        }


    }
}
