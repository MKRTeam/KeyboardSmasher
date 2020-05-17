using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardSmasher.Gameplay
{
    class EventObject
    {
        private Biom Biom { get; }
        string Name { get; }
        string Description { get; }

        public EventObject(string name, string description, Biom biom)
        {
            if (name != "" || description != "" || biom !=null)
            {
                new _Exception("Имя или описание не задано(24 строка, EventObject.cs)");
                return;
            }
            Biom = biom;
            Name = name;
            Description = description;
        }
    }
}
