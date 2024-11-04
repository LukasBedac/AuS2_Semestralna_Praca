using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semestralna_Praca1
{
    public class AppKey : DataKey
    {
        public double X { get; set; }
        public double Y { get; set; }

        public int Compare(DataKey data, int level)
        {
            if (data == null)
            {
                throw new Exception("Bad data send to comparer!");
            }
            if (data is AppKey)
            {
                AppKey key = (AppKey)data;
                if (level % 2 == 0)
                {
                    if (this.X < key.X)
                    {
                        return -1;
                    }
                    else if (this.X > key.X)
                    {
                        return 1;
                    } else
                    {
                        return 0;
                    }
                }
                //C integer
                else 
                {
                    if (this.Y < key.Y)
                    {
                        return -1;
                    }
                    else if (this.Y > key.Y)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }                
            }
            else
            {
                throw new Exception("Bad data send to comparer!");
            }
        }
        public bool Compare(DataKey data)
        {
            throw new NotImplementedException();
        }

        public bool Equals(DataKey data)
        {
            if (data == null)
            {
                throw new Exception("Bad data send to comparer!");
            }
            if (data is AppKey)
            {
                AppKey key = (AppKey)data;
                if (this.X == key.X)
                {
                    if (this.Y == key.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
