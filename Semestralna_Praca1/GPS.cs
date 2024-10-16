namespace Semestralna_Praca1
{
    public class GPS
    {
        public char Latitude { get; set; } 
        public double LatitudeCoord { get; set; }
        public char Longtitude { get; set; }
        public double LongtitudeCoord { get; set; }

        public Lot Lot
        {
            get => default;
            set
            {
            }
        }

        public RealEstate RealEstate
        {
            get => default;
            set
            {
            }
        }
    } 

}
