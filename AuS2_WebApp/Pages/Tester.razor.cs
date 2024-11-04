using AuS2_WebApp.API;
using Semestralna_Praca1;
namespace AuS2_WebApp.Pages
{
    public partial class Tester
    {
        private GuiApi<Property> api = new GuiApi<Property>();
        public Property Property { get; set; } = new Lot();

        public void GenerateData()
        {
            api.GenerateData();    
        }
        public void RunTest() 
        {
            api.RunTest();
        }
    }
}
