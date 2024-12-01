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
        public int PartialFreeBlock { get; set; }
        public int FreeBlock { get; set; }
        private int NumberOfRecordsInBlock { get; set; }

        public Heap(string fileName) 
        {
            if (File.Exists(fileName))
            {
                //OpenHeapFile();
                //return;
            }
            //Extract to method CreateHeapFile(filename);
            HeapFile = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            Block<T> block = new();
            HeapFile.Seek(0, SeekOrigin.End);
            FreeBlock = (int)HeapFile.Position;
            BlockSize = block.GetSize();
            HeapFile.Write(block.ToByteArray(), 0, BlockSize);
            PartialFreeBlock = -1;
            NumberOfRecordsInBlock = block.NUMBEROFRECORDS;
        }

        

        public int Insert(T record)
        {
            if (FreeBlock != -1)
            {
                return InsertIntoFreeBlock(record);

            }
            else if (PartialFreeBlock != -1)
            {
                return InsertIntoPartiallyFreeBlock(record);
                
            }
            if (record != null)
            {
                return InsertIntoNewBlock(record);
            }
            return -1;
        }

        public int InsertIntoNewBlock(T record)
        {
            int addressOfBlock = 0;
            Block<T> newBlock = new();
            if (!newBlock.InsertRecord(record))
            {
                return -1;
            }
            
            HeapFile.Seek(0, SeekOrigin.End);
            addressOfBlock = (int) HeapFile.Position;
            HeapFile.Write(newBlock.ToByteArray(), 0, BlockSize);            
            if (FreeBlock != -1)
            {

            }
            return addressOfBlock;
        }
        public int InsertIntoPartiallyFreeBlock(T record)
        {
            int addressOfBlock = PartialFreeBlock;
            byte[] readBytes = new byte[BlockSize];
            Block<T> block = new();
            HeapFile.Seek(addressOfBlock, SeekOrigin.Begin);
            HeapFile.Read(readBytes, 0, BlockSize);
            block.FromByteToArray(readBytes);
            if (!block.InsertRecord(record))
            {
                return -1;
            }
            if (block.ValidCount == NumberOfRecordsInBlock)
            {
                PartialFreeBlock = -1;
                Block<T> newBlock = new();
                HeapFile.Seek(0, SeekOrigin.Begin);
                HeapFile.Write(newBlock.ToByteArray(), 0, BlockSize);
                FreeBlock = 0;
                block.Previous = -1;
                block.Next = -1;
                addressOfBlock = (int)HeapFile.Position;
            }
            HeapFile.Seek(addressOfBlock, SeekOrigin.Begin);
            HeapFile.Write(block.ToByteArray(), 0, BlockSize);
            
            return addressOfBlock;
        }

        public int InsertIntoFreeBlock(T record)
        {
            Block<T> block = new();
            int addressOfBlock = FreeBlock;
            byte[] readBytes = new byte[BlockSize];
            HeapFile.Seek(addressOfBlock, SeekOrigin.Begin);
            if (HeapFile.Read(readBytes, 0, BlockSize) != block.GetSize())
            {
                return -1;
            }
            block.FromByteToArray(readBytes);
            if (!block.InsertRecord(record))
            {
                return -1;
            }
            FreeBlock = -1;
            PartialFreeBlock = addressOfBlock;
            HeapFile.Seek(addressOfBlock, SeekOrigin.Begin);
            HeapFile.Write(block.ToByteArray(), 0, BlockSize);
            return addressOfBlock;
        }

        private void BlockManagement(Block<T> block,int address)
        {
            Block<T> previous = new();
            byte[] bBlock = new byte[BlockSize];
            int previousAddress = (int) HeapFile.Seek(address - BlockSize, SeekOrigin.End);      
            HeapFile.Read(bBlock, address - BlockSize, BlockSize);
            previous.FromByteToArray(bBlock);
            previous.Next = address;
            block.Previous = previousAddress;
        }

        public bool Delete(T record, int address)
        {
            byte[] bBlock = new byte[BlockSize];
            HeapFile.Seek(address, SeekOrigin.Begin);
            HeapFile.Read(bBlock, 0, BlockSize);
            Block<T> block = new();
            block.FromByteToArray(bBlock);
            if (!block.RemoveRecord(record))
            {
                return false;
            }
            if (block.Next != -1 || block.Previous != -1 || block.ValidCount < block.NUMBEROFRECORDS)
            {
                if (PartialFreeBlock != -1)
                {
                    LinkNewPartialFreeBlock(block, address);
                } else
                {
                    PartialFreeBlock = address;
                }
            }
            if (block.ValidCount == 0)
            {
                if (FreeBlock != -1)
                {
                    LinkFreeBlock(block, address);   
                } else
                {
                    FreeBlock = address;
                }
            }
            return true;
            
        }
        public T Get(T record, int address) 
        {
            byte[] bBlock = new byte[BlockSize];
            HeapFile.Seek(address, SeekOrigin.Begin);
            HeapFile.Read(bBlock, 0, BlockSize);
            Block<T> block = new();
            block.FromByteToArray(bBlock);
            return (T) block.Get(record);
        }
        private void LinkNewPartialFreeBlock(Block<T> block, int blockAddress)
        {            
            block.Next = PartialFreeBlock;
            block.Previous = -1;

            if (PartialFreeBlock != -1)
            {
                byte[] partialFirstBlock = new byte[BlockSize];
                HeapFile.Seek(PartialFreeBlock, SeekOrigin.Begin);
                HeapFile.Read(partialFirstBlock, 0, BlockSize);

                Block<T> partialBlock = new();
                partialBlock.FromByteToArray(partialFirstBlock);
                partialBlock.Previous = blockAddress;

                HeapFile.Seek(PartialFreeBlock, SeekOrigin.Begin);
                HeapFile.Write(partialBlock.ToByteArray(), 0, BlockSize);
            }
            PartialFreeBlock = blockAddress;
            HeapFile.Seek(blockAddress, SeekOrigin.Begin);
            HeapFile.Write(block.ToByteArray(), 0, BlockSize);
        }

        private void LinkFreeBlock(Block<T> block, int blockAddress)
        {
            block.Next = FreeBlock;
            block.Previous = -1;
            if (FreeBlock != -1)
            {
                byte[] firstFreeBlock = new byte[BlockSize];
                HeapFile.Seek(FreeBlock, SeekOrigin.Begin);
                HeapFile.Read(firstFreeBlock, 0, BlockSize);

                Block<T> firstBlock = new();
                firstBlock.FromByteToArray(firstFreeBlock);
                firstBlock.Previous = blockAddress;

                HeapFile.Seek(FreeBlock, SeekOrigin.Begin);
                HeapFile.Write(firstBlock.ToByteArray(), 0, BlockSize);
            }
            FreeBlock = blockAddress;
            HeapFile.Seek(blockAddress, SeekOrigin.Begin);
            HeapFile.Write(block.ToByteArray(), 0, BlockSize);
        }

        public void Dispose()
        {
            HeapFile.Close();
        }
    }
}
