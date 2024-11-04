using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIAuS2
{
    public static class UniqueIDGenerator
    {
        private static int ID = 0;
        public static int GetUniqueID()
        {
                return ++ID;
        }
    }
}
