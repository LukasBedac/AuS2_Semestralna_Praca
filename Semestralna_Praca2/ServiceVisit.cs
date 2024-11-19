using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca2
{
    public class ServiceVisit : IRecord<ServiceVisit>
    {
        private int _validCount;
        public DateTime Date { get; set; }
        public double Price { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum character length exceeded!")]
        public string Description { get; set; }
        public int ValidCount { get => _validCount; set { _validCount = Description.Length; } }
        
        // This converts DateTime to int - seconds or miliseconds which takes less space (4 bytes)
        // new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        // This note is here for me to fo not forget this code to use

        public ServiceVisit(DateTime date, double price, string description) 
        {
            Date = date;
            Price = price;
            Description = description;            
        }

        public void FromByteToArray(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public byte[] ToByteArray()
        {
            byte[] bDate = BitConverter.GetBytes(new DateTimeOffset(Date).ToUnixTimeSeconds());
            byte[] bPrice = BitConverter.GetBytes(Price);
            byte[] bDescription = Encoding.UTF8.GetBytes(Description);
            int length = bDate.Length + bPrice.Length + bDescription.Length;
            byte[] bytes = new byte[length];
            for (int i = 0; i < length; i++)
            {
                if (i < bDate.Length)
                {
                    bytes[i] = bDate[i];
                }
                else if (i < bDate.Length + bPrice.Length)
                {
                    bytes[i] = bPrice[i];
                } else
                {
                    bytes[i] = bDescription[i];
                }
            }
            return bytes;
        }

        public int GetSize()
        {
            throw new NotImplementedException();
        }
    }
}
