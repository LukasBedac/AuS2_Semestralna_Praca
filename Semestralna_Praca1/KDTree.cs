namespace Semestralna_Praca1
{
    public class KDTree<Key, T> 
    {    
        public KDTree(Node<T> node) 
        {
            Root = node;
            Level = 0;
            CurrentNode = Root;
        }

        public int Level { get; set; }
        public Node<T> Root { get; set; }
        public Node<T> CurrentNode { get; set; }

        public void RotateRight() 
        {
            
        }
        public void RotateLeft() 
        {
            
        }
        public bool Insert(Node<T> node) 
        {
            CurrentNode = Root;
            Level = 0;
            if (node == null)
            {
                return false;
            }
            if (node.Equals(Root))
            {
                return false;
            }
            while (CurrentNode != null) 
            {
                int comparison = CurrentNode.Key.Compare(node.Key, Level);                               
                if (comparison == -1)
                {
                    if (CurrentNode.Left == null)
                    {
                        CurrentNode.Left = node;                   
                    } else
                    {
                        CurrentNode = CurrentNode.Left;
                        Level++;
                        continue;
                    }

                } else if (comparison == 1)
                {
                    if (CurrentNode.Right == null)
                    {
                        CurrentNode.Right = node;
                    }  else
                    {
                        CurrentNode = CurrentNode.Right;
                        Level++;
                        continue;
                    }                 
                } else
                {
                    return false;
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
