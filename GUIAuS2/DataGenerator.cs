using Semestralna_Praca1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIAuS2
{    
    public class DataGenerator
    {
        private static DataGenerator instance;

        public const int NUMBEROFPROPERTIES = REALESTATESNUMBER + LOTSNUMBER;
        public const int REALESTATESNUMBER = 10000;
        public const int LOTSNUMBER = 10000;
        public const int DIMENSION = 4;

        public KDTree<TestKey, Property> TreeRealEstate { get; set; }
        public KDTree<TestKey, Property> TreeLot { get; set; }
        public KDTree<TestKey, Property> TreeProperty { get; set; }

        public List<Property> InsertedProps { get; set; } = new List<Property>();
        public List<TestKey> InsertedKeys { get; set; } = new List<TestKey>();

        private int duplicatesPercent;
        public DataGenerator()
        {                        

        }
        public void CreateTrees()
        {
            Property realEstateRoot = new RealEstate();
            realEstateRoot.GPSCoords = new List<GPS>() { GPSGenerator.GetGPS(), GPSGenerator.GetGPS() };
            realEstateRoot.Description = PropNameGenerator.GetPropertyName();
            realEstateRoot.Number = PropNumberGenerator.GetPropertyNumber();
            realEstateRoot.ID = UniqueIDGenerator.GetUniqueID();
            TreeRealEstate = new KDTree<TestKey, Property>(GenerateKey(realEstateRoot), realEstateRoot , DIMENSION);

            Property lotRoot = new Lot();
            lotRoot.GPSCoords = new List<GPS>() { GPSGenerator.GetGPS(), GPSGenerator.GetGPS() };
            lotRoot.Description = PropNameGenerator.GetPropertyName();
            lotRoot.Number = PropNumberGenerator.GetPropertyNumber();
            lotRoot.ID = UniqueIDGenerator.GetUniqueID();
            TreeLot = new KDTree<TestKey, Property>(GenerateKey(lotRoot), lotRoot, DIMENSION);

            TreeProperty = new KDTree<TestKey, Property>(GenerateKey(realEstateRoot), realEstateRoot, DIMENSION);
            InsertedProps.Add(realEstateRoot);
            TreeProperty.Insert(lotRoot, GenerateKey(lotRoot));            
            InsertedProps.Add(lotRoot);
        }
        public TestKey GenerateKey(Property prop)
        {
            TestKey key = new TestKey();
            key.X = "N".Equals(prop.GPSCoords[0].Latitude) ? prop.GPSCoords[0].LatitudeCoord : -prop.GPSCoords[0].LatitudeCoord;
            key.Y = "E".Equals(prop.GPSCoords[1].Longtitude) ? prop.GPSCoords[1].LongtitudeCoord : -prop.GPSCoords[1].LongtitudeCoord;
            key.B = KeyValuesGenerator.GetStringKey();
            key.C = KeyValuesGenerator.GetIntKey();
            InsertedKeys.Add(key);
            return key;
        }
        
        public void FillTrees()
        {
            bool inserted = false;
            bool isRealEstate = false;
            int insertedCount = 2; //Add root to each tree, but not the one for both objects
            for (int i = 0; i < NUMBEROFPROPERTIES; i++)
            {
                if (i < NUMBEROFPROPERTIES - LOTSNUMBER)
                {
                    isRealEstate = true;
                    inserted = Insert(TreeRealEstate, isRealEstate);
                }
                else
                {
                    isRealEstate = false;
                    inserted = Insert(TreeLot, isRealEstate);
                }
                if (inserted)
                {
                    insertedCount++;
                    Insert(TreeProperty, isRealEstate);
                } else
                {
                    throw new Exception("Data generation failed while inserting into trees");
                }                
            }
            List<Node<TestKey, Property>> returned = TreeProperty.InOrder(TreeProperty.Root.Data, TreeProperty.Root.AppKey);
            Console.WriteLine("Inserted count: " + insertedCount);
            Console.WriteLine("Returned inOrder count: " + returned.Count);
        }
        public bool Insert(KDTree<TestKey, Property> tree, bool isRealEstate)
        {
            Property prop;
            if (tree == null)
            {
                return false;
            }
            if (isRealEstate)
            {
                prop = new RealEstate();
            } else
            {
                prop = new Lot();
            }
            prop.GPSCoords = new List<GPS>() { GPSGenerator.GetGPS(), GPSGenerator.GetGPS() };
            prop.Description = PropNameGenerator.GetPropertyName();
            prop.Number = PropNumberGenerator.GetPropertyNumber();
            prop.ID = UniqueIDGenerator.GetUniqueID();
            if (tree.Equals(TreeProperty))
            {
                InsertedProps.Add(prop);
            }
            Console.WriteLine("Coords to test: " + GenerateKey(prop).X + " , " + GenerateKey(prop).Y);
            return tree.Insert(prop, GenerateKey(prop));
        }       

        public static DataGenerator GetDataGenerator()
        {
            if (instance == null)
            {
                instance = new DataGenerator();
            }
            return instance;
        }
    }
}
