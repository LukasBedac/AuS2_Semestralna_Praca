using AuS2_WebApp.API;
using Semestralna_Praca1;
namespace AuS2_WebApp.Pages
{
    public partial class Sem1
    {
        private string gpsCoordinates;
        public Property Property { get; set; } = new Lot(0);
        private string[] latitudeSelect = { "N", "S" };
        private string[] longtitudeSelect = { "E", "W" };
        public string LatSelect { get; set; }
        public string LongSelect { get; set; }
        public string LatSelect2 { get; set; }
        public string LongSelect2 { get; set; }
        private GuiApi api = new GuiApi();

        //TODO 1.4 Finish GUI and its methods
        public void FindLot()
        {

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
    }
}
