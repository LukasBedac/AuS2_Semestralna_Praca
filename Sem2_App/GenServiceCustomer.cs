using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2_App
{
    public class GenServiceCustomer
    {
        private GenServiceCustomer? Instance { get; set; }
        
        
        
        public GenServiceCustomer GetGenServiceCustomer() 
        {
            return Instance ??= new GenServiceCustomer();
        }
    }
}
