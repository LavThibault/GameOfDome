using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    class GeneralObservable
    {
        public String val1 { get; set; }
        public String val2 { get; set; }
        public String val3 { get; set; }
        public int id;

        public GeneralObservable(int id)
        {
            this.id = id;
        }

        public GeneralObservable(int id,String v1,String v2):this(id)
        {
            
            val1 = v1;
            val2 = v2;
        }

        public GeneralObservable(int id, String v1, String v2, String v3):this(id,v1,v2)
        {
            val3=v3;
        }
    }
}
