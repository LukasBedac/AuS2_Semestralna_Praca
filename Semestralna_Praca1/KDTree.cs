using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Timers;

namespace Semestralna_Praca1
{
    public class KDTree<Key, T> where Key : DataKey
    {    
        //TODO 1.0 Dimension
        public KDTree(Key key, T data) 
        {
            Root = new Node<Key, T>(key, data);
            Level = 0;
            CurrentNode = Root;
        }

        public int Level { get; set; }
        public Node<Key, T> Root { get; set; }
        public Node<Key, T> CurrentNode { get; set; }
        
        public bool Insert(T data, Key key)
        {
            
            CurrentNode = Root;
            Level = 0;
            if (data  == null || key == null)
            {
                return false;
            }
            Node<Key, T> node = new Node<Key, T>(key, data);
            
            while (CurrentNode != null) 
            {
                int comparison = CurrentNode.AppKey.Compare(node.AppKey, Level);                               
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
                    if (CurrentNode.AppKey.Compare(node.AppKey))
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
            Node<Key, T> node = new Node<Key, T>(key, data);            
                        
            List<Node<Key, T>> toRemove = FindNode(node);
            
            if (toRemove == null || toRemove.Count == 0)
            {
                return false;
            }
            if (toRemove.Count > 1)
            {
                //Work with duplicities
            }
            if (toRemove.Count == 1) //TODO 1.7 change to while (duplicates)
            {
                Node<Key, T> nodeToRemove = toRemove[0];
                while (true)
                {
                    if (nodeToRemove.Left == null && nodeToRemove.Right == null) 
                    {
                        //Console.WriteLine("Removing property: " + nodeToRemove.Data.ToString());
                        Node<Key, T> parent = nodeToRemove.Parent;
                        if (parent != null)
                        {
                            if (parent.Left != null && parent.Left.Equals(nodeToRemove))
                            {
                                parent.Left = null;
                            } else if (parent.Right != null && parent.Right.Equals(nodeToRemove)) 
                            {
                                parent.Right = null;
                            }
                        } else
                        {
                            Root = null;
                        }
                        nodeToRemove = null;
                        return true;
                    } 
                    //Find max in left subtree
                    if (nodeToRemove.Left != null)
                    {
                        Node<Key, T> returnedNode = FindMax(nodeToRemove.Left);
                        if (returnedNode == null)
                        {
                            throw new Exception("Returned node from FindMax was null");
                        } else
                        {
                            nodeToRemove = Swap(nodeToRemove, returnedNode);                            
                        }
                        
                    } else
                    {
                        //Find min in right subtree
                        Node<Key, T> returnedNode = FindMin(nodeToRemove.Right);
                        if (returnedNode == null)
                        {
                            throw new Exception("Returned node from FindMin was null");
                        }
                        else
                        {
                            nodeToRemove = Swap(nodeToRemove, returnedNode);
                        }
                    }
                }
            }
            return false;
        }

        private Node<Key, T> Swap(Node<Key, T> nodeToRemove, Node<Key, T> node)
        {
            if (node == null || nodeToRemove == null)
            {
                throw new Exception("While swapping nodes, one of them was null, please check possible null returns");
            }
            Node<Key, T> removedNodeData = new Node<Key, T>(nodeToRemove.AppKey, nodeToRemove.Data);
            T tempData = nodeToRemove.Data;
            Key tempKey = nodeToRemove.AppKey;

            nodeToRemove.Data = node.Data;
            nodeToRemove.AppKey = node.AppKey;

            node.Data = tempData;
            node.AppKey = tempKey;
            if (removedNodeData.Parent == null)
            {
                Root.Parent = null;
            }
            return node;
        }

        public T Find(T data, Key key)
        {
            if (data == null)
            {
                return data;
            }
            Node<Key, T> node = new Node<Key, T>(key, data);
            List<Node<Key, T>> nodes = FindNode(node);
            if (nodes.Count == 1)
            {
                return nodes[0].Data;
            } else
            {
                return default;
            }
           
        }
        private List<Node<Key, T>> InOrder(Node<Key, T> node)
        {
            if (node == null)
            {
                return new List<Node<Key, T>>();
            }
            Node<Key, T> current = node;
            List<Node<Key, T>> nodes = new List<Node<Key, T>>();
            while(current != null)
            {
                if (current.Left == null)
                {
                    nodes.Add(current);
                    current = current.Right;
                } else
                {
                    Node<Key, T> previous = current.Left;
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
        private Node<Key, T> FindMax(Node<Key, T> node)
        {
            Node<Key, T> current = node;
            Node<Key, T> max = current;
            int level = Level;
            if (node == null)
            {
                return null;
            }
            while (current != null)
            {
                if (current.Left == null && current.Right == null)
                {
                    return current;
                }
                if (current.Left != null && current.Right != null) 
                {
                    if (current.AppKey.Compare(current.Left.AppKey, level) == 1 && current.AppKey.Compare(current.Right.AppKey, level) == 1)
                    {
                        Level = level;
                        return max;
                    }
                }
                if (current.Left != null)
                {
                    int comparison = current.AppKey.Compare(current.Left.AppKey, level);
                    if (comparison == -1)
                    {
                        current = current.Left;
                        max = current;
                    } else if (comparison == 1)
                    {
                        if (current.Right != null)
                        {
                            if (current.AppKey.Compare(current.Right.AppKey, level) == 1)
                            {
                                max = current;
                                return max;
                            } else
                            {
                                current = current.Right;
                                max = current;
                            }
                        }
                        else
                        {
                            max = current;
                            return max;
                        }
                    }
                }
                if (current.Right != null)
                {
                    int comparison = current.AppKey.Compare(current.Right.AppKey, level);
                    if  (comparison == -1)
                    {
                        current = current.Right;
                        max = current;
                    } else if (comparison == 1)
                    {
                        if (current.Left != null)
                        {
                            if (current.AppKey.Compare(current.Left.AppKey, level) == 1)
                            {
                                max = current;
                                return max;                                
                            } else
                            {
                                current = current.Left;
                                max = current;
                            }
                        } else
                        {
                            max = current;
                            return max;
                        }
                    }
                }               
                level++;
            }           
            return max;
        }

        private Node<Key, T> FindMin(Node<Key, T> node)
        {
            Node<Key, T> current = node;
            Node<Key, T> min = current;
            int level = Level;
            if (node == null)
            {
                return null;
            }
            while (current != null)
            {
                if (current.Left == null && current.Right == null)
                {
                    return current;
                }
                if (current.Left != null && current.Right != null)
                {
                    if (current.AppKey.Compare(current.Left.AppKey, level) == -1 && current.AppKey.Compare(current.Right.AppKey, level) == -1)
                    {
                        Level = level;
                        return min;
                    }
                }
                if (current.Left != null)
                {
                    int comparison = current.AppKey.Compare(current.Left.AppKey, level);
                    if (comparison == 1)
                    {
                        current = current.Left;
                        min = current;
                    } else if (comparison == -1)
                    {
                        if (current.Right != null)
                        {
                            if (current.AppKey.Compare(current.Right.AppKey, level) == -1)
                            {
                                current = current.Right;
                                min = current;
                            } else
                            {
                                min = current;
                                return min;
                            }
                        } else
                        {
                            min = current;
                            return min;
                        }
                    }
                }
                
                if (current.Right != null)
                {
                    int comparison = current.AppKey.Compare(current.Right.AppKey, level);
                    if (comparison == 1)
                    {
                        current = current.Right;
                        min = current;
                    } else if (comparison == -1)
                    {
                        if (current.Left != null)
                        {
                            if (current.AppKey.Compare(current.Left.AppKey, level) == -1)
                            {
                                current = current.Left;
                                min = current;
                            } else
                            {
                                min= current;
                                return min;
                            }
                        } else
                        {
                            min = current;
                            return min;
                        }
                    }
                }               
                level++;
            }           
            return min;
        }
        private List<Node<Key, T>> FindNode(Node<Key, T> node)
        {
            if (node == null || Root == null)
            {
                return new List<Node<Key, T>>();
            }
            CurrentNode = Root;
            Level = 0;
            int comparison;
            int level = 0;
            while (CurrentNode != node)
            {
                if (CurrentNode == null)
                {
                    return new List<Node<Key, T>>();
                }
               
                comparison = CurrentNode.AppKey.Compare(node.AppKey, level);

                if (comparison == -1)
                {
                    CurrentNode = CurrentNode.Left;
                    level++;
                    continue;
                }
                else if (comparison == 1)
                {
                    CurrentNode = CurrentNode.Right;
                    level++;
                    continue;
                }
                else
                {
                    if (CurrentNode.Equals(node))
                    {
                        if (CurrentNode.Duplicates != null || CurrentNode.Duplicates.Count != 0)
                        {
                            //Return all duplicates of node and actual node                        
                            //List<Node<Key, T>> tempList = [CurrentNode, .. CurrentNode.Duplicates];
                            List<Node<Key, T>> tempList = new List<Node<Key, T>>() { CurrentNode };
                            return tempList;

                        }
                        return new List<Node<Key, T>>() { CurrentNode };
                    } else
                    {
                        return new List<Node< Key, T >> () { CurrentNode };
                    }
                   
                }
            }
            return new List<Node<Key, T>>() { CurrentNode };
        }
    }   
}
