using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca2
{
    public class Block<T> : IData where T : IRecord<T>
    {
        public int Next { get; set; }
        public int Previous { get; set; }
        public IRecord<T>[] Records { get; set; } = new IRecord<T>[4];
        public void FromByteToArray(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public int GetSize()
        {
            throw new NotImplementedException();
        }

        public byte[] ToByteArray()
        {
            throw new NotImplementedException();
        }
    }
}
