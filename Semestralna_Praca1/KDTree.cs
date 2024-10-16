namespace Semestralna_Praca1
{
    public class KDTree<T> where T : DataKey<T>
    {    
        public KDTree(Node<T> node) 
        {
            Root = node;
            Level = 0;
            LastInserted = Root;
        }

        public int Level { get; set; }
        public Node<T> Root { get; set; }
        public Node<T> LastInserted { get; set; }

        public void RotateRight() 
        {
            
        }
        public void RotateLeft() 
        {
            
        }
        public bool Insert(Node<T> node) 
        {
            LastInserted = Root;
            Level = 0;
            int insertedPoints = 0;
            if (node == null)
            {
                return false;
            }
            if (node.Equals(Root))
            {
                return false;
            }
            while (insertedPoints < 2) 
            {
                int comparison = LastInserted.Data.Compare(node.Data, Level);                                
                if (comparison == -1)
                {
                    if (LastInserted.Left == null)
                    {
                        node.Parent = LastInserted;
                        LastInserted.Left = node;                        
                        insertedPoints++;
                    } else
                    {
                        LastInserted = LastInserted.Left;
                        continue;
                    }

                } else if (comparison == 1)
                {
                    if (LastInserted.Right == null)
                    {
                        node.Parent = LastInserted;
                        LastInserted.Right = node;
                        insertedPoints++;
                    }  else
                    {
                        LastInserted = LastInserted.Right;
                        continue;
                    }                 
                } else
                {
                    return false;
                }                
                if (insertedPoints == 1)
                {
                    LastInserted = Root;
                }
                Level++;
               
            }
            return true;
            
        }
        public bool Remove(Node<T> node)
        {
            return false;
        }
        public bool Find(Node<T> node)
        {
            return false;
        }

    }
}
