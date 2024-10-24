namespace Semestralna_Praca1
{
    public class Key : DataKey
    {
        public double X { get; set; }
        public string B { get; set; }
        public int C { get; set; }
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
                //X = double, B = string
                if (level % 2 == 0)
                {
                    if (key.X < this.X)
                    {
                        return -1;
                    }
                    else if (key.X > this.X)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                //C integer
                else if ((level % 2) == 1)
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
                    // Y = double 
                } else if ((level % 2) == 2)
                {
                    return 0;
                //B = string, C = integer
                } else
                {
                    return 0;
                }
            }
            else
            {
                throw new Exception("Bad data send to comparer!");
            }
        }
        public bool Compare(DataKey data)
        {
            if (data == null)
            {
                throw new Exception("Bad data send to comparer!");
            }
            if (data is Key)
            {
                Key key = (Key)data;
                if (key.X == this.X)
                {
                    if (key.Y == this.Y)
                    {
                        return true;

                    }
                }

            }
            return false;
        }
    }
}
