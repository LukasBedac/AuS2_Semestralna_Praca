using System.ComponentModel.Design;
using System.Timers;

namespace Semestralna_Praca1
{
    public class KDTree<DataKey, T>
    {    
        //TODO 1.0 Dimension
        public KDTree(T data, Key key) 
        {
            Root = new Node<T>(data, key);
            Level = 0;
            CurrentNode = Root;
        }

        public int Level { get; set; }
        public Node<T> Root { get; set; }
        public Node<T> CurrentNode { get; set; }
        
        public bool Insert(T data, Key key)
        {
            
            CurrentNode = Root;
            Level = 0;
            if (data  == null || key == null)
            {
                return false;
            }
            Node<T> node = new Node<T>(data, key);
            
            while (CurrentNode != null) 
            {
                int comparison = CurrentNode.Key.Compare(node.Key, Level);                               
                if (comparison == -1)
                {
                    if (CurrentNode.Left == null)
                    {
                        CurrentNode.Left = node;
                        node.Parent = CurrentNode;
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
                        node.Parent = CurrentNode;
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
        //TODO 1.5 Finish delete
        public bool Remove(T data, Key key)
        {
            if (data == null)
            {
                return false;
            }
            Node<T> node = new Node<T>(data, key);            
                        
            List<Node<T>> toRemove = FindNode(node);
            
            if (toRemove == null || toRemove.Count == 0)
            {
                return false;
            }
            if (toRemove.Count > 1)
            {
                //Work with duplicities
            }
            if (toRemove.Count == 1)
            {
                Node<T> nodeToRemove = toRemove[0];
                while (true)
                {
                    if (nodeToRemove.Left == null && node.Right == null) 
                    {
                        /*if (nodeToRemove.Parent == null)
                        {
                            Root = null;
                            return true;
                        }*/
                        nodeToRemove = null;
                        return true;
                    } 
                    //Find max in left subtree
                    //List<Node<T>> subTreeNodes = InOrder(nodeToRemove.Left);
                    if (nodeToRemove.Left != null)
                    {
                        Node<T> returnedNode = FindMax(nodeToRemove.Left);
                        if (returnedNode == null)
                        {
                            //error
                            break;
                        } else
                        {
                            Swap(nodeToRemove, returnedNode);
                        }
                        
                    } else
                    {
                        //Find min in right subtree
                        //List<Node<T>> subTreeNodes = InOrder(nodeToRemove.Right);
                        Node<T> returnedNode = FindMin(nodeToRemove.Right);
                        if (returnedNode == null)
                        {
                            //error
                            break;
                        }
                        else
                        {
                            Swap(nodeToRemove, returnedNode);
                        }
                    }
                }
            }
            return false;
        }

        private void Swap(Node<T> nodeToRemove, Node<T> node)
        {
            if (node == null || nodeToRemove == null)
            {
                throw new Exception("While swapping nodes, one of them turned to be null, please check possible null returns");
            }
            Node<T> removedNodeData = nodeToRemove;
            nodeToRemove.Data = node.Data;
            node.Data = removedNodeData.Data;
        }

        public T Find(T data, Key key)
        {
            if (data == null)
            {
                return data;
            }
            Node<T> node = new Node<T>(data, key);
            List<Node<T>> nodes = FindNode(node);
            if (nodes.Count == 1)
            {
                return nodes[0].Data;
            } else
            {
                return default;
            }
           
        }
        private List<Node<T>> InOrder(Node<T> node)
        {
            if (node == null)
            {
                return new List<Node<T>>();
            }
            Node<T> current = node;
            List<Node<T>> nodes = new List<Node<T>>();
            while(current != null)
            {
                if (current.Left == null)
                {
                    nodes.Add(current);
                    current = current.Right;
                } else
                {
                    Node<T> previous = current.Left;
                    while (previous.Right != null && previous.Right != current)
                    {
                        previous = previous.Right;
                    }
                    if (previous.Right == null)
                    {
                        previous.Right = current;
                        current = current.Left;
                    }
                    else
                    {
                        previous.Right = null;
                        nodes.Add(current);
                        current = current.Right;
                    }
                } 
                
            }            
            return nodes;
        }
        //TODO 1.6 Refactor FindMax and FindMin
        private Node<T> FindMax(Node<T> node)
        {
            Node<T> current = node;
            Node<T> max = current;
            int level = Level;
            if (node == null)
            {
                return null;
            }
             
            if (Level % 2 == 0)
            {
                while (current != null)
                {
                    if (current.Key.X > current.Left.Key.X && current.Key.X > current.Right.Key.X)
                    {
                        Level = level;
                        return max;
                    }
                    if (current.Key.X < current.Left.Key.X)
                    {
                        current = current.Left;
                        max = current;
                    }
                    if (current.Key.X < current.Right.Key.X)
                    {
                        current = current.Right;
                        max = current;                        
                    }
                    level++;
                }
            }
            else
            {
                while (current != null)
                {
                    if (current.Key.Y > current.Left.Key.Y && current.Key.Y > current.Right.Key.Y)
                    {
                        Level = level;
                        return max;
                    }
                    if (current.Key.X < current.Left.Key.Y)
                    {
                        current = current.Left;
                        max = current;
                    }
                    if (current.Key.Y < current.Right.Key.Y)
                    {
                        current = current.Right;
                        max = current;
                    }
                    level++;
                }
            }
            return null;
        }

        private Node<T> FindMin(Node<T> node)
        {
            Node<T> current = node;
            Node<T> min = current;
            int level = Level;
            if (node == null)
            {
                return null;
            }

            if (Level % 2 == 0)
            {
                while (current != null)
                {
                    if (current.Key.X < current.Left.Key.X && current.Key.X < current.Right.Key.X)
                    {
                        Level = level;
                        return min;
                    }
                    if (current.Key.X > current.Left.Key.X)
                    {
                        current = current.Left;
                        min = current;
                    }
                    if (current.Key.X > current.Right.Key.X)
                    {
                        current = current.Right;
                        min = current;
                    }
                    level++;
                }
            }
            else
            {
                while (current != null)
                {
                    if (current.Key.Y > current.Left.Key.Y && current.Key.Y > current.Right.Key.Y)
                    {
                        Level = level;
                        return min;
                    }
                    if (current.Key.X < current.Left.Key.Y)
                    {
                        current = current.Left;
                        min = current;
                    }
                    if (current.Key.Y < current.Right.Key.Y)
                    {
                        current = current.Right;
                        min = current;
                    }
                    level++;
                }
            }
            return null;
        }
        private List<Node<T>> FindNode(Node<T> node)
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
                }
                else if (comparison == 1)
                {
                    CurrentNode = CurrentNode.Right;
                    Level++;
                    continue;
                }
                else
                {
                    if (CurrentNode.Duplicates != null || CurrentNode.Duplicates.Count != 0)
                    {
                        //Return all duplicates of node and actual node                        
                        List<Node<T>> tempList = [CurrentNode, .. CurrentNode.Duplicates];
                        return tempList;

                    }
                    return new List<Node<T>>() { node };
                }
            }
            return new List<Node<T>>() { node };
        }
    }   
}
