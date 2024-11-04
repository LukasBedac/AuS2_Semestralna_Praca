using AuS2_WebApp.API;
using Semestralna_Praca1;
namespace AuS2_WebApp.Pages
{
    public partial class Sem1
    {        
        public Property Property { get; set; } = new RealEstate(); //This is only for form 
        private readonly string[] latitudeSelect = { "N", "S" };
        private readonly string[] longtitudeSelect = { "E", "W" };
        private readonly string[] propertyType = {"Lot","Real Estate"};
        private RealEstate RealEstate { get; set; }
        private Lot Lot { get; set; }
        public string PropertyTypeSelect { get; set; }
        public string? LatSelect { get; set; }
        public double LatDouble { get; set; }
        public string? LongSelect { get; set; }
        public double LongDouble { get; set; }
        public string? LatSelect2 { get; set; }
        public double LatDouble2 { get; set; }
        public string? LongSelect2 { get; set; }
        public double LongDouble2 { get; set; }


        public int PropNumber { get; set; }
        public string PropName { get; set; }
        public string PropDescription { get; set; }
        
        private GuiApi<Property> api = new GuiApi<Property>();

        //TODO 1.4 Finish GUI and its methods
        public void FindLot()
        {

            api.SendResults();
        }
        public void FindRealEstate()
        {

        }

        public void FindProperty()
        {

        }

        public void AddRealEstate()
        {

        }
        public void AddLot()
        {

        }
        public void DeleteRealEstate()
        {

        }
        public void DeleteLot()
        {

        }
        public void EditRealEstate()
        {

        }
        public void EditLot()
        {

        }

        public void GenerateFormData() 
        {
            if("Real Estate".Equals(PropertyTypeSelect))
            {
                Property = new RealEstate();
            } else
            {
                Property = new Lot();
            }
            GPS gps1 = new GPS();
            GPS gps2 = new GPS();

            gps1.Latitude = LatSelect;
            gps1.LatitudeCoord = LatDouble;

            gps2.Longtitude = LongSelect;
            gps2.LongtitudeCoord = LongDouble;

            Property.GPSCoords.Add(gps1);
            Property.GPSCoords.Add(gps2);

            Property.Description = PropDescription;
            Property.Number = PropNumber;
        }
    }
}
