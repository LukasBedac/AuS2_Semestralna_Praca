using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca2
{
    public interface IData
    {
        public void FromByteToArray(byte[] bytes);
        public byte[] ToByteArray();
        public int GetSize();
    }
}
