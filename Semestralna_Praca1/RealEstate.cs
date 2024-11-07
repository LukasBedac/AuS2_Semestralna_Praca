namespace Semestralna_Praca1
{
    public class RealEstate : Property
    {
        public int ID { get; set; }
        public int Number { get; set; }
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
        public RealEstate() 
        {
            ID = default;
            GPSCoords = new List<GPS>();
            LotsList = new List<Lot>();
            Description = string.Empty;
        }
        public override string ToString()
        {
            return ID.ToString();
        }

        public bool Equals(Property data)
        {
            return this.ID == data.ID;
        }
        public bool DataEquals(Property data)
        {
            if (!this.Description.Equals(data.Description))
            {
                return false;
            }
            if (!this.Number.Equals(data.Number))
            {
                return false;
            }
            if (!this.GPSCoords[0].Equals(data.GPSCoords[0]))
            {
                return false;
            }
            if (!this.GPSCoords[1].Equals(data.GPSCoords[1]))
            {
                return false;
            }
            return true;
        }
    }
}
