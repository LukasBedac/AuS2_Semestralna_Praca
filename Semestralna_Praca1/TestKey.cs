namespace Semestralna_Praca1
{
    public class TestKey : DataKey
    {
        public double X { get; set; }
        public string B { get; set; } = " ";
        public int C { get; set; } = 0;
        public double Y { get; set; }
        public int Compare(DataKey data, int level)
        {
            if (data == null)
            {
                throw new Exception("Bad data send to comparer!");
            }
            if (data is TestKey)
            {
                TestKey key = (TestKey)data;
                //X = double, B = string
                if (level % 4 == 0)
                {
                    if (this.X < key.X)
                    {
                        return -1;
                    }
                    else if (this.X > key.X)
                    {
                        return 1;
                    }
                    else
                    {
                        int comparison = this.B.CompareTo(key.B);
                        if (comparison == -1)
                        {
                            return -1;
                        } else if (comparison == 1)
                        {
                            return 1;
                        } else
                        {
                            return 0;
                        }                        
                    }
                }
                //C integer
                else if ((level % 4) == 1)
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
                    // Y = double 
                } else if ((level % 4) == 2)
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
                        return 0;
                //B = string, C = integer
                } else
                {
                    int comparison = this.B.CompareTo(key.B);
                    if (comparison == -1)
                    {
                        return -1;
                    }
                    else if (comparison == 1)
                    {
                        return 1;
                    }
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
            if (data is TestKey)
            {
                TestKey key = (TestKey)data;
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

        public bool Equals(DataKey data)
        {
            if (data == null)
            {
                throw new Exception("Bad data send to comparer!");
            }
            if (data is TestKey)
            {
                TestKey key = (TestKey)data;
                if (this.X == key.X &&
                    this.B == key.B &&
                    this.C == key.C &&
                    this.Y == key.Y)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
