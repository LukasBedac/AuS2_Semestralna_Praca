using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca2
{
    public interface IRecord<T> : IData
    {
        public int ValidCount { get; set; }

        public bool MyEquals()
        {
            return false;
        }
    }
}
