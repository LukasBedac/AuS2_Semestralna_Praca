using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca2
{
    public class Block<T> : IData where T : IRecord<T>, new()
    {
        private readonly int SIZE = 200;
        public readonly int NUMBEROFRECORDS;
        public int Next { get; set; }
        public int Previous { get; set; }
        public IRecord<T>[] Records { get; set; }
        public int ValidCount { get; set; }
        public Block()
        {
            Next = -1;
            Previous = -1;
            IRecord<T> record = new T();
            NUMBEROFRECORDS = (SIZE - 4 - 4 - 4) / record.GetSize();
            Records = new IRecord<T>[NUMBEROFRECORDS];
            for (int i = 0; i < NUMBEROFRECORDS; i++)
            {
                Records[i] = new T();
            }
            ValidCount = 0;
        }

        public bool InsertRecord(IRecord<T> record)
        {            
            if (ValidCount < 5)
            {
                Records[ValidCount] = record;
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
                    ValidCount--;
                    return true;
                }
            }
            return false;
        }

        public IRecord<T> Get(T record)
        {
            for (int i = 0; i < Records.Length;i++)
            {
                if (Records[i].MyEquals(record))
                {
                    return Records[i];
                }
            }
            return new T();
        }

        public void FromByteToArray(byte[] bytes)
        {
            IRecord<T> record = new T();
            int offset = 0;
            byte[] bNext = new byte[4];
            byte[] bPrevious = new byte[4];
            byte[] bValidCount = new byte[4];
            byte[] bRecords = new byte[record.GetSize() * Records.Length];
            Buffer.BlockCopy(bytes, 0, bNext, 0, bNext.Length);
            offset += bNext.Length;
            Buffer.BlockCopy(bytes, offset, bPrevious, 0, bPrevious.Length);
            offset += bPrevious.Length;
            Buffer.BlockCopy(bytes, offset, bValidCount, 0, bValidCount.Length);
            offset += bValidCount.Length;
            Buffer.BlockCopy(bytes, offset, bRecords, 0, bRecords.Length);
            Next = BitConverter.ToInt32(bNext);
            Previous = BitConverter.ToInt32(bPrevious);
            ValidCount = BitConverter.ToInt32(bValidCount);
            int recordOffset = 0;
            for (int i = 0; i < Records.Length; i++)
            {
                IRecord<T> tmp = new T();
                byte[] bTmp = new byte[tmp.GetSize()];
                Buffer.BlockCopy(bRecords, recordOffset, bTmp, 0, tmp.GetSize());
                tmp.FromByteToArray(bTmp);
                Records[i] = tmp;
                recordOffset += tmp.GetSize();
            }
        }

        public int GetSize()
        {
            return SIZE;
        }

        public byte[] ToByteArray()
        {
            int offset = 0;
            IRecord<T> record = new T();

            byte[] blockBytes = new byte[SIZE];
            byte[] bNext = BitConverter.GetBytes(Next);
            byte[] bPrevious = BitConverter.GetBytes(Previous);
            byte[] bValidCount = BitConverter.GetBytes(ValidCount);
            byte[] bRecords = new byte[record.GetSize() * Records.Length];

            int recordOffset = 0;
            foreach (var r in Records)
            {
                byte[] tmp = r.ToByteArray();
                Buffer.BlockCopy(tmp, 0, bRecords, recordOffset, r.GetSize());
                recordOffset += r.GetSize();
            }

            Buffer.BlockCopy(bNext, 0, blockBytes, 0, bNext.Length);
            offset += 4;
            Buffer.BlockCopy(bPrevious, 0, blockBytes, offset, bPrevious.Length);
            offset += 4;
            Buffer.BlockCopy(bValidCount, 0, blockBytes, offset, bValidCount.Length);
            offset += 4;
            Buffer.BlockCopy(bRecords, 0, blockBytes, offset, bRecords.Length);
            return blockBytes;
        }
    }
}
