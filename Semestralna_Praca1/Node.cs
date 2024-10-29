using System.Reflection.Metadata.Ecma335;

namespace Semestralna_Praca1
{
    public class Node<T>
    {
        public Node<T>? Parent { get; set; }
        public Node<T>? Right { get; set; }
        public Node<T>? Left { get; set; }
        public T Data { get; set; }        
        public Key Key { get; set; }
        public List<Node<T>> Duplicates { get; set; }
        public Node(T data, Key key)
        {
            Parent = null;
            Right = null;
            Left = null;
            Duplicates = new List<Node<T>>();
            Data = data;
            Key = key;
        }
    }
}
