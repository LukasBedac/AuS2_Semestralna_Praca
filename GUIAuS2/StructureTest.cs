using Semestralna_Praca1;
using GUIAuS2;
namespace Semestralna_Praca1
{
    public class StructureTest
    {
        private DataGenerator DataGenerator { get; set; }
        private Random rand = new Random();

        public StructureTest(int duplicatesChance) 
        {
            DataGenerator = DataGenerator.GetDataGenerator();
        }

        public void TestRandomMethods()
        {
            KDTree<TestKey, Property> tree;
            for (int i = 0; i < 100; i++)
            {
                double chance = rand.NextDouble();
                double treeChance = rand.NextDouble();
                bool isRealEstate = false;
                bool inserted = false;
                List<Property> found = new List<Property>();
                if (treeChance <= 0.5)
                {
                    tree = DataGenerator.TreeRealEstate;
                }
                else
                {
                    tree = DataGenerator.TreeLot;
                }
                if (chance <= 0.33)
                {
                    
                    if (treeChance <= 0.5)
                    {
                        isRealEstate = true;
                        DataGenerator.Insert(tree, isRealEstate);
                    }
                    else
                    {
                        isRealEstate = false;
                        DataGenerator.Insert(tree, isRealEstate);
                    }
                    inserted = DataGenerator.Insert(DataGenerator.TreeProperty, isRealEstate);
                    Console.WriteLine("Inserted: " + inserted);
                }
                else if (chance <= 0.66)
                {
                    int index = rand.Next(DataGenerator.NUMBEROFPROPERTIES);
                    Property prop = DataGenerator.InsertedProps[index];
                    TestKey key = DataGenerator.InsertedKeys[index];
                    if (prop is RealEstate)
                    {
                        found.AddRange(Find(DataGenerator.TreeRealEstate, prop, key));
                    }
                    else
                    {
                        found.AddRange(Find(DataGenerator.TreeLot, prop, key));
                    }
                    Find(tree, prop, key);
                    if (found != null)
                    {
                        foreach (Property p in found)
                        {
                            if (found[0].Equals(p))
                            {
                                Console.WriteLine("Node Found: " + prop.ToString());
                            } else
                            {
                                Console.WriteLine("Duplicate Found: " + prop.ToString());
                            }
                            
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Not Found: " + prop.ToString());
                    }

                }
                else
                {
                    int find = rand.Next(DataGenerator.InsertedProps.Count);
                    Property prop = DataGenerator.InsertedProps[find];                    
                    TestKey key = DataGenerator.InsertedKeys[find];
                    bool oneTreeBool;
                    if (prop is RealEstate)
                    {
                        prop = (RealEstate)prop;
                        oneTreeBool = DataGenerator.TreeRealEstate.Remove(prop, key);
                    }
                    else
                    {
                        prop = (Lot)prop;
                        oneTreeBool = DataGenerator.TreeLot.Remove(prop, key);
                    }
                    bool allBool = DataGenerator.TreeProperty.Remove(prop, key);
                    //Test why the prop did not remove
                    /*if (allBool == false && oneTreeBool == false)
                    {
                        allBool = DataGenerator.TreeProperty.Remove(prop, key);
                    }*/


                    Console.WriteLine("Deleted property: " + prop.ToString());
                    Console.WriteLine("Deleted in tree: " + oneTreeBool + " and in allTree: " + allBool);
                    DataGenerator.InsertedProps.Remove(prop);
                    DataGenerator.InsertedKeys.Remove(key);
                }                
            }
            Console.WriteLine("Inserted properties count after test: " + DataGenerator.InsertedProps.Count);
            Console.WriteLine("Inserted properties count after test with InOrder: " + 
                DataGenerator.TreeProperty.InOrder(DataGenerator.TreeProperty.Root.Data, DataGenerator.TreeProperty.Root.AppKey).Count);
        }
        public void Insert()
        {

        }
        public List<Property> Find(KDTree<TestKey, Property> tree,Property prop, TestKey key)
        {
            return tree.Find(prop, key);
        }
        public void Delete(KDTree<TestKey, Lot> tree, TestKey key)
        {
            //tree.Remove((Lot)deleteProp, key);
        }
        public void GenerateData()
        {


        }
    }
}