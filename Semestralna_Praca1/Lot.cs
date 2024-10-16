namespace Semestralna_Praca1
{
    public class Lot
    {
        public int LotNumber { get; set; }
        public string Description { get; set; }
        public List<RealEstate> RealEstatesList { get; set; }
        public List<GPS> GPSCoords { get; set; }

        public RealEstate RealEstate
        {
            get => default;
            set
            {
            }
        }

        public Lot()
        {
            GPSCoords = new List<GPS>();
            RealEstatesList = new List<RealEstate>();
            Description = string.Empty;
        }              
    }
}
