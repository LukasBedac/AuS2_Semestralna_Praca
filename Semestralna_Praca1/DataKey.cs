using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca1 
{
    public interface DataKey
    {
        public int Compare(DataKey data, int level);
    }
}
