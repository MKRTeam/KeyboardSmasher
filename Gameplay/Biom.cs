using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameplay
{
    public class Biom
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public EventObject[] Objects { get; }
        private static Random random = new Random();

        public Biom(string name, string description, EventObject[] objects)
        {
            if (name == "")
            {
               throw new Exception("Имя биома или описание не задано(24 строка, Biom.cs)");
            }
            this.Name = name;
            this.Description = description;
            this.Objects = objects;
        }

        public EventObject getRandomEventObject()
        {
            return Objects[random.Next(0, Objects.Length)];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
