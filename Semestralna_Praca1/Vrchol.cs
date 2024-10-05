namespace Semestralna_Praca1
{
    public class Vrchol<T>
    {
        public Vrchol<T>? Pravy { get; set; }
        public Vrchol<T>? Lavy { get; set; }
        public T? Data { get; set; }
        public List<T> Kluc { get; set; }
        public Vrchol(List<T> kluc, T? data)
        {
            Pravy = null;
            Lavy = null;
            Data = data;
            Kluc = kluc;
        }
    }
}
