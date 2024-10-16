namespace Semestralna_Praca1
{
    public class RealEstate
    {
        public int InventoryNumber { get; set; }
        public string Description { get; set; }
        public List<Lot> LotsList { get; set; }
        public List<GPS> GPSCoords { get; set; }

        public Lot Lot
        {
            get => default;
            set
            {
            }
        }

        public RealEstate() 
        {
            GPSCoords = new List<GPS>();
            LotsList = new List<Lot>();
            Description = string.Empty;
        }
    }
}
