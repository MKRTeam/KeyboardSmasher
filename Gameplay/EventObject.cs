using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay
{
    public class EventObject
    {
       public string Name { get; set; }
       public string Description { get; set; }

        public Event[] Events { get; }
        private static Random random = new Random();

        public EventObject(string name, string description, Event[] events)
        {
            if (name == "" || description == "")
            {
                throw new Exception("Имя или описание не задано(24 строка, EventObject.cs)");
            }
            Name = name;
            Description = description;
            this.Events = events;
        }

        public Event getRandomEvent()
        {
            return Events[random.Next(0, Events.Length)];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
