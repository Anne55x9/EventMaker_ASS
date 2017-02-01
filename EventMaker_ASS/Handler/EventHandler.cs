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
        private EventViewModel Evm { get; set; }

        public EventHandler(EventViewModel evm)
        {
            this.Evm = evm;
        }

        public void CreateEvent()
        {
            Event tempEvent = new Event(Evm.Id,Evm.Name,Evm.Description,Evm.Place);
            tempEvent.Id = Evm.Id;
            tempEvent.Name = Evm.Name;
            tempEvent.Description = Evm.Description;
            tempEvent.Place = Evm.Place;

            tempEvent.DateTime = DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(Evm.Date, Evm.Time);

            EventCatalogSingleton.Instance.AddEvent(tempEvent);
        }
    }
}
