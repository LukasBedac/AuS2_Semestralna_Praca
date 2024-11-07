using GUIAuS2;
using Semestralna_Praca1;
using System.Collections.ObjectModel;

namespace AuS2_WebApp.API
{
    public class GuiApi<T>
    {
        //TODO 1.3 Implement API
        public GuiApi()
        {

        }
        public int UserSelectedId { get; set; }
        private GUIGenerator Data { get; set; } = GUIGenerator.GetDataGenerator();

        public bool Insert(string property, T data)
        {
           return Data.Insert(property, (Property)data);                     
        }


        public bool Update(T newData, T oldData)
        {
            return Data.Update((Property)newData, (Property)oldData);
        }
        public List<Property> Find(string type, T data)
        {
            List<Property> list = Data.Find(type, (Property)data);
            return list;
        }
        public bool Delete(string type, Property prop)
        {
            return Data.Delete(type, prop);
        }

        public void SendResults()
        {

        }
        public bool GenerateData(int number, string type)
        {
           return Data.FillTrees(number, type);           
        }

        public bool SaveToFile()
        {
            return Data.SaveToFile();
        }
        public bool LoadFromFile()
        {
            return Data.LoadFromFile();
        }
    }
}

