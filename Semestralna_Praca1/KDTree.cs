using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Timers;

namespace Semestralna_Praca1
{
    /*This class is for creating and managing K-D tree
     * @param key - key of the root
     * @param data - data of object of the root
     * @param dimension - dimension of key secondary keys
     */

    public class KDTree<Key, T> where Key : DataKey
    {    
        public KDTree(Key key, T data, int dimension) 
        {
            Root = new Node<Key, T>(key, data);
            Level = 0;
            CurrentNode = Root;
            Dimension = dimension;
        }

        public int Level { get; set; }
        public Node<Key, T> Root { get; set; }
        public Node<Key, T> CurrentNode { get; set; }
        public int Dimension { get; set; }
        
        /*Insert method for KD-tree
         * @param data - data of object which will be inserted
         * @param key - key of object which will be inserted
         */
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
                int comparison = node.AppKey.Compare(CurrentNode.AppKey, Level);                               
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
                    if (CurrentNode.Data.Equals(node.Data))
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
        /*Remove method of K-D tree
         * @param data - data of object which will be removed
         * @param key - key of object which will be removed
         */

        public bool Remove(T data, Key key)
        {
            if (data == null || key == null)
            {
                return false;
            }
            Node<Key, T> node = new Node<Key, T>(key, data);            
                        
            List<Node<Key, T>> toRemove = FindNode(node);
            
            if (toRemove == null || toRemove.Count == 0)
            {
                return false;
            }
            Node<Key, T> nodeToRemove = toRemove[0];
            
            /*if (toRemove.Count > 1)
            {
                foreach(Node<Key, T> removing in toRemove)
                {
                    if (removing.AppKey.Equals(key)) {
                        if (removing.Equals(toRemove[0]))
                        {
                            removing.Data = removing.Duplicates[0].Data;
                            removing.AppKey = removing.Duplicates[0].AppKey;
                            removing.Duplicates.RemoveAt(0);
                        } else
                        {
                            toRemove[0].Duplicates.Remove(removing);
                        }
                    }
                }
            }*/
             
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
        /* Help method FidnMax for Remove method
         * @param node - node determines which subtree is used from parent node
         */
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

                // Update max if current node is greater than the previous max
                if (current.AppKey.Compare(max.AppKey, level) == 1)
                {
                    max = current;
                }

                // Check both subtrees if they exist and decide direction
                if (current.Right != null && current.AppKey.Compare(current.Right.AppKey, level) == -1)
                {
                    current = current.Right;
                }
                else if (current.Left != null && current.AppKey.Compare(current.Left.AppKey, level) == -1)
                {
                    current = current.Left;
                }
                else
                {
                    // If neither left nor right subtrees have greater nodes, stop
                    break;
                }

                level++; // Increment level to switch dimensions
            }

            return max;
        }
        /* Help method FindMin for Remove method
         * @param node - node determines which subtree is used from parent node
         */
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
                // Update min if current node is smaller than the previous min
                if (current.AppKey.Compare(min.AppKey, level) == -1)
                {
                    min = current;
                }

                // Check both subtrees if they exist and decide direction
                if (current.Left != null && current.AppKey.Compare(current.Left.AppKey, level) == 1)
                {
                    current = current.Left;
                }
                else if (current.Right != null && current.AppKey.Compare(current.Right.AppKey, level) == 1)
                {
                    current = current.Right;
                }
                else
                {
                    // If neither left nor right subtrees have smaller nodes, stop
                    break;
                }

