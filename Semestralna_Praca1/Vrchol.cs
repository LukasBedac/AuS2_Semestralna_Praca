namespace Semestralna_Praca1
{
    public class Vrchol<T>
    {
        public Vrchol<T> Pravy { get; set; }
        public Vrchol<T> Lavy { get; set; }
        public T Data { get; set; }
        public Vrchol() 
        {
            Pravy = null;
            Lavy = null; 
        }
    }
}
