namespace Semestralna_Praca1
{
    public class RealEstate : DataKey<RealEstate>
    {
        public int InventoryNumber { get; set; }
        public string Description { get; set; }
        public List<Lot> LotsList { get; set; }
        public List<GPS> GPSCoords { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public RealEstate() 
        {
            GPSCoords = new List<GPS>();
            LotsList = new List<Lot>();
            Description = string.Empty;
        }


        public int Compare(RealEstate data, int level)
        {
            
            if (data == null)
            {
                throw new Exception("Data for comparison was null");
            }
            if (level % 2 == 1) {
                double X = 'N'.Equals(GPSCoords[0].Latitude) ? GPSCoords[0].LatitudeCoord : -GPSCoords[1].LatitudeCoord;                
                if (X < data.X)
                {
                    return -1;
                } else if (X > data.X)
                {
                    return 1;
                } else
                {
                    return 0;
                }
            } else
            {                
                double Y = 'E'.Equals(GPSCoords[1].Longtitude) ? GPSCoords[1].LongtitudeCoord : -GPSCoords[1].LongtitudeCoord;
                if (Y < data.Y)
                {
                    return -1;
                } else if (Y > data.Y)
                {
                    return 1;
                } else
                {
                    return 0;
                }
            }
        }
    }
}
