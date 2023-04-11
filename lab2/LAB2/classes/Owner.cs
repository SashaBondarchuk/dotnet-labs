using System;
using System.Xml.Serialization;

namespace LAB2.classes
{
    public class Owner : Driver
    {
        public override string ToString()
        {
            return $"Власник: Id: {Id}, {Surname}";
        }
    }
}
