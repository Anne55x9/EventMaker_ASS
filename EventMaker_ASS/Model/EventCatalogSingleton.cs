using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EventMaker_ASS.Model
{
    class EventCatalogSingleton         
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

        public ObservableCollection<Event> Events { get; set; }

        //public Model.Event NewEvent { get; set; }

        private EventCatalogSingleton()
        {
            //NewEvent = new Model.Event();
           
            Events = new ObservableCollection<Event>();
        }

        public void AddEvent(Event NyEvent)
        {
            Events.Add(NyEvent);

  
            //Skal kunne addere en Event til collectionen.
        }
    }

}
