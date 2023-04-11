using System;
using System.Xml.Serialization;

namespace LAB2.classes
{
    public abstract class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public string Adress { get; set; }
        public DateTime BirthDate { get; set; }
        public string DriverLicense { get; set; }
    }
}
