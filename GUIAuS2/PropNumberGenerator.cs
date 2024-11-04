using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIAuS2
{
    public static class PropNumberGenerator
    {
        private static Random rand = new Random();
        public static int GetPropertyNumber()
        {
            return rand.Next(100000);
        }
    }
}
