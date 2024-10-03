
namespace Semestralna_Praca1
{
    public class Parcela
    {
        public int CisloParcely { get; set; }
        public string Popis { get; set; }
        public List<Nehnutelnost> ZoznamNehnutelnosti { get; set; }
        public List<GPS> GPSSuradnice { get; set; }
    }
}