                level++; // Increment level to switch dimensions
            }

            return min;
        }
        /* Help method FindNode for Find method
         * @param node - node to be found in tree
         */
        private List<Node<Key, T>> FindNode(Node<Key, T> node)
        {
            if (node == null || Root == null)
            {
                return new List<Node<Key, T>>();
            }
            List<Node<Key, T>> returningNodes = new List<Node<Key, T>>();
            CurrentNode = Root;
            Level = 0;
            int comparison;
            int level = 0;
            while (CurrentNode != node)
            {
                comparison = node.AppKey.Compare(CurrentNode.AppKey, level);
                if (comparison == -1)
                {
                    if (CurrentNode.Left == null)
                    {
                        /*returningNodes.Add(CurrentNode);
                        if (CurrentNode.Duplicates != null && CurrentNode.Duplicates.Count() > 0)
                        {
                            returningNodes.AddRange(CurrentNode.Duplicates);
                        }/
                        if (CurrentNode.Right != null)
                        {
                            CurrentNode = CurrentNode.Right;
                            level++;
                            continue;
                        }
                        else
                        {
                            return returningNodes;
                        }*/
                        return returningNodes;

                    }
                    CurrentNode = CurrentNode.Left;
                    level++;
                    continue;
                }
                else if (comparison == 1)
                {
                    if (CurrentNode.Right == null)
                    {
                        /*returningNodes.Add(CurrentNode);
                        if (CurrentNode.Duplicates != null && CurrentNode.Duplicates.Count > 0)
                        {
                            returningNodes.AddRange(CurrentNode.Duplicates);
                        }
                        if (CurrentNode.Left != null)
                        {
                            CurrentNode = CurrentNode.Left;
                            level++;
                            continue;
                        } else
                        {
                            return returningNodes;
                        }*/
                        return returningNodes;

                    }
                    CurrentNode = CurrentNode.Right;
                    level++;
                    continue;
                }
                else
                {
                    /*if (CurrentNode.Data.Equals(node.Data))
                    {
                        if (CurrentNode.Duplicates != null || CurrentNode.Duplicates.Count != 0)
                        {
                            //Unfortunately, this works only in .net8, but i have to support .net6 :(
                            //Return all duplicates of node and actual node                        
                            //List<Node<Key, T>> tempList = [CurrentNode, .. CurrentNode.Duplicates];
                            returningNodes.Add(CurrentNode);
                            returningNodes.AddRange(CurrentNode.Duplicates);                            
                            return returningNodes;

                        }
                        returningNodes.Add(CurrentNode);
                        return returningNodes;
                    }
                    else
                    {
                        
                    }*/
                    returningNodes.Add(CurrentNode);
                    return returningNodes;

                }
            }
            return new List<Node<Key, T>>() { CurrentNode };
        }
        /* Help method Swap for Remove method
         * @param nodeToRemove - node which will be removed
         * @param node - node for replacement od node to remove
         */
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
        /*Find method of K-D tree
         * @param data - data of object which will be used for finding
         * @param key - key of object which will be used for finding
         */
        public List<T> Find(T data, Key key)
        {
            if (data == null || key == null)
            {
                return default;
            }
            Node<Key, T> node = new Node<Key, T>(key, data);
            List<Node<Key, T>> nodes = FindNode(node);
            if (nodes.Count == 1)
            {
                List<T> result = new List<T>();
                result.Add(nodes[0].Data);
                return result;
            } else
            {
                List<T> result = new List<T>();
                foreach (Node<Key, T> prop in nodes)
                {
                    result.Add(prop.Data);
                }
                return result;
            }
        }
        /*Update method of K-D tree
         * @param newData - new data for replacement of oldData
         * @param newKey - new key for replacement of oldKey
         * @param oldData - data of object which will be used for finding and then replaced by newData
         * @param oldKey - key of object which will be used for finding and then replaced by newKey
         */
        public bool Update(T newData, Key newKey, T oldData, Key oldKey)
        {
            if (oldData == null || oldKey == null || newData == null || newKey == null)
            {
                return false;
            }
            Node<Key, T> temp = new Node<Key, T>(oldKey, oldData);
            Property tempData = null; 
            List<Node<Key, T>> nodes = FindNode(temp);
            /*if (nodes.Count > 1) 
            {
                foreach (Node<Key, T> node in nodes)
                {
                    if (node.AppKey.Equals(newKey))
                    {
                        temp = node;
                    }
                }
            }*/
            if (nodes.Count == 0)
            {
                return false;
            }
            if (nodes.Count == 1)
            {
                tempData = (Property)nodes[0].Data;
            }
            if (temp.AppKey.Equals(newKey))
            {
                if (tempData.DataEquals((Property)newData))
                {
                    return true;
                } else
                {
                    temp.Data = newData;
                }                        
            } else
            {
                temp.AppKey = newKey;
            }
            bool removed = Remove(temp.Data, temp.AppKey);
            if (removed)
            {
                bool inserted = Insert(temp.Data, temp.AppKey);
                return inserted;
            } else
            {
                throw new InvalidOperationException("Error removing old node");
            }            
        }
        /*Inorder method for test cases
         * @param data - data from where will be the tree traversed
         * @param key - key from where will be the tree traversed
         */
        public List<Node<Key, T>> InOrder(T data, Key key)
        {
            if (data == null || key == null)
            {
                return new List<Node<Key, T>>();
            }
            Node<Key, T> current = new Node<Key, T>(key, data);
            List<Node<Key, T>> nodes = FindNode(current);
            if (nodes != null && nodes.Count > 0) 
            {
                current = nodes[0];
            } else
            {
                throw new Exception("Can't make inOrder traversal, node was not found");
            }
            nodes.Clear();
            while (current != null)
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
    }   
}
