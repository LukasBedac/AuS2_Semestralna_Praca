namespace Semestralna_Praca1
{
    public class Lot<T> : DataKey<T> where T : DataKey<T>
    {
        public int LotNumber { get; set; }
        public string Description { get; set; }
        public List<RealEstate<T>> RealEstatesList { get; set; }
        public List<GPS> GPSCoords { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public int Compare(T data, int level)
        {
            
            if (data == null)
            {
                throw new Exception("Data for comparison was null");
            }
            if (level % 2 == 0)
            {
                double X = 'N'.Equals(GPSCoords[0].Latitude) ? GPSCoords[0].LatitudeCoord : -GPSCoords[1].LatitudeCoord;                
                if (X <= data.X)
                {
                    return -1;
                }
                else if (X == data.X)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {                
                double Y = 'E'.Equals(GPSCoords[1].Longtitude) ? GPSCoords[1].LongtitudeCoord : -GPSCoords[1].LongtitudeCoord;
                if (Y <= this.Y)
                {
                    return -1;
                }
                else if (Y == this.Y)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
