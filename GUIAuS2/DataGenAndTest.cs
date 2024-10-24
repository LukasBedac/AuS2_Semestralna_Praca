using Semestralna_Praca1;
namespace Semestralna_Praca1
{
    public class DataGenAndTest
    {
        private const int NUMBEROFPROPERTIES = 1000000;
        public void CreateRealEstateTree()
        {
            Random rand = new Random();
            
            KDTree<Key ,RealEstate> tree = null;
            double temp1 = 0.0;
            double temp2 = 0.0;
            for (int i = 0; i < NUMBEROFPROPERTIES; i++)
            {
                if (i == 3)
                {

                }
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

                RealEstate estate = new RealEstate(i);
                estate.GPSCoords.Add(gps1);
                estate.GPSCoords.Add(gps2);                                
                Key key = new Key();
                if (i == 3)
                {
                    key.X = temp1;
                    key.Y = temp2;
                } else
                {
                    key.X = 'N'.Equals(estate.GPSCoords[0].Latitude) ? estate.GPSCoords[0].LatitudeCoord : -estate.GPSCoords[0].LatitudeCoord;
                    key.Y = 'E'.Equals(estate.GPSCoords[0].LongtitudeCoord) ? estate.GPSCoords[0].LongtitudeCoord : -estate.GPSCoords[0].LongtitudeCoord;
                }
                Node<RealEstate> node = new Node<RealEstate>(estate, key);
                if (i == 0)
                {
                    temp1 = key.X;
                    temp2 = key.Y;
                }
                
                if (i == 0)
                {
                    tree = new KDTree<Key, RealEstate>(node);
                }
                else
                {
                    tree.Insert(node);
                }
            }
        }

        public void CreateLotTree()
        {
            Random rand = new Random(4);
            KDTree<Key, Lot> tree = null;
            for (int i = 0; i < NUMBEROFPROPERTIES; i++)
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

                Lot lot = new Lot(i);
                lot.GPSCoords.Add(gps1);
                lot.GPSCoords.Add(gps2);
                Key key = new Key();
                key.X = 'N'.Equals(lot.GPSCoords[0].Latitude) ? lot.GPSCoords[0].LatitudeCoord : -lot.GPSCoords[0].LatitudeCoord;
                key.Y = 'E'.Equals(lot.GPSCoords[0].LongtitudeCoord) ? lot.GPSCoords[0].LongtitudeCoord : -lot.GPSCoords[0].LongtitudeCoord;
                Node<Lot> node = new Node<Lot>(lot, key);

                if (i == 0)
                {
                    tree = new KDTree<Key, Lot>(node);
                }
                else
                {
                    tree.Insert(node);
                }
            }
        }

        public void Insert()
        {

        }
        public void Find()
        {

        }
        public void Delete()
        {

        }
    }
}
