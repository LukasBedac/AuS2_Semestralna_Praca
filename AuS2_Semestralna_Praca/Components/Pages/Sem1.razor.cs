using AuS2_Semestralna_Praca.API;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazor.Interfaces;
using Semestralna_Praca1;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;


namespace AuS2_Semestralna_Praca.Components.Pages
{
    public partial class Sem1
    {
        private string gpsCoordinates;
        public Property Property { get; set; } = new RealEstate(1);
        public bool ShowFieldsBool { get; set; } = false;
        public int MethodId { get; set; }

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

        public async Task ShowFields()
        {
            ShowFieldsBool = !ShowFieldsBool;
            
        }
    }
}
