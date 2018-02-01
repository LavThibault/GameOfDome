using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    class DalManager
    {
        private static DalManager _instance;
        private static readonly object padlock = new object();

        public static DalManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DalManager();
                        }
                    }
                }
                return _instance;
            }
        }

        private DalManager()
        {

        }
    }
}
