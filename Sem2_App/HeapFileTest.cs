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
        private Heap<ServiceCustomer> heap;
        private List<ServiceCustomer> inserted = [];
        private List<int> addresses = [];
        public HeapFileTest()
        {
            heap = new Heap<ServiceCustomer>("../../../heapTest.bin");
            TestHeapFile();
        }
        public void TestMethods()
        {
            ServiceCustomer customer = new ServiceCustomer();
            customer.SureName = "Test";
            customer.ECV = "TN878GL";
            customer.ID = 1;
            customer.SetLengths();

            int address = heap.Insert(customer);
            inserted.Add(customer);
            ServiceCustomer customerGet = heap.Get(customer, address);
            Console.WriteLine(customerGet.ID + ", " + customerGet.ECV + ", " + customerGet.SureName);

            ServiceCustomer customer2 = new ServiceCustomer();
            customer2.SureName = "Test1";
            customer2.ECV = "TN343GL";
            customer2.ID = 1;
            customer2.SetLengths();

            address = heap.Insert(customer2); 
            inserted.Add(customer2);
            ServiceCustomer customerGet2 = heap.Get(customer2, address);
            Console.WriteLine(customerGet2.ID + ", " + customerGet2.ECV + ", " + customerGet2.SureName);

            ServiceCustomer customer3 = new ServiceCustomer();
            customer3.SureName = "Test2";
            customer3.ECV = "TN123GL";
            customer3.ID = 1;
            customer3.SetLengths();

            address = heap.Insert(customer3);
            inserted.Add(customer3);
            ServiceCustomer customerGet3 = heap.Get(customer3, address);
            Console.WriteLine(customerGet3.ID + ", " + customerGet3.ECV + ", " + customerGet3.SureName);

           /* ServiceCustomer customer4 = new ServiceCustomer();
            customer4.SureName = "Test3";
            customer4.ECV = "TN123GL";
            customer4.ID = 1;
            customer4.SetLengths();

            address = heap.Insert(customer4);
            address = heap.Insert(customer4);
            inserted.Add(customer4);
            ServiceCustomer customerGet4 = heap.Get(customer4, address);
            Console.WriteLine(customerGet4.ID + ", " + customerGet4.ECV + ", " + customerGet4.SureName);*/

            bool removed = heap.Delete(inserted[^1], address);

        }
        public void TestHeapFile()
        {
            GenerateFirstData();
            double methodSelect = randomMethod.NextDouble();
            if (methodSelect < 0.5)
            {
                ServiceCustomer customer = GenServiceCustomer.GetServiceCustomer();
                int address = heap.Insert(customer);

            } else
            {
                //heap.Delete();
            }
        }
        private void GenerateFirstData()
        {
            for (int i = 0; i < 1000; i++)
            {
                ServiceCustomer customer = GenServiceCustomer.GetServiceCustomer();
                int address = heap.Insert(customer);
                inserted.Add(customer);
                addresses.Add(address);
            }
            for (int i = 0; i < 1000; i++) //Somehow get address
            {
                ServiceCustomer customer = new();
                customer = heap.Get(inserted[i], i * 200);
                Console.WriteLine(i * 200 + ", " + inserted[i].ID + ", " + inserted[i].ECV + ", " + inserted[i].SureName);
                Console.WriteLine(i * 200 + ", " + customer.ID + ", " + customer.ECV + ", " + customer.SureName);
            }
        }
    }
}
