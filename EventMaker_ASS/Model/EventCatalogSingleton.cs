using EventMaker_ASS.Persistency;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EventMaker_ASS.Model
{
    public class EventCatalogSingleton         
    {
        private static EventCatalogSingleton _instance;

        //Tom konstruktor

        public static EventCatalogSingleton Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new EventCatalogSingleton();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Prop af Events
        /// </summary>
        /// 
        public ObservableCollection<Event> Events { get; set; }

        private EventCatalogSingleton()
        {
            Events = new ObservableCollection<Event>();
            //if (ObservableCollection<Event> > 0)
            //{
            LoadJson();
            //}
        }

        public void AddEvent(Event NyEvent)
        {
            Events.Add(NyEvent);
            PersistencyService.SaveEventsAsJsonAsync();

            //Skal kunne addere en Event til collectionen.
        }

        public void RemoveEvent(Event deleteEvent)
        {
            Events.Remove(deleteEvent);
            PersistencyService.SaveEventsAsJsonAsync();
        }

        public async void LoadJson()
        {
            try
            {
                Events = await PersistencyService.LoadEventsFromJsonAsync();
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.Write($"Exception: { e }");
            }
            
            ////if (Event > 0)
            ////{
            //    Events = await PersistencyService.LoadEventsFromJsonAsync();
            ////}

        }


    }

}
