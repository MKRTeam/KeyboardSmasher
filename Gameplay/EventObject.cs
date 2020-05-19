using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay
{
    public class EventObject
    {
        string Name { get; }
        string Description { get; }

        private Event[] events;
        private static Random random = new Random();

        public EventObject(string name, string description, Event[] events)
        {
            if (name == "" || description == "")
            {
                throw new Exception("Имя или описание не задано(24 строка, EventObject.cs)");
            }
            Name = name;
            Description = description;
            this.events = events;
        }

        public Event getRandomEvent()
        {
            return events[random.Next(0, events.Length)];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
