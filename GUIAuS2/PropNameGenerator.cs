using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUIAuS2
{
    public static class PropNameGenerator
    {
        private static List<string> adjectives = new List<string>
        {
            "Sunny", "Misty", "Whispering", "Golden", "Silver", "Tranquil", "Majestic", "Serene",
            "Peaceful", "Shady", "Enchanted", "Hidden", "Lush", "Quiet", "Cozy", "Verdant",
            "Breezy", "Dreamy", "Blissful", "Rustic", "Forested", "Velvet", "Emerald", "Gentle",
            "Radiant", "Wildflower", "Sapphire", "Azure", "Sapphire", "Starlit", "Timbered",
            "Velvet", "Open", "Moonlit", "Maple", "Cedar", "Oakwood", "Sunset", "Sunrise", "Valley",
            "Meadow", "Sunflower", "Willow", "Elm", "Crystal", "Highland", "Broadleaf", "Meadow",
            "Desert", "Amber", "Jade", "Fern", "Woodland", "Ivy", "Autumn", "Winter", "Spring",
            "Summer", "Dappled", "Violet", "Blushing", "Rolling", "Covered", "Towering", "Snowy",
            "Blooming", "Ever", "Soft", "Mellow", "Bright", "Starry", "Brisk", "Calming", "Gentle",
            "Quiet", "Peaceful", "Hidden", "Sheltered", "Open", "Fresh", "Cool", "Dappled", "Gleaming",
            "Serene", "Quiet", "Whispering", "Hidden", "Lush", "Broad", "Pristine", "Calm", "Wild",
            "Sparkling", "Still", "Radiant", "Majestic", "Quiet", "Flowing", "Meadowy"
        };

        private static List<string> nouns = new List<string>
        {
            "Oaks", "Valley", "Meadow", "Pines", "Cove", "Grove", "Hills", "Ridge", "Lake", "River",
            "Forest", "Bay", "Field", "Glen", "Park", "Waters", "Creek", "Falls", "Springs", "Bayou",
            "Bluff", "Shore", "Isle", "Point", "Wood", "Field", "Lake", "River", "Valley", "Hill",
            "Ridge", "Basin", "Cliff", "Pond", "Meadow", "Lakeview", "Stream", "Woodland", "Riverbank",
            "Garden", "Arbor", "Cliffside", "Path", "Vale", "Prairie", "Bluff", "Desert", "Lagoon",
            "Cove", "Bay", "Hollow", "Knoll", "Beach", "Retreat", "Grove", "Haven", "Vista", "Shire",
            "Oasis", "Lookout", "Passage", "Landing", "Preserve", "Forest", "Arbor", "Estate",
            "Acreage", "Waters", "Bridge", "Terraces", "Marsh", "Glade", "Summit", "Rock", "Beachside",
            "Plains", "Dunes", "Harbour", "Timber", "Acres", "View", "Mountain", "Parkland", "Woods",
            "Sanctuary", "Preserve", "Pathway", "Summit", "Bluff", "Palms", "Valleyview", "Dales",
            "Hallow", "Orchards", "Overlook", "Crest", "Reserve", "Pier", "Rapids", "Slopes"
        };

        private static List<string> suffixes = new List<string>
        {
            "Estates", "Manor", "Acres", "Retreat", "Ridge", "Cove", "Hollow", "Grove", "Place",
            "Terrace", "View", "Meadows", "Crossing", "Garden", "Woods", "Preserve", "Point", "Shores",
            "Park", "Hills", "Peaks", "Heights", "Overlook", "Plaza", "Glade", "Corner", "Beach",
            "Landing", "Bay", "Plains", "Ridge", "Pines", "Falls", "Glen", "Knoll", "Isle", "Retreat",
            "Summit", "Marsh", "Harbour", "Oasis", "Shire", "Crossing", "Shores", "Crescent", "Reserve",
            "Harbor", "Gateway", "Cape", "Bridge", "Peak", "Domain", "Fields", "Plateau", "Vale",
            "Glens", "Bayou", "Terrace", "Creek", "Run", "Bend", "Walk", "Nook", "Meadowlands",
            "Reserve", "Arch", "Arcadia", "Domain", "Parkway", "Cross", "Courts", "Plaza", "Lake",
            "Forest", "Vale", "Terrace", "Trails", "Dales", "Enclave", "Lane", "Knoll", "Meadow",
            "Lanes", "Oasis", "Glade", "Manor", "Ponds", "Gateway", "Path", "Crossing", "Grove",
            "Field", "Island", "Preserve", "Flats", "Garden", "Bluffs", "Meadows", "Crossroads", "Crest"
        };

        public static string GetPropertyName()
        {
            Random random = new Random();            
            string name = $"{adjectives[random.Next(adjectives.Count)]} " +
                          $"{nouns[random.Next(nouns.Count)]} " +
                          $"{suffixes[random.Next(suffixes.Count)]}";
            return name;
        }
    }
}
