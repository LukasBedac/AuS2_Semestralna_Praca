using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca2
{
    public class ServiceCustomer : IRecord<ServiceCustomer>
    {
        private const string ERROR = "Maximum character length exceeded!";
        private const int SERVICEVISITLENGTH = 212;
        private const int ECVLENGTH = 10;
        private const int SURENAMELENGTH = 15;
        private const int LASTNAMELENGTH = 20;
        private const int SIZE = 4 + ECVLENGTH + SURENAMELENGTH + LASTNAMELENGTH;// + SERVICEVISITLENGTH * 5;
        public int ID { get; set; }
        [MaxLength(10, ErrorMessage = ERROR)]
        public string ECV { get; set; }
        [MaxLength(15, ErrorMessage = ERROR)]
        public string SureName { get; set; }
        [MaxLength(20, ErrorMessage = ERROR)]
        public string LastName { get; set; }
        [MaxLength(5, ErrorMessage = ERROR)]
        public ServiceVisit[] ServiceVisits { get; set; } = new ServiceVisit[5];
        public int ValidCount { get; set; }

        public ServiceCustomer(int id, string ecv, string surename, string lastname)//, ServiceVisit[] serviceVisits)
        {
            ID = id;
            ECV = ecv;
            SureName = surename;
            LastName = lastname;
            //ServiceVisits = serviceVisits;
            SetLengths();
            //SetValidCount();
        }

        public ServiceCustomer()
        {
            ID = -1;
            ECV = string.Empty;
            SureName = string.Empty;
            LastName = string.Empty;
            SetLengths();
        }

        public IRecord<ServiceCustomer> Create()
        {
            return new ServiceCustomer();
            
        }

        public void FromByteToArray(byte[] bytes)
        {
            byte[] bID = new byte[4];
            byte[] bECV = new byte[ECVLENGTH];
            byte[] bSureName = new byte[SURENAMELENGTH];
            byte[] bLastname = new byte[LASTNAMELENGTH];
            Buffer.BlockCopy(bytes, 0, bID, 0, 4);
            Buffer.BlockCopy(bytes, 4, bECV, 0, ECVLENGTH);
            Buffer.BlockCopy(bytes, 4 + ECVLENGTH, bSureName, 0, SURENAMELENGTH);
            Buffer.BlockCopy(bytes, 4 + ECVLENGTH + SURENAMELENGTH, bLastname ,0, LASTNAMELENGTH);
            ID = BitConverter.ToInt32(bID);
            ECV = Encoding.UTF8.GetString(bECV);
            SureName = Encoding.UTF8.GetString(bSureName);
            LastName = Encoding.UTF8.GetString(bLastname);
        }

        public byte[] ToByteArray()
        {
            byte[] bID = BitConverter.GetBytes(ID) ?? new byte[4];
            byte[] bECV = Encoding.UTF8.GetBytes(ECV) ?? new byte[10];
            byte[] bSureName = Encoding.UTF8.GetBytes(SureName) ?? new byte[15];
            byte[] bLastname = Encoding.UTF8.GetBytes(LastName) ?? new byte[20];
            //byte[] bServiceVisits = GetServiceVisitsBytes() ?? new byte[SERVICEVISITLENGTH * 5];
            int length = bID.Length + bECV.Length + bSureName.Length + bLastname.Length;// + bServiceVisits.Length; //TODO 
            byte[] bytes = new byte[SIZE];
            Buffer.BlockCopy(bID, 0, bytes, 0, bID.Length);
            Buffer.BlockCopy(bECV, 0, bytes, bID.Length, bECV.Length);
            Buffer.BlockCopy(bSureName, 0, bytes, bID.Length + bECV.Length, bSureName.Length);
            Buffer.BlockCopy(bLastname, 0, bytes, bID.Length + bECV.Length + bSureName.Length, bLastname.Length);
            //Buffer.BlockCopy(bServiceVisits, 0, bytes, bID.Length + bECV.Length + bSureName.Length + bLastname.Length, bServiceVisits.Length);
            return bytes;
        }

        public byte[] GetServiceVisitsBytes()
        {            
            int offset = 0;
            byte[] serviceVisists = new byte[SERVICEVISITLENGTH * 5];
            for (int i = 0; i < ServiceVisits.Length; i++)
            {
                byte[] tmp = ServiceVisits[i].ConvertWorkDescArray();
                Buffer.BlockCopy(tmp, 0, serviceVisists, offset, SERVICEVISITLENGTH);
                offset += SERVICEVISITLENGTH;
            }
            return serviceVisists;
        }

        public void SetValidCount()
        {
            for (int i = 0; i < ServiceVisits.Length; i++)
            {
                if (ServiceVisits[i] != null)
                {
                    ValidCount++;
                } else
                {
                    ServiceVisits[i] = new ServiceVisit();
                }
            }
        }

        public void SetLengths()
        {
            if (ECV.Length < 10)
            {
                ECV.PadRight(10, '\0');
            }
            if (SureName.Length < 15)
            {
                SureName.PadRight(15, '\0');
            }
            if (LastName.Length < 20)
            {
                LastName.PadRight(20, '\0');
            }
        }

        public int GetSize()
        {
            return SIZE;
        }

        public bool MyEquals(ServiceCustomer data)
        {
            if (this.ECV.Equals(data.ECV) && this.ID == data.ID)
            {
                return true;
            }
            return false;
        }

        public bool MyEquals(int customerId)
        {
            if (this.ID == customerId)
            {
                return true;
            }
            return false;
        }

        public bool MyEquals(string ecv)
        {
            if (this.ECV.Equals(ecv))
            {
                return true;
            }
            return false;
        }

        
    }
}
