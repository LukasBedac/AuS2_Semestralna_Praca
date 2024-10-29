using Semestralna_Praca1;
namespace Semestralna_Praca1
{
    public class DataGenAndTest
    {
        private const int NUMBEROFPROPERTIES = 1000000;
        private Lot lotToFind;
        private Key keyToFind;
        private Property deleteProp;
        private Key deleteKey;
        public void CreateRealEstateTree()
        {
            Random rand = new Random();

            KDTree<Key, RealEstate> tree = null;
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
                }
                else
                {
                    key.X = 'N'.Equals(estate.GPSCoords[0].Latitude) ? estate.GPSCoords[0].LatitudeCoord : -estate.GPSCoords[0].LatitudeCoord;
                    key.Y = 'E'.Equals(estate.GPSCoords[0].LongtitudeCoord) ? estate.GPSCoords[0].LongtitudeCoord : -estate.GPSCoords[0].LongtitudeCoord;
                }
                if (i == 0)
                {
                    temp1 = key.X;
                    temp2 = key.Y;
                }

                if (i == 0)
                {
                    tree = new KDTree<Key, RealEstate>(estate, key);
                }
                else
                {
                    tree.Insert(estate, key);
                }
            }
        }

        public void CreateLotTree()
        {
            Random rand = new Random();
            KDTree<Key, Lot> tree = null;
            Random random2 = new Random();
            List<Property> list = new List<Property>();
            List<Key> keys = new List<Key>();
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
                if (rand.NextDouble() < 0.3)
                {
                    lotToFind = lot;
                    keyToFind = key;
                }
                if (i == 0)
                {
                    tree = new KDTree<Key, Lot>(lot, key);
                    list.Add(lot);
                    keys.Add(key);
                    deleteProp = lot;
                    deleteKey = key;
                    continue;
                }            
                if (i == 24)
                {
                    this.Delete(tree, deleteKey);
                }
                else
                {
                    tree.Insert(lot, key);
                    list.Add(lot);
                    keys.Add(key);
                }
            }
            int find = rand.Next(list.Count);
            Property prop = list[find];
            Key propKey = keys[find];
            tree.Find((Lot)prop, propKey);
        }
        //TODO 1.2 Implement methods for inserting, finding and deleting
        public void Insert()
        {

        }
        public void Find(KDTree<Key, Lot> tree, Key key)
        {
            tree.Find(lotToFind, key);
        }
        public void Delete(KDTree<Key, Lot> tree, Key key)
        {
            //tree.Remove((Lot)deleteProp, key);
        }
        //TODO 1.1 Data generation
        public void GenerateData()
        {
            Random randGPS = new Random();
            Random randMethodod = new Random();
            Random randProp = new Random();
        }
    }
}