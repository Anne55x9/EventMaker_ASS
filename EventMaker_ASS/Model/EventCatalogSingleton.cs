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
            
        }

        public void AddEvent(Event NyEvent)
        {
            Events.Add(NyEvent);

            //Skal kunne addere en Event til collectionen.
        }

        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

        public void InsertJson(string jsonText)
        {
            ObservableCollection<Event> nyListe = JsonConvert.DeserializeObject<ObservableCollection<Event>>(jsonText);
            foreach (var Event in nyListe)
            {
                nyListe.Add(Event);
            }
        }
    }

}
