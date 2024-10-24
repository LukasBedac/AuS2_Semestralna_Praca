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
                        return true;
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
                        return true;
                    }  else
                    {
                        CurrentNode = CurrentNode.Right;
                        Level++;
                        continue;
                    }                 
                } else
                {
                    if (CurrentNode.Key.Compare(node.Key))
                    {
                        CurrentNode.Duplicates.Add(node);
                        node.Duplicates.Add(CurrentNode);
                        return true;
                    }                    
                }
                Level++;
               
            }            
            return true;
            
        }
        public bool Remove(Node<T> node)
        {
            if (node == null)
            {
                return false;
            }
            
            List<Node<T>> toRemove = Find(node);
            
            if (toRemove == null || toRemove.Count == 0)
            {
                return false;
            }
            if (toRemove.Count > 1)
            {

            }
            if (toRemove.Count == 1)
            {
                Node<T> nodeToRemove = toRemove[0];
                if (nodeToRemove.Left == null && node.Right == null) 
                {
                    nodeToRemove.Parent = null;
                    return true;
                } else
                {
                    Node<T> parent = nodeToRemove.Parent;
                    if (parent.Left == nodeToRemove)
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                    nodeToRemove.Parent = null;
                    return true;
                }
            } else
            {

            }

            return false;
        }
        public List<Node<T>> Find(Node<T> node)
        {
            if (node == null || Root == null)
            {
                return new List<Node<T>>();
            }

            CurrentNode = Root;
            Level = 0;
            int comparison;
            
            while (CurrentNode != node)
            {
                if (CurrentNode == null)
                {
                    return new List<Node<T>>();
                }

                comparison = CurrentNode.Key.Compare(node.Key, Level);

                if (comparison == -1)
                {
                    CurrentNode = CurrentNode.Left;
                    Level++;
                    continue;
                } else if (comparison == 1)
                {
                    CurrentNode = CurrentNode.Right;
                    Level++;
                    continue;
                } else
                {
                    if (node.Duplicates != null)
                    {
                        //Return all duplicates of node and actual node                        
                        List<Node<T>> tempList = new List<Node<T>>();
                        tempList.Add(node);
                        foreach (Node<T> property in node.Duplicates)
                        {
                            tempList.Add(property);
                        }
                        return tempList;

                    }
                    return new List<Node<T>>() { node };
                }
            }
            return new List<Node<T>>() { node };
        }
    }
}
