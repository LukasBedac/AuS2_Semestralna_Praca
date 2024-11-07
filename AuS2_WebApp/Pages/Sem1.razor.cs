using AuS2_WebApp.API;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Semestralna_Praca1;
using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using static MudBlazor.CategoryTypes;

namespace AuS2_WebApp.Pages
{
    public partial class Sem1
    {
        public Property Property { get; set; } = new RealEstate(); //This is only for form 
        private readonly string[] latitudeSelect = { "N", "S" };
        private readonly string[] longtitudeSelect = { "E", "W" };
        private readonly string[] propertyType = { "Lot", "Real Estate", "Property" };
        private RealEstate RealEstate { get; set; }
        private Lot Lot { get; set; }
        public string PropertyTypeGeneration { get; set; }
        public int NumberOfProperties { get; set; }
        [Required]
        public string PropertyTypeSelect { get; set; }
        public string? LatSelect { get; set; }
        public double LatDouble { get; set; }
        public string? LongSelect { get; set; }
        public double LongDouble { get; set; }
        public string? LatSelect2 { get; set; }
        public double LatDouble2 { get; set; }
        public string? LongSelect2 { get; set; }
        public double LongDouble2 { get; set; }

        private List<Property> returnList { get; set; } = new List<Property>();
        private string propertType = "";
        public int PropNumber { get; set; }
        public string PropName { get; set; }
        public string PropDescription { get; set; }

        private Property? SelectedProperty;
        private int selectedRow = -1;
        private List<string> clickedEvents = new List<string>();
        private MudTable<Property> mudTable;

        private GuiApi<Property> api = new GuiApi<Property>();

        //TODO 1.4 Finish GUI and its methods
        public void FindLot()
        {
            returnList.Clear();
            GenerateFormData();
            returnList.AddRange(api.Find("Lot", Property));
            GetType(returnList);
        }
        public void FindRealEstate()
        {
            returnList.Clear();
            GenerateFormData();
            returnList.AddRange(api.Find("Real Estate", Property));
            GetType(returnList);
        }

        public void FindProperty()
        {
            returnList.Clear();
            GenerateFormData();
            returnList.AddRange(api.Find("Property", Property));
            GetType(returnList);
        }

        public void AddProperty()
        {
            returnList.Clear();
            GenerateFormData();
            bool inserted = api.Insert(PropertyTypeSelect, Property);
            if (inserted)
            {
                SnackbarService.Add("Data was inserted", Severity.Success);
            }
            else
            {
                SnackbarService.Add("Data was not inserted", Severity.Error);
            }
        }
        public async Task DeleteProperty()
        {
            returnList.Clear();
            GenerateFormData();
            returnList.AddRange(api.Find(PropertyTypeSelect, Property));
            GetType(returnList);
            SelectedProperty = null;
            _selectionCompletionSource = new TaskCompletionSource<Property>();
            SelectedProperty = await _selectionCompletionSource.Task;
            bool removed = api.Delete(PropertyTypeSelect, SelectedProperty);
            if (removed)
            {
                SnackbarService.Add("Property was removed", Severity.Success);
                returnList.Clear();                
            } else
            {
                SnackbarService.Add("Property was not removed", Severity.Error);
            }
            SelectedProperty = null;
            _selectionCompletionSource = null;
        }
        public async Task EditProperty()
        {
            returnList.Clear();
            GenerateFormData();
            bool updated = api.Update(Property, SelectedProperty);
            if (updated)
            {
                SnackbarService.Add("Property was updated", Severity.Success);
                returnList.Clear();
            }
            else
            {
                SnackbarService.Add("Property was not updated", Severity.Error);
            }
        }

        public void SaveToFile()
        {
            bool saved = api.SaveToFile();
            if (saved)
            {
                SnackbarService.Add("Data was inserted", Severity.Success);
            }
            else
            {
                SnackbarService.Add("Data was not inserted", Severity.Error);
            }
        }
        public void LoadFromFile()
        {
            bool loaded = api.LoadFromFile();
            if (loaded)
            {
                SnackbarService.Add("Data was inserted", Severity.Success);
            }
            else
            {
                SnackbarService.Add("Data was not inserted", Severity.Error);
            }
        }

        public void GenerateData()
        {
            bool inserted = api.GenerateData(NumberOfProperties, PropertyTypeGeneration);
            if (inserted)
            {
                SnackbarService.Add("Data was inserted", Severity.Success);
            }
            else
            {
                SnackbarService.Add("Data was not inserted", Severity.Error);
            }
            
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
            gps1.Longtitude = LongSelect;
            gps1.LongtitudeCoord = LongDouble;
            gps2.Latitude = LatSelect2;
            gps2.LatitudeCoord = LatDouble2;
            gps2.Longtitude = LongSelect2;
            gps2.LongtitudeCoord = LongDouble2;

            Property.GPSCoords.Add(gps1);
            Property.GPSCoords.Add(gps2);

            Property.Description = PropDescription;
            Property.Number = PropNumber;
        }

        public void Reset()
        {
            LatSelect = default; 
            LatSelect2 = default;
            LongSelect = default;
            LongSelect2 = default;
            LatDouble = default; 
            LatDouble2 = default;
            LongDouble = default;
            LongDouble2 = default;
            PropDescription = string.Empty;
            PropNumber = default;
            PropertyTypeGeneration = default;
            PropertyTypeSelect = default;
            propertType = "";
            returnList.Clear();
        }

        private void OnRowClicked(TableRowClickEventArgs<Property> args)
        {
            SelectedProperty = args.Item;
            if (_selectionCompletionSource != null)
            {
                _selectionCompletionSource.SetResult(SelectedProperty);
            }
            if (SelectedProperty == null)
            {
                return;
            }
            LatSelect = SelectedProperty.GPSCoords[0].Latitude;
            LatSelect2 = SelectedProperty.GPSCoords[1].Latitude;
            LongSelect = SelectedProperty.GPSCoords[0].Longtitude;
            LongSelect2 = SelectedProperty.GPSCoords[1].Longtitude;
            LatDouble = SelectedProperty.GPSCoords[0].LatitudeCoord;
            LatDouble2 = SelectedProperty.GPSCoords[1].LatitudeCoord;
            LongDouble = SelectedProperty.GPSCoords[0].LongtitudeCoord;
            LongDouble2 = SelectedProperty.GPSCoords[1].LongtitudeCoord;
            PropDescription = SelectedProperty.Description;
            PropNumber = SelectedProperty.Number;
        }
        private string SelectedRow(Property prop, int rowNumber)
        {
            if (selectedRow == rowNumber)
            {
                selectedRow = -1;
                clickedEvents.Add("Selected Row: None");
                return string.Empty;
            }
            else if (mudTable.SelectedItem != null && mudTable.SelectedItem.Equals(Property))
            {
                selectedRow = rowNumber;
                clickedEvents.Add($"Selected Row: {rowNumber}");
                return "selected";
            }
            else
            {
                return string.Empty;
            }
        }

        public void GetType(List<Property> props)
        {
            int propType1 = 0;
            int propType2 = 0;
            foreach (Property prop in props)
            {
                if (prop is RealEstate)
                {
                    propType1++;
                } else
                {
                    propType2++;
                }
            }
            if (props.Count == propType1)
            {
                propertType = "Real Estate";
            } else if (props.Count == propType2) 
            {
                propertType = "Lot";
            } else
            {
                propertType = "error";
            }
        }

        private TaskCompletionSource<Property> _selectionCompletionSource;

    }
}
