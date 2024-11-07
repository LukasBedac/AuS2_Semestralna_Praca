using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Semestralna_Praca1;
namespace GUIAuS2
{
    public class GUIGenerator
    {
        private static GUIGenerator instance;
        string filePath = "C:\\Users\\Lukas\\Desktop\\Zimny semester\\AuS2\\Sem1\\AuS2_Semestralna_Praca\\GUIAuS2\\SavedData.csv";
        private FileData fileData = new FileData();
        public const int NUMBEROFPROPERTIES = REALESTATESNUMBER + LOTSNUMBER;
        public const int REALESTATESNUMBER = 10000;
        public const int LOTSNUMBER = 10000;
        public const int DIMENSION = 2;
        public KDTree<AppKey, Property> TreeRealEstate { get; set; }
        public KDTree<AppKey, Property> TreeLot { get; set; }
        public KDTree<AppKey, Property> TreeProperty { get; set; }

        public List<Property> InsertedProps { get; set; } = new List<Property>();
        public List<AppKey> InsertedKeys { get; set; } = new List<AppKey>();
        public GUIGenerator() 
        {
            
        }

        public void CreateTrees()
        {

            Property realEstateRoot = new RealEstate();
            realEstateRoot.GPSCoords = new List<GPS>() { GPSGenerator.GetGPS(), GPSGenerator.GetGPS() };
            realEstateRoot.Description = PropNameGenerator.GetPropertyName();
            realEstateRoot.Number = PropNumberGenerator.GetPropertyNumber();
            realEstateRoot.ID = UniqueIDGenerator.GetUniqueID();
            TreeRealEstate = new KDTree<AppKey, Property>(GenerateKey(realEstateRoot), realEstateRoot, DIMENSION);

            Property lotRoot = new Lot();
            lotRoot.GPSCoords = new List<GPS>() { GPSGenerator.GetGPS(), GPSGenerator.GetGPS() };
            lotRoot.Description = PropNameGenerator.GetPropertyName();
            lotRoot.Number = PropNumberGenerator.GetPropertyNumber();
            lotRoot.ID = UniqueIDGenerator.GetUniqueID();
            TreeLot = new KDTree<AppKey, Property>(GenerateKey(lotRoot), lotRoot, DIMENSION);

            TreeProperty = new KDTree<AppKey, Property>(GenerateKey(realEstateRoot), realEstateRoot, DIMENSION);
            InsertedProps.Add(realEstateRoot);
            TreeProperty.Insert(lotRoot, GenerateKey(lotRoot));
            InsertedProps.Add(lotRoot);
        }

        public AppKey GenerateKey(Property prop)
        {
            AppKey key = new AppKey();
            key.X = "N".Equals(prop.GPSCoords[0].Latitude) ? prop.GPSCoords[0].LatitudeCoord : -prop.GPSCoords[0].LatitudeCoord;
            key.Y = "E".Equals(prop.GPSCoords[0].Longtitude) ? prop.GPSCoords[0].LongtitudeCoord : -prop.GPSCoords[0].LongtitudeCoord;
            InsertedKeys.Add(key);
            return key;
        }
        public bool FillTrees(int number, string type)
        {
            if (number < 1 || string.IsNullOrEmpty(type))
            {
                return false;
            }
            if (TreeRealEstate == null || TreeLot == null || TreeProperty == null)
            {
                CreateTrees();
            }
            bool inserted = false;
            bool isRealEstate = false;
            for (int i = 0; i < number; i++)
            {
                if ("Real Estate".Equals(type))
                {
                    isRealEstate = true;
                    inserted = Insert(isRealEstate);
                }
                else
                {
                    isRealEstate = false;
                    inserted = Insert(isRealEstate);
                }

                if (!inserted)
                {
                    return false;
                }
            }
            List<Node<AppKey, Property>> returned = TreeProperty.InOrder(TreeProperty.Root.Data, TreeProperty.Root.AppKey);
            Console.WriteLine("Inserted count: " + InsertedProps.Count);
            Console.WriteLine("Returned inOrder count: " + returned.Count);
            return true;
        }
        public bool Insert(bool isRealEstate)
        {
            Property prop;
            if (TreeRealEstate == null || TreeLot == null || TreeProperty == null)
            {
                return false;
            }
            if (isRealEstate)
            {
                prop = new RealEstate();
            }
            else
            {
                prop = new Lot();
            }
            prop.GPSCoords = new List<GPS>() { GPSGenerator.GetGPS(), GPSGenerator.GetGPS() };
            prop.Description = PropNameGenerator.GetPropertyName();
            prop.Number = PropNumberGenerator.GetPropertyNumber();
            prop.ID = UniqueIDGenerator.GetUniqueID();
            if (isRealEstate)
            {
                TreeRealEstate.Insert(prop, GenerateKey(prop));
            } else
            {
                TreeLot.Insert(prop, GenerateKey(prop));
            }

            Console.WriteLine("X coord: " + GenerateKey(prop).X);
            Console.WriteLine("Y coord: " + GenerateKey(prop).Y);
            return TreeProperty.Insert(prop, GenerateKey(prop));
        }

