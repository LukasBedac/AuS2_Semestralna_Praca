using Semestralna_Praca1;

namespace AuS2_WebApp.API
{
    public class GuiApi<T>
    {
        //TODO 1.3 Implement API
        public GuiApi()
        {
            Data = new DataGenAndTest();
        }
        public int UserSelectedId { get; set; }
        public DataGenAndTest Data { get; set; }

        public void Insert(int property, T data)
        {
            Property toInsert = property == 0 ? new RealEstate() : new Lot();
            
            //Data.Insert();
        }


        public void Update()
        {

        }

        public void Delete() 
        {
        
        }

        public void SendResults()
        {

        }
        public void GenerateData()
        {
           // Data.CreateTrees();
        }
        public void RunTest()
        {

        }
    }
}

