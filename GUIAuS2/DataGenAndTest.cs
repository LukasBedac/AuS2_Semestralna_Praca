using Semestralna_Praca1;
namespace Semestralna_Praca1
{
    public class DataGenAndTest
    {
        public void CreateRealEstateTree()
        {
            Random rand = new Random();
            KDTree<RealEstate> tree = null;
            for (int i = 0; i < 10; i++)
            {
                
                GPS gps1 = new GPS();
                GPS gps2 = new GPS();
                gps1.Latitude = rand.NextDouble() < 0.5 ? gps1.Latitude = 'N' : gps1.Latitude = 'S';
                gps1.Longtitude = rand.NextDouble() < 0.5 ? gps1.Longtitude = 'E' : gps1.Longtitude = 'W';
                gps1.LatitudeCoord = rand.NextDouble();
                gps1.LongtitudeCoord = rand.NextDouble();

                gps2.Latitude = rand.NextDouble() < 0.5 ? gps2.Latitude = 'N' : gps2.Latitude = 'S';
                gps2.Longtitude = rand.NextDouble() < 0.5 ? gps2.Longtitude = 'E' : gps2.Longtitude = 'W';
                gps2.LatitudeCoord = rand.NextDouble();
                gps2.LongtitudeCoord = rand.NextDouble();

                RealEstate estate = new RealEstate();
                estate.GPSCoords.Add(gps1);
                estate.GPSCoords.Add(gps2);                                
                Node<RealEstate> node = new Node<RealEstate>(estate);

                node.Data.X = 'N'.Equals(estate.GPSCoords[0].Latitude) ? estate.GPSCoords[0].LatitudeCoord : -estate.GPSCoords[0].LatitudeCoord;
                node.Data.Y = 'E'.Equals(estate.GPSCoords[0].LongtitudeCoord) ? estate.GPSCoords[0].LongtitudeCoord : -estate.GPSCoords[0].LongtitudeCoord;

                if (i == 0)
                {
                    tree = new KDTree<RealEstate>(node);
                }
                else
                {
                    tree.Insert(node);
                }
            }
        }
    }
}
