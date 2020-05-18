using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay
{
    class _Exception : Exception
    {
        public _Exception(string message)
            : base(message)
        { }
    }
    public class Biom
    {
        public string Name { get; }
        public string Description { get; }

        private EventObject[] objects;
        private static Random random = new Random();

        public Biom(string name, string description, EventObject[] objects)
        {
            if (name != "" || description != "")
            {
               new _Exception("Имя биома или описание не задано(24 строка, Biom.cs)");
                return;
            }
            this.Name = name;
            this.Description = description;
            this.objects = objects;
        }

        public EventObject getRandomEventObject()
        {
            return objects[random.Next(0, objects.Length)];
        }
    }
}
