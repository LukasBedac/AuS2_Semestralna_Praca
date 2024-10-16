namespace Semestralna_Praca1
{
    public class Key : DataKey
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Compare(DataKey data, int level)
        {
            if (data == null)
            {
                throw new Exception("Bad data send to comparer!");
            }
            if (data is Key)
            {  
                Key key = (Key)data;
                if (level % 2 == 0)
                {

                    if (key.X < this.X)
                    {
                        return -1;
                    } else if (key.X > this.X)
                    {
                        return 1;
                    } else
                    {
                        return 0;
                    }

                } else
                {
                    if (key.Y < this.Y)
                    {
                        return -1;
                    }
                    else if (key.Y > this.Y)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }           
            } else
            {
                throw new Exception("Bad data send to comparer!");
            }                     
        }
    }
}
