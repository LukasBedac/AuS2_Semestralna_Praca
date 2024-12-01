using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca2
{
    public interface IRecord<T> : IData
    {
        public bool MyEquals(T data);
        public bool MyEquals(int customerId);
        public bool MyEquals(string ecv);
    }
}
