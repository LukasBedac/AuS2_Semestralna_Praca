using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Semestralna_Praca2
{
    public class Heap<T> : IDisposable where T : IRecord<T>, new()
    {
        private FileStream HeapFile { get; set; }
        public int BlockSize { get; set; }
        public string FileName { get; set; }
        public int PartialFreeBlock { get; set; }
        public int FreeBlock { get; set; }


        public Heap(string fileName) 
        {
            if (File.Exists(fileName))
            {
                //OpenHeapFile();
                //return;
            }
            HeapFile = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            Block<T> block = new();
            BlockSize = block.GetSize();
            FileName = fileName;
            PartialFreeBlock = -1;
            FreeBlock = -1;
        }
        public int Insert(T record)
        {
            if (FreeBlock != -1)
            {
                //return InsertIntoFreeBlock()

            }
            else if (PartialFreeBlock != -1)
            {
                //return InsertIntoPartiallyFreeBlock();
            }
            else
            {
                return InsertIntoNewBlock(record);
            }
            return -1;
        }

        public int InsertIntoNewBlock(T record)
        {
            int addressOfBlock = 0;
            Block<T> newBlock = new();
            newBlock.InsertRecord(record);
            HeapFile.Seek(0, SeekOrigin.End);
            addressOfBlock = (int) HeapFile.Position;
            HeapFile.Write(newBlock.ToByteArray(), 0, newBlock.GetSize());
            BlockManagement(newBlock);

            return addressOfBlock;
        }

        private void BlockManagement(Block<T> newBlock)
        {
            throw new NotImplementedException();
        }

        public void Delete(T record, int address)
        {

        }
        public T Get(T record, int address) 
        {
            return new();
        }
        public void Dispose()
        {
            HeapFile.Close();
        }
    }
}
