using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca1 
{
    public interface DataKey<T>
        {        
        public double X { get; set; }
        public double Y { get; set; }

        int Compare(T data, int level);
    }
}
