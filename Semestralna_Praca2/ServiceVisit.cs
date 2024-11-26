using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca2
{
    public class ServiceVisit : IData
    {
        private const int DESCRIPTIONLENGTH = 10;
        private const int STRINGLENGTH = 20;
        private const int SIZE = 4 + 8 + (DESCRIPTIONLENGTH * STRINGLENGTH); //date(unixTime) + price(double) + (workDescr[10] * 20) (212 bytes)
        public DateTime Date { get; set; }
        public double Price { get; set; }
        [MaxLength(DESCRIPTIONLENGTH, ErrorMessage = "Maximum work description lines exceeded!")]
        public string[] WorkDescription { get; set; } = new string[DESCRIPTIONLENGTH];
        public int[] ValidCount { get; set; } = new int[DESCRIPTIONLENGTH];

        // This converts DateTime to int - seconds or miliseconds which takes less space (4 bytes)
        // new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        // This note is here for me to fo not forget this code to use

        public ServiceVisit(DateTime date, double price, string[] description)
        {
            Date = date;
            Price = price;
            WorkDescription = description;
            SetValidCount();
        }
        public ServiceVisit() 
        {
            
        }
        public void FromByteToArray(byte[] bytes)
        {
            byte[] bDate = new byte[4];
            Buffer.BlockCopy(bytes, 0, bDate, 0, 4);
            Date = DateTimeOffset.FromUnixTimeSeconds(BitConverter.ToInt32(bDate)).AddMinutes(60).UtcDateTime;
            byte[] bPrice = new byte[8];
            Buffer.BlockCopy(bytes, 4, bPrice, 0, 8);
            Price = BitConverter.ToDouble(bPrice);
            byte[] bDescription = new byte[DESCRIPTIONLENGTH * STRINGLENGTH];
            Buffer.BlockCopy(bytes, 12, bDescription, 0, bDescription.Length);
            GetWorkDescFromByte(bytes, 12);
        }

        public byte[] ToByteArray()
        {
            byte[] bytes = new byte[SIZE];
            byte[] bDate = BitConverter.GetBytes(new DateTimeOffset(Date).ToUnixTimeSeconds()).Take(4).ToArray() ?? new byte[4];
            byte[] bPrice = BitConverter.GetBytes(Price) ?? new byte[8];
            byte[] bDescription = ConvertWorkDescArray() ?? new byte[DESCRIPTIONLENGTH * STRINGLENGTH];
            Buffer.BlockCopy(bDate, 0, bytes, 0, bDate.Length);
            Buffer.BlockCopy(bPrice, 0, bytes, bDate.Length, bPrice.Length);
            Buffer.BlockCopy(bDescription, 0, bytes,bDate.Length + bPrice.Length, bDescription.Length);
            return bytes;
        }

        public byte[] ConvertWorkDescArray()
        {
            byte[] descBytes = new byte[WorkDescription.Length * STRINGLENGTH];
            int offset = 0;
            for (int i = 0;i < WorkDescription.Length;i++)
            {
                byte[] tmp = Encoding.UTF8.GetBytes(WorkDescription[i]);
                Buffer.BlockCopy(tmp, 0, descBytes, offset, STRINGLENGTH);
                offset += STRINGLENGTH;
            }
            return descBytes;
        }
        
        private void GetWorkDescFromByte(byte[] bytes, int offset)
        {
            int stringOffset = offset;
            string[] tempData = new string[10];
            for (int i = 0; i < DESCRIPTIONLENGTH;i++)
            {
                byte[] tmp = new byte[STRINGLENGTH];
                Buffer.BlockCopy(bytes, offset, tmp, 0, STRINGLENGTH);
                offset += STRINGLENGTH;
                tempData[i] += Encoding.UTF8.GetString(tmp);
            }
            WorkDescription = tempData;
        }

        private void SetValidCount()
        {            
            for (int i = 0; i < WorkDescription.Length; i++)
            {
                if (WorkDescription[i] == null)
                {
                    WorkDescription[i] = WorkDescription[i].PadRight(20, '\0');
                    ValidCount[i] = 0;
                    continue;
                }
                ValidCount[i] = WorkDescription[i].Length;
                WorkDescription[i] = WorkDescription[i].PadRight(20, '\0');
            }
        }
        public int GetSize()
        {
            return SIZE;
        }
    }
}
