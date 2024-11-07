using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUIAuS2;
using Semestralna_Praca1;

namespace Semestralna_Praca1
{
    public class FileData
    {        
        public bool WriteToCsv(KDTree<AppKey, Property> tree, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the header                    
                    writer.WriteLine("Type, Number, Description, Latitude, LatitudeCoord, Longtitude, LongtitudeCoord, Latitude2, LatitudeCoord2, Longtitude2, LongtitudeCoord2");
                    if (tree.Root == null)
                    {
                        return false;
                    }

                    // Level-order traversal using a queue
                    Queue<Node<AppKey, Property>> queue = new Queue<Node<AppKey, Property>>();
                    queue.Enqueue(tree.Root);

                    while (queue.Count > 0)
                    {
                        Node<AppKey, Property> currentNode = queue.Dequeue();
                        Property property = currentNode.Data;
                        bool isRealEstate;
                        isRealEstate = property is RealEstate;
                        // Write data to the CSV
                        if (isRealEstate) { 
                            writer.WriteLine($"{"Real Estate"}; {property.Number}; {property.Description}; {property.GPSCoords[0].Latitude}; {property.GPSCoords[0].LatitudeCoord}; {property.GPSCoords[0].Longtitude}; {property.GPSCoords[0].LongtitudeCoord}; {property.GPSCoords[1].Latitude}; {property.GPSCoords[1].LatitudeCoord}; {property.GPSCoords[1].Longtitude};{property.GPSCoords[1].LongtitudeCoord} ");
                        }
                        else
                        {
                            writer.WriteLine($"{"Lot"};{property.Number}; {property.Description}; {property.GPSCoords[0].Latitude}; {property.GPSCoords[0].LatitudeCoord}; {property.GPSCoords[0].Longtitude}; {property.GPSCoords[0].LongtitudeCoord}; {property.GPSCoords[1].Latitude}; {property.GPSCoords[1].LatitudeCoord}; {property.GPSCoords[1].Longtitude};{property.GPSCoords[1].LongtitudeCoord} ");
                        }
                        // Enqueue left and right children
                        if (currentNode.Left != null)
                        {
                            queue.Enqueue(currentNode.Left);
                        }

                        if (currentNode.Right != null)
                        {
                            queue.Enqueue(currentNode.Right);
                        }
                    }

                    Console.WriteLine($"Data was written to: {filePath}");
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine($"Error occurred while writing to the file: {e.Message}");
                return false;
            }
            return true;
        }

        public bool LoadFromCsv(string filePath)
        {
            GUIGenerator GUIGenerator = GUIGenerator.GetDataGenerator();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line = reader.ReadLine(); // Skip the header line

                    while ((line = reader.ReadLine()) != null)
                    {
                        Property property;
                        string[] values = line.Split(';');

                        if ("Real Estate".Equals(values[0]))
                        {
                            property = new RealEstate();
                        } else
                        {
                            property = new Lot();
                        }

                        // Parse property data based on expected column order
                        int number = int.Parse(values[1]);
                        string description = values[2].Trim();

                        string latitude1 = values[3].Trim();
                        double latitudeCoord1 = double.Parse(values[4]);
                        string longitude1 = values[5].Trim();
                        double longitudeCoord1 = double.Parse(values[6]);

                        string latitude2 = values[7].Trim();
                        double latitudeCoord2 = double.Parse(values[8]);
                        string longitude2 = values[9].Trim();
                        double longitudeCoord2 = double.Parse(values[10]);

                        // Create GPS coordinates for boundaries
                        GPS gps1 = new GPS();
                        gps1.Latitude = latitude1;
                        gps1.LatitudeCoord = latitudeCoord1;
                        gps1.Longtitude = longitude1;
                        gps1.LongtitudeCoord = longitudeCoord1;
                        GPS gps2 = new GPS();
                        gps2.Latitude = latitude1;
                        gps2.LatitudeCoord = latitudeCoord1;
                        gps2.Longtitude = longitude1;
                        gps2.LongtitudeCoord = longitudeCoord1;

                        // Create the Property object
                        property.ID = UniqueIDGenerator.GetUniqueID();
                        property.Number = number;
                        property.Description = description;
                        property.GPSCoords.Add(gps1);
                        property.GPSCoords.Add(gps2);

                        // Create a Node or appropriate key (assuming AppKey creation is based on Property or GPS)
                        AppKey key = new AppKey();  // Adjust if AppKey is created differently
                        key.X = "N".Equals(property.GPSCoords[0].Latitude) ? property.GPSCoords[0].LatitudeCoord : -property.GPSCoords[0].LatitudeCoord;
                        key.Y = "E".Equals(property.GPSCoords[0].Longtitude) ? property.GPSCoords[0].LongtitudeCoord : -property.GPSCoords[0].LongtitudeCoord;

                        // Insert the node into the KDTree
                        if (property is RealEstate)
                        {
                            if (GUIGenerator.TreeRealEstate == null)
                            {
                                GUIGenerator.TreeRealEstate = new KDTree<AppKey, Property>(key, property, 2);
                            }
                            else
                            {
                                GUIGenerator.TreeRealEstate.Insert(property, key);
                            }                            
                            
                        }
                        else
                        {
                            if (GUIGenerator.TreeLot == null)
                            {
                                GUIGenerator.TreeLot = new KDTree<AppKey, Property>(key, property, 2);
                            } else
                            {
                                GUIGenerator.TreeLot.Insert(property, key);
                            }
                        }                        
                        if (GUIGenerator.TreeProperty == null)
                        {
                            GUIGenerator.TreeProperty = new KDTree<AppKey, Property>(key, property, 2);
                        }
                        GUIGenerator.TreeProperty.Insert(property, key);
                    }
                }

                Console.WriteLine("Data was loaded from: " + filePath);
            }
            catch (IOException e)
            {
                Console.Error.WriteLine($"Error reading file: {e.Message}");
                return false;
            }
            catch (FormatException e)
            {
                Console.Error.WriteLine($"Data format error: {e.Message}");
                return false;
            }
            return true;
        }
    }

    

}
