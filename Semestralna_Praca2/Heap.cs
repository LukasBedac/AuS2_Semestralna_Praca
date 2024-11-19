using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca2
{
    public class Heap<T>
    {
        public int ClusterSize { get; set; }
        public string FileName { get; set; }
        public Heap(int clusterSize, string fileName) 
        {
            ClusterSize = clusterSize;
            FileName = fileName;
        }
        public int Insert(T record)
        {
            return -1;
        }
        public void Delete(T record, int address)
        {

        }
        public T Get(T record, int address) 
        {
            return default;
        }
    }
}
