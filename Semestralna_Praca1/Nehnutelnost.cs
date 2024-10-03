namespace Semestralna_Praca1
{
    public class Nehnutelnost
    {
        public int SupCislo { get; set; }
        public string Popis { get; set; }
        public List<Parcela> ZoznamParciel { get; set; }
        public List<GPS> GPSSuradnice { get; set; }

    }
}
