using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay
{
    public class EventObject
    {
        private Biom Biom { get; }
        string Name { get; }
        string Description { get; }

        private Event[] events;
        private static Random random = new Random();

        public EventObject(string name, string description, Biom biom, Event[] events)
        {
            if (name != "" || description != "" || biom !=null)
            {
                new _Exception("Имя или описание не задано(24 строка, EventObject.cs)");
                return;
            }
            Biom = biom;
            Name = name;
            Description = description;
            this.events = events;
        }

        public Event getRandomEvent()
        {
            return events[random.Next(0, events.Length)];
        }
    }
}