        public bool Insert(string type, Property prop)
        {
            if (string.IsNullOrEmpty(type) || prop == null)
            {
                return false;
            }
            prop.ID = UniqueIDGenerator.GetUniqueID();
            if ("Real Estate".Equals(type))
            {
                TreeRealEstate.Insert(prop, GenerateKey(prop));
            }
            else
            {
                TreeLot.Insert(prop, GenerateKey(prop));
            }
            Console.WriteLine("X coord " + GenerateKey(prop).X);
            Console.WriteLine("Y coord: " + GenerateKey(prop).Y);
            return TreeProperty.Insert(prop, GenerateKey(prop));
        }
        public List<Property> Find(string type, Property prop)
        {
            List<Property> props = new List<Property>();
            if (prop == null)
            {
                return new List<Property>();
            }
            switch (type)
            {
                case "Real Estate":
                    props.AddRange(TreeRealEstate.Find(prop, GenerateKey(prop)));
                    return props;
                case "Lot":
                    props.AddRange(TreeLot.Find(prop, GenerateKey(prop)));
                    return props;
                case "Property":
                    props.AddRange(TreeProperty.Find(prop, GenerateKey(prop)));
                    return props;
                default: return new List<Property>();
            }
        }

        public bool Delete(string type, Property prop)
        {
            bool removed = false;
            bool oneRemove = false;
            if (prop == null)
            {
                return false;
            }
            switch (type)
            {
                case "Real Estate":
                    removed = TreeRealEstate.Remove(prop, GenerateKey(prop));
                    oneRemove = TreeProperty.Remove(prop, GenerateKey(prop));
                    return removed;
                case "Lot":
                    removed = TreeLot.Remove(prop, GenerateKey(prop));
                    oneRemove = TreeProperty.Remove(prop, GenerateKey(prop));
                    return removed;
                case "Property":
                    removed = TreeProperty.Remove(prop, GenerateKey(prop));
                    if (prop is RealEstate)
                    {
                        oneRemove = TreeRealEstate.Remove(prop, GenerateKey(prop));
                    } else
                    {
                        oneRemove = TreeLot.Remove(prop, GenerateKey(prop));
                    }
                    if (oneRemove == false)
                    {

                    }
                    return removed;
                default: return false;
            }
        }
        public bool Update(Property newProp, Property oldProp)
        {
            bool changed = false;
            newProp.ID = oldProp.ID;
            if (oldProp == null || newProp == null)
            {
                return false;
            }
            if (oldProp is RealEstate)
            {
                changed = TreeRealEstate.Update(newProp, GenerateKey(newProp), oldProp, GenerateKey(oldProp));
            } else
            {
                changed = TreeLot.Update(newProp, GenerateKey(newProp), oldProp, GenerateKey(oldProp));
            }
            TreeProperty.Update(newProp, GenerateKey(newProp),oldProp, GenerateKey(oldProp));
            return changed;
        }
        public static GUIGenerator GetDataGenerator()
        {
            if (instance == null)
            {
                instance = new GUIGenerator();
            }
            return instance;
        }

        public bool SaveToFile()
        {
            return fileData.WriteToCsv(TreeProperty, filePath);
        }

        public bool LoadFromFile()
        {
            bool returned;
            returned = fileData.LoadFromCsv("../GUIAuS2/SavedData.csv");
            List<Node<AppKey, Property>> list = TreeProperty.InOrder(TreeProperty.Root.Data, TreeProperty.Root.AppKey);
            list.ForEach(node => Console.WriteLine("X: " + node.AppKey.X + "Y: " + node.AppKey.Y));
            list.Clear();
            return returned;
        }
    }
}
