using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca2
{
    public class Block<T> : IData where T : IRecord<T>, new()
    {
        private readonly int SIZE = 1000;
        public int Next { get; set; }
        public int Previous { get; set; }
        public IRecord<T>[] Records { get; set; }
        public int ValidCount { get; set; }
        public Block()
        {
            Next = -1;
            Previous = -1;
            IRecord<T> record = new T();
            int numberOfRecords = SIZE / record.GetSize();
            Records = new IRecord<T>[numberOfRecords];
            for (int i = 0; i < numberOfRecords; i++)
            {
                Records[i] = record.Create();
            }
            ValidCount = 0;
        }

        public bool InsertRecord(IRecord<T> record)
        {
            if (ValidCount < 5)
            {
                Records[ValidCount + 1] = record;
                ValidCount++;
                return true;
            }
            return false;
        }

        public bool RemoveRecord(T record)
        {
            for (int i = 0; i < Records.Length;i++)
            {
                if (Records[i].MyEquals(record))
                {
                    Records[i] = new T();
                    return true;
                }
            }
            return false;
        }

        public void FromByteToArray(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public int GetSize()
        {
            return 1000;
        }

        public byte[] ToByteArray()
        {
            throw new NotImplementedException();
        }
    }
}
