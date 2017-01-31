using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker_ASS.ViewModel;
using EventMaker_ASS.Model;
using EventMaker_ASS.Converter;

namespace EventMaker_ASS.Handler
{
    public class EventHandler
    {
        public EventViewModel evm { get; set; }

        public Event NyEvent { get; set; }

        public EventHandler(EventViewModel evm)
        {
            this.evm = new EventViewModel();
        }

        //public object Events { get; private set; }

        public void CreateEvent()
        {
            Event tempEvent = new Event();
            tempEvent.Id = evm.Id;
            tempEvent.Name = evm.Name;
            tempEvent.Description = evm.Description;
            tempEvent.Place = evm.Place;

            tempEvent.DateTime = DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(evm.Date, evm.Time);

            EventCatalogSingleton.Instance.AddEvent(NyEvent);
        }
    }
}
