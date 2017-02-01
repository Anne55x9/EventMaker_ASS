using EventMaker_ASS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using EventMaker_ASS.Model;
using Windows.UI.Popups;
using Newtonsoft.Json;

namespace EventMaker_ASS.Persistency
{
    class PersistencyService
    {
        // FileIO er en statisk klasse.
        /// <summary>
        /// Async and await til at lave et responsivt brugerflade design. 
        /// </summary>
        /// 

        const string fileName = "EventMaker.json";


        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            string JsonData = JsonConvert.SerializeObject(EventCatalogSingleton.Instance.Events);
            await FileIO.WriteTextAsync(localFile, JsonData); 

        }

        public static async Task<ObservableCollection<Event>> LoadEventsFromJsonAsync()
        {
            StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
            String jsonData = await FileIO.ReadTextAsync(localFile);
            return JsonConvert.DeserializeObject<ObservableCollection<Event>>(jsonData);
        }

        //public static async void SerializeEventsFilsAsync(string eventsString, string fileName)
        //{

        //}

        //public static async Task<string> DeserializeEventsFileAsync(String fileName)
        //{

        //}

 
    }
}
