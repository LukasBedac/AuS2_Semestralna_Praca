namespace Semestralna_Praca1
{
    public class KDTree<T> where T : DataKey<T>
    {    
        public KDTree(int dimension) 
        {
            Root = null;
            Dimension = dimension;
        }

        public int Dimension { get; set; }
        public Node<T> Root { get; set; }

        public int Level(Node<T> node)
        {
            return 0;
        }
        public void RotateRight() 
        {
            
        }
        public void RotateLeft() 
        {
            
        }
        public bool Insert(Node<T> node) 
        {
            if (node == null)
            {
                return false;
            }
            if (node.Equals(Root))
            {
                return false;
            }



            return false;
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
