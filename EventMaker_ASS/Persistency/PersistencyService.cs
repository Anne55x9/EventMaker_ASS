using EventMaker_ASS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace EventMaker_ASS.Persistency
{
    class PersistencyService
    {
        // FileIO er en statisk klasse.
        /// <summary>
        /// Async and await til at lave et responsivt brugerflade design. 
        /// </summary>
        /// 
        StorageFolder localfolder = null;

        public EventCatalogSingleton EventsJson { get; set; }

        private readonly string filnavn = "EventMaker.json";

        public async void SaveDataToDiscAsync()
        {
            string JsonText = this.EventsJson.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(this.filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, JsonText);
        }

        /// <summary>
        /// Metoden inkluderer exceptionhåndtering med try/catch med message box (using Windows.UI.Popups). 
        /// Det går ud på at hvis der ikke er gemt en fil med listen i Json format så
        /// vises en besked box med titel og forklarende indhold til bruger. 
        /// </summary>

        public async void GetDataFromDiscAsync()
        {
            try
            {
                StorageFile file = await localfolder.GetFileAsync(filnavn);
                string jsonText = await FileIO.ReadTextAsync(file);

                this.CoffeeList.Clear();
                CoffeeList.InsertJson(jsonText);
            }
            catch (Exception)
            {
                MessageDialog NoData = new MessageDialog("No Data Found", "Error!");
                await NoData.ShowAsync();
            }
        }


        //public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        //{

        //}

        //public static async void SerializeEventsFilsAsync(string eventsString, string fileName)
        //{

        //}

        //public static async Task<string> DeserializeEventsFileAsync(String fileName)
        //{

        //}
    }
}
