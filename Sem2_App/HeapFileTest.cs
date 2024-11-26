using Semestralna_Praca2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2_App
{
    public class HeapFileTest
    {
        private Random randomMethod = new Random();
        public HeapFileTest() 
        {
            Heap<ServiceCustomer> heap = new Heap<ServiceCustomer>("heapTest.bin");
        }
        public void TestMethods()
        {

        }
    }
}
