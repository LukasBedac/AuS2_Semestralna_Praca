namespace Semestralna_Praca1
{
    public class Strom<T>
    {
        public Vrchol<T>? Koren { get; set; }
        public int Uroven { get; set; }
        public int Hlbka { get; set; }
        private const int K = 2;
        public Strom() 
        {
            Koren = null;
            Uroven = 0;
            Hlbka = 1;
        }

        public bool Insert(Vrchol<T> vrchol)
        {
            if (vrchol == null)
            {
                return false;
            }
            if (vrchol.Equals(Koren))
            {
                return false;
            }

            if (Hlbka % K == 0)
            {
                T suradnicaY = vrchol.Kluc[0];
                if (suradnicaY == null)
                {
                    return false;
                }
            } else
            {
                T suradnicaX = vrchol.Kluc[0];
                if (suradnicaX == null)
                {
                    return false;
                }                
                //Porovnat suradnicu < koren = P : L
            }
            return true;
        }
    }

    
}
