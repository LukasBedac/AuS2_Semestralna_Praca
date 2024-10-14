namespace Semestralna_Praca1
{
    public class Node<T> where T : DataKey<T>
    {
        public Node<T>? Parent { get; set; }
        public Node<T>? Right { get; set; }
        public Node<T>? Left { get; set; }
        public T? Data { get; set; }
        public T Key { get; set; }
        public Node(T key)
        {
            Parent = null;
            Right = null;
            Left = null;
            Key = key;
        }
    }
}
