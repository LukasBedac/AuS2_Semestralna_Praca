namespace Semestralna_Praca1
{
    public class RealEstate : Property
    {
        public int ID { get; set; }
        public int InventoryNumber { get; set; }
        public string Description { get; set; }
        public List<Lot> LotsList { get; set; }
        public List<GPS> GPSCoords { get; set; }

        public RealEstate(int Id)
        {
            ID = Id;
            GPSCoords = new List<GPS>();
            LotsList = new List<Lot>();
            Description = string.Empty;
        }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
