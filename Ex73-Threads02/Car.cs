using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex73_Threads02
{
    class Car
    {
        private string name;
        private string serial;
        public string Name { get => name; }
        public string Serial { get => serial; }

        public Car(string name, string serial)
        {
            this.name = name;
            this.serial = serial;
        }

        public override string ToString()
        {
            return name + " " + serial;
        }
    }
}