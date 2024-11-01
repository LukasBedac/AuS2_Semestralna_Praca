namespace Semestralna_Praca1
{
    public class Lot : Property
    {
        public int ID { get; set; }
        public int LotNumber { get; set; }
        public string Description { get; set; }
        public List<RealEstate> RealEstatesList { get; set; }
        public List<GPS> GPSCoords { get; set; }

        public Lot(int Id)
        {
            ID = Id;
            GPSCoords = new List<GPS>();
            RealEstatesList = new List<RealEstate>();
            Description = string.Empty;
        }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
