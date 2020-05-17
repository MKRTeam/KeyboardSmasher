using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardSmasher.Gameplay
{
    class _Exception : Exception
    {
        public _Exception(string message)
            : base(message)
        { }
    }
    class Biom
    {
        public string Name { get; }
        public string Description { get; }

        public Biom(string name, string description)
        {
            if (name != "" || description != "")
            {
               new _Exception("Имя биома или описание не задано(24 строка, Biom.cs)");
                return;
            }
            this.Name = name;

            this.Description = description;
        }


    }
}
