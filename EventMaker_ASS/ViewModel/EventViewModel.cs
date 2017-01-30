using EventMaker_ASS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaker_ASS.ViewModel
{
    public class EventViewModel
    {
       private EventCatalogSingleton SingleEvent { get; set; }


        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }

        
        //public DateTime DateTime { get; set; }

    }
}
