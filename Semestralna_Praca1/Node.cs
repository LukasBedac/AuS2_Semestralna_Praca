using System.Reflection.Metadata.Ecma335;

namespace Semestralna_Praca1
{
    public class Node<Key , T> where Key : DataKey
    {
        public Node<Key, T>? Parent { get; set; }
        public Node<Key, T>? Right { get; set; }
        public Node<Key, T>? Left { get; set; }
        public T Data { get; set; } 
        public Key AppKey { get; set; }
        public List<Node<Key, T>> Duplicates { get; set; }
        public Node(Key key, T data)
        {
            Parent = null;
            Right = null;
            Left = null;
            Duplicates = new List<Node<Key, T>>();
            Data = data;
            AppKey = key;
        }
    }
}
