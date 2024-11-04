using Semestralna_Praca1;
using GUIAuS2;
namespace Semestralna_Praca1
{
    public class DataGenAndTest
    {
        
        /*private Lot lotToFind;
        private TestKey keyToFind;
        private Property deleteProp;
        private TestKey deleteKey;
        private Lot root;
        private TestKey rootKey;
        private Random randGPS = new Random();
        private Random randMethod = new Random();
        private Random randProp = new Random();
        private Random randChars = new Random();
        private Random randInteger = new Random();
        private RealEstate ReRoot;
        private TestKey ReRootKey;

        private Lot LotRoot;
        private TestKey LoteRootKey;

        private KDTree<TestKey, Property> AllTree;
        private KDTree<TestKey, Property> ReTree;
        private KDTree<TestKey, Property> LotTree;
        private List<Property> inserted = new List<Property>();
        private List<DataKey> keys = new List<DataKey>();
        public void CreateRealEstateTree()
        {
            Random rand = new Random();

            KDTree<TestKey, RealEstate> tree = null;
            double temp1 = 0.0;
            double temp2 = 0.0;
            for (int i = 0; i < REALESTATESNUMBER; i++)
            {

                GPS gps1 = new GPS();
                GPS gps2 = new GPS();
                gps1.Latitude = rand.NextDouble() < 0.5 ? gps1.Latitude = "N" : gps1.Latitude = "S";
                gps1.Longtitude = rand.NextDouble() < 0.5 ? gps1.Longtitude = "E" : gps1.Longtitude = "W";
                gps1.LatitudeCoord = rand.NextDouble();
                gps1.LongtitudeCoord = rand.NextDouble();

                gps2.Latitude = rand.NextDouble() < 0.5 ? gps2.Latitude = "N" : gps2.Latitude = "S";
                gps2.Longtitude = rand.NextDouble() < 0.5 ? gps2.Longtitude = "E" : gps2.Longtitude = "W";
                gps2.LatitudeCoord = rand.NextDouble();
                gps2.LongtitudeCoord = rand.NextDouble();

                RealEstate estate = new RealEstate(i);
                estate.GPSCoords.Add(gps1);
                estate.GPSCoords.Add(gps2);
                TestKey key = new TestKey();
                if (i == 3)
                {
                    key.X = temp1;
                    key.Y = temp2;
                }
                else
                {
                    key.X = "N".Equals(estate.GPSCoords[0].Latitude) ? estate.GPSCoords[0].LatitudeCoord : -estate.GPSCoords[0].LatitudeCoord;
                    key.Y = "E".Equals(estate.GPSCoords[0].LongtitudeCoord) ? estate.GPSCoords[0].LongtitudeCoord : -estate.GPSCoords[0].LongtitudeCoord;
                }
                if (i == 0)
                {
                    temp1 = key.X;
                    temp2 = key.Y;
                }

                if (i == 0)
                {
                    ReTree = new KDTree<TestKey, Property>(key, estate, 4);
                    AllTree = new KDTree<TestKey, Property>(key, estate, 4);
                    inserted.Add(estate);
                    keys.Add(key);
                }
                else
                {
                    ReTree.Insert(estate, key);
                    AllTree.Insert(estate, key);
                    inserted.Add(estate);
                    keys.Add(key);
                }
            }
        }

        public void CreateLotTree()
        {
            Random rand = new Random();
            KDTree<TestKey, Lot> tree = null;
            Random random2 = new Random();
            List<Property> list = new List<Property>();
            //List<TestKey> keys = new List<TestKey>();
            for (int i = REALESTATESNUMBER + 1; i < REALESTATESNUMBER + LOTSNUMBER; i++)
            {

                GPS gps1 = new GPS();
                GPS gps2 = new GPS();
                gps1.Latitude = rand.NextDouble() < 0.5 ? gps1.Latitude = "N" : gps1.Latitude ="S";
                gps1.Longtitude = rand.NextDouble() < 0.5 ? gps1.Longtitude = "E" : gps1.Longtitude = "W";
                gps1.LatitudeCoord = rand.NextDouble();
                gps1.LongtitudeCoord = rand.NextDouble();

                gps2.Latitude = rand.NextDouble() < 0.5 ? gps2.Latitude = "N" : gps2.Latitude = "S";
                gps2.Longtitude = rand.NextDouble() < 0.5 ? gps2.Longtitude = "E" : gps2.Longtitude = "W";
                gps2.LatitudeCoord = rand.NextDouble();
                gps2.LongtitudeCoord = rand.NextDouble();

                Lot lot = new Lot(i);
                lot.GPSCoords.Add(gps1);
                lot.GPSCoords.Add(gps2);
                TestKey key = new TestKey();
                key.X = "N".Equals(lot.GPSCoords[0].Latitude) ? lot.GPSCoords[0].LatitudeCoord : -lot.GPSCoords[0].LatitudeCoord;
                key.Y = "E".Equals(lot.GPSCoords[0].LongtitudeCoord) ? lot.GPSCoords[0].LongtitudeCoord : -lot.GPSCoords[0].LongtitudeCoord;
                if (rand.NextDouble() < 0.3)
                {
                    lotToFind = lot;
                    keyToFind = key;
                }
                if (i == REALESTATESNUMBER + 1)
                {
                    LotTree = new KDTree<TestKey, Property>(key, lot, 4);
                    AllTree.Insert(lot, key);
                    list.Add(lot);
                    inserted.Add(lot);
                    keys.Add(key);
                    deleteProp = lot;
                    deleteKey = key;
                    root = lot;
                    rootKey = key;
                    continue;
                }            
                
                else
                {
                    LotTree.Insert(lot, key);
                    AllTree.Insert(lot, key);
                    inserted.Add(lot);
                    list.Add(lot);
                    keys.Add(key);
                }
            }
          *//* // tree.Remove(root, rootKey);
            for (int i = 0; i < NUMBEROFPROPERTIES - 1; i++)
            {
                int find = rand.Next(list.Count);
                Property prop = list[find];
                TestKey propKey = keys[find];
                //bool removed = tree.Remove((Lot)prop, propKey);
                //Console.WriteLine(removed);
                
                Lot newLot = tree.Find((Lot)prop, propKey);
                if (newLot == null)
                {
                    Console.WriteLine("Not found");
                }
                else
                {
                    Console.WriteLine("Find lot: " + newLot.ToString());
                }
            }
            for (int i = 0; i < NUMBEROFPROPERTIES - 1; i++)
            {
                Property prop = list[i];
                TestKey propKey = keys[i];
                Lot newLot = tree.Find((Lot)prop, propKey);
                
            }*//*
           
        }
        //TODO 1.2 Implement methods for inserting, finding and deleting
        public void CreateRoots()
        {
            for (int i = 0; i < 2; i++)
            {
                GPS gps1 = new GPS();
                GPS gps2 = new GPS();
                gps1.Latitude = randGPS.NextDouble() < 0.5 ? gps1.Latitude = "N" : gps1.Latitude ="S";
                gps1.Longtitude = randGPS.NextDouble() < 0.5 ? gps1.Longtitude = "E" : gps1.Longtitude = "W";
                gps1.LatitudeCoord = randGPS.NextDouble();
                gps1.LongtitudeCoord = randGPS.NextDouble();

                gps2.Latitude = randGPS.NextDouble() < 0.5 ? gps2.Latitude = "N" : gps2.Latitude = "S";
                gps2.Longtitude = randGPS.NextDouble() < 0.5 ? gps2.Longtitude = "E" : gps2.Longtitude = "W";
                gps2.LatitudeCoord = randGPS.NextDouble();
                gps2.LongtitudeCoord = randGPS.NextDouble();
                if (i == 0)
                {
                    ReRoot = new RealEstate(0);
                    ReRoot.GPSCoords.Add(gps1);
                    ReRoot.GPSCoords.Add(gps2);
                    ReRootKey.X = "N".Equals(ReRoot.GPSCoords[0].Latitude) ? ReRoot.GPSCoords[0].LatitudeCoord : -ReRoot.GPSCoords[0].LatitudeCoord;
                    ReRootKey.Y = "E".Equals(ReRoot.GPSCoords[0].LongtitudeCoord) ? ReRoot.GPSCoords[0].LongtitudeCoord : -ReRoot.GPSCoords[0].LongtitudeCoord;
                    int numberOfChars = randChars.Next(10);
                    string stringKey = "";
                    for (int k = 0; k < numberOfChars; k++)
                    {

                        stringKey += chars[randChars.Next(chars.Count())];
                    }
                    ReRootKey.B = stringKey;
                    ReRootKey.C = randInteger.Next(NUMBEROFPROPERTIES);
                } else
                {
                    LotRoot = new Lot(1);
                    LotRoot.GPSCoords.Add(gps1);
                    LotRoot.GPSCoords.Add(gps2);
                    LoteRootKey.X = "N".Equals(ReRoot.GPSCoords[0].Latitude) ? ReRoot.GPSCoords[0].LatitudeCoord : -ReRoot.GPSCoords[0].LatitudeCoord;
                    LoteRootKey.Y = "E".Equals(ReRoot.GPSCoords[0].LongtitudeCoord) ? ReRoot.GPSCoords[0].LongtitudeCoord : -ReRoot.GPSCoords[0].LongtitudeCoord;
                    int numberOfChars = randChars.Next(10);
                    string stringKey = "";
                    for (int k = 0; k < numberOfChars; k++)
                    {

                        stringKey += chars[randChars.Next(chars.Count())];
                    }
                    LoteRootKey.B = stringKey;
                    LoteRootKey.C = randInteger.Next(NUMBEROFPROPERTIES);
                }
            }
            

            
        }
        private GPS CreateGPS()
        {
            GPS gps = new GPS();
            gps.Latitude = randGPS.NextDouble() < 0.5 ? gps.Latitude = "N" : gps.Latitude = "S";
            gps.Longtitude = randGPS.NextDouble() < 0.5 ? gps.Longtitude = "E" : gps.Longtitude = "W";
            gps.LatitudeCoord = randGPS.NextDouble();
            gps.LongtitudeCoord = randGPS.NextDouble();
            return gps;

        }
        
        private void CreateRealEstate()
        {
          *//*  RealEstate re = new RealEstate();
            ReRoot = new RealEstate(0);
            ReRoot.GPSCoords.Add(gps1);
            ReRoot.GPSCoords.Add(gps2);
            ReRootKey.X = 'N'.Equals(ReRoot.GPSCoords[0].Latitude) ? ReRoot.GPSCoords[0].LatitudeCoord : -ReRoot.GPSCoords[0].LatitudeCoord;
            ReRootKey.Y = 'E'.Equals(ReRoot.GPSCoords[0].LongtitudeCoord) ? ReRoot.GPSCoords[0].LongtitudeCoord : -ReRoot.GPSCoords[0].LongtitudeCoord;
            int numberOfChars = randChars.Next(10);
            string stringKey = "";
            for (int k = 0; k < numberOfChars; k++)
            {

                stringKey += chars[randChars.Next(chars.Count())];
            }
            ReRootKey.B = stringKey;
            ReRootKey.C = randInteger.Next(NUMBEROFPROPERTIES);*//*
        }
        private void CreateLot()
        {

        }
        public void CreateTrees()
        {
            GenerateData();
            CreateRealEstateTree();
            CreateLotTree();
 
                KDTree<TestKey, Property> tree;
                for (int i = 0; i < 100; i++)
                {
                    double chance = randMethod.NextDouble();
                    double treeChance = randProp.NextDouble();
                    if (treeChance <= 0.5)
                    {
                        tree = ReTree;
                    } else
                    {
                        tree = LotTree;
                    }
                    if (chance <= 0.33)
                    {
                    if (treeChance <= 0.5)
                    {
                        RealEstate re = new RealEstate(randInteger.Next(REALESTATESNUMBER));
                        TestKey key = new TestKey();
                        GPS gps1 = new GPS();
                        GPS gps2 = new GPS();
                        gps1.Latitude = randGPS.NextDouble() < 0.5 ? gps1.Latitude = "N" : gps1.Latitude = "S";
                        gps1.Longtitude = randGPS.NextDouble() < 0.5 ? gps1.Longtitude = "E" : gps1.Longtitude = "W";
                        gps1.LatitudeCoord = randGPS.NextDouble();
                        gps1.LongtitudeCoord = randGPS.NextDouble();

                        gps2.Latitude = randGPS.NextDouble() < 0.5 ? gps2.Latitude = "N" : gps2.Latitude = "S";
                        gps2.Longtitude = randGPS.NextDouble() < 0.5 ? gps2.Longtitude = "E" : gps2.Longtitude = "W";
                        gps2.LatitudeCoord = randGPS.NextDouble();
                        gps2.LongtitudeCoord = randGPS.NextDouble();
                        re.GPSCoords.Add(gps1);
                        re.GPSCoords.Add(gps2);
                        int numberOfChars = randChars.Next(10);
                        string stringKey = "";
                        for (int k = 0; k < numberOfChars; k++)
                        {

                            stringKey += chars[randChars.Next(chars.Count())];
                        }
                        key.X = 'N'.Equals(re.GPSCoords[0].Latitude) ? re.GPSCoords[0].LatitudeCoord : -re.GPSCoords[0].LatitudeCoord;
                        key.Y = 'E'.Equals(re.GPSCoords[0].LongtitudeCoord) ? re.GPSCoords[0].LongtitudeCoord : -re.GPSCoords[0].LongtitudeCoord;
                        key.B = stringKey;
                        key.C = randInteger.Next();
                        tree.Insert(re, key);
                        AllTree.Insert(re, key);
                        inserted.Add(re);
                        Console.WriteLine("Inserted prop: " + re.ToString());
                    } else
                    {
                        Lot lot = new Lot(randInteger.Next(LOTSNUMBER));
                        TestKey key = new TestKey();
                        GPS gps1 = new GPS();
                        GPS gps2 = new GPS();
                        gps1.Latitude = randGPS.NextDouble() < 0.5 ? gps1.Latitude = "N" : gps1.Latitude = "S";
                        gps1.Longtitude = randGPS.NextDouble() < 0.5 ? gps1.Longtitude = "E" : gps1.Longtitude = "W";
                        gps1.LatitudeCoord = randGPS.NextDouble();
                        gps1.LongtitudeCoord = randGPS.NextDouble();

                        gps2.Latitude = randGPS.NextDouble() < 0.5 ? gps2.Latitude = "N" : gps2.Latitude = "S";
                        gps2.Longtitude = randGPS.NextDouble() < 0.5 ? gps2.Longtitude = "E" : gps2.Longtitude = "W";
                        gps2.LatitudeCoord = randGPS.NextDouble();
                        gps2.LongtitudeCoord = randGPS.NextDouble();
                        lot.GPSCoords.Add(gps1);
                        lot.GPSCoords.Add(gps2);
                        int numberOfChars = randChars.Next(10);
                        string stringKey = "";
                        for (int k = 0; k < numberOfChars; k++)
                        {

                            stringKey += chars[randChars.Next(chars.Count())];
                        }
                        key.X = "N".Equals(lot.GPSCoords[0].Latitude) ? lot.GPSCoords[0].LatitudeCoord : -lot.GPSCoords[0].LatitudeCoord;
                        key.Y = "E".Equals(lot.GPSCoords[0].LongtitudeCoord) ? lot.GPSCoords[0].LongtitudeCoord : -lot.GPSCoords[0].LongtitudeCoord;
                        key.B = stringKey;
                        key.C = randInteger.Next();
                        tree.Insert(lot, key);
                        AllTree.Insert(lot, key);
                        inserted.Add(lot);
                        keys.Add(key);
                        Console.WriteLine("Inserted prop: " + lot.ToString());
                    }
                       
                } else if (chance <= 0.66)
                {
                    int find = randProp.Next(inserted.Count() - 1);
                    Property prop = inserted[find];
                    List<Property> found;
                    TestKey key = (TestKey)keys[find];
                    found = AllTree.Find(prop, key);
                    
                    if (found != null)
                    {
                        Console.WriteLine("Find: " + prop.ToString());
                    } else
                    {
                        Console.WriteLine("Not Found: " + prop.ToString());
                    }
                        
                } else
                {
                    int find = randProp.Next(1000);
                    Property prop = inserted[find];
                    bool oneTreeBool;
                    TestKey key = (TestKey)keys[find];
                    if (prop is RealEstate)
                    {
                        prop = (RealEstate)prop;
                        oneTreeBool = ReTree.Remove(prop, key);
                    }
                    else
                    {
                        prop = (Lot)prop;
                        oneTreeBool = LotTree.Remove(prop, key);
                    }
                    bool allBool = AllTree.Remove(prop, key);
                    if(allBool == false && oneTreeBool == false) {
                        allBool = AllTree.Remove(prop, key);
                    }
                    Console.WriteLine("Deleted property: " + prop.ToString());
                    Console.WriteLine("Deleted in tree: " + oneTreeBool + " and in allTree: " + allBool);
                    inserted.Remove(prop);
                    keys.Remove(key);
                }                
            }
            *//*CreateRoots();
            KDTree<TestKey, Property> ReTree = new KDTree<TestKey, Property>(ReRootKey, ReRoot);
            KDTree<TestKey, Property> LotTree = new KDTree<TestKey, Property>(LoteRootKey, LotRoot);
            KDTree<TestKey, Property> AllTree = new KDTree<TestKey, Property>(ReRootKey, ReRoot);
            List<Property> inserted = new List<Property>();
            Property inserting;
            for (int j = 0; j < 1000; j++)
            {
                double treeSelect = randProp.NextDouble();
                if (treeSelect <= 0.5)
                {
                    ReTree.Insert();
                } else
                {
                    LotTree.Insert();
                }
                AllTree.Insert();
            }
            for (int i = 2; i < NUMBEROFPROPERTIES; i++)
            {
                double methodSelect = randMethod.NextDouble();
                if (methodSelect <= 0.33)
                {

                } else if (methodSelect <= 0.66)
                {

                } else
                {

                }
            }*//*
        }
        public void Insert()
        {

        }
        public void Find(KDTree<TestKey, Lot> tree, TestKey key)
        {
            tree.Find(lotToFind, key);
        }
        public void Delete(KDTree<TestKey, Lot> tree, TestKey key)
        {
            //tree.Remove((Lot)deleteProp, key);
        }
        public void GenerateData()
        {

           
        }*/
    }
}