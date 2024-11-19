using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca2
{
    public class ServiceCustomer : IRecord<ServiceCustomer>
    {
        private const string ERROR = "Maximum character length exceeded!";
        public int ID { get; set; }
        [MaxLength(15, ErrorMessage = ERROR)]
        public string SureName { get; set; }
        [MaxLength(20, ErrorMessage = ERROR)]
        public string LastName { get; set; }
        [MaxLength(5, ErrorMessage = ERROR)]
        public ServiceVisit[] ServiceVisits { get; set; } = new ServiceVisit[5];
        public int ValidCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ServiceCustomer(int id, string surename, string lastname, ServiceVisit[] serviceVisits) 
        {
            ServiceVisits = serviceVisits;
            SureName = surename;
            LastName = lastname;
            ID = id;
        }

        public void FromByteToArray(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public byte[] ToByteArray()
        {
            throw new NotImplementedException();
        }

        public int GetSize()
        {
            throw new NotImplementedException();
        }
    }
}
