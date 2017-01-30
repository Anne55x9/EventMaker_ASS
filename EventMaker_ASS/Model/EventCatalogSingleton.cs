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
        private static EventCatalogSingleton instance;

        //Tom konstruktor
      
            public static EventCatalogSingleton Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new EventCatalogSingleton();
                }
                return instance;
            }
        }

        public ObservableCollection<Event> Events { get; set; }

        public Model.Event NewEvent { get; set; }

        private EventCatalogSingleton()
        {
            NewEvent = new Model.Event();
           
            Events = new ObservableCollection<Event>();

        }

        public void AddEvent()
        {
            Event tempEvent = new Model.Event();
            tempEvent.Id = NewEvent.Id;
            tempEvent.Name = NewEvent.Name;
            tempEvent.Description = NewEvent.Description;
            tempEvent.Place = NewEvent.Place;
            tempEvent.DateTime = NewEvent.DateTime;
            
            Events.Add(tempEvent);
  
            //Skal kunne addere en EVent til collectionen.
        }
    }

}
