using System;
using LAB2.enums;

namespace LAB2.classes
{
    public class Vechile
    {
        public string Vin { get; set; }
        public Brand Brand { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public BodyType BodyType { get; set; }
        public CarColor Color { get; set; }
        public TechCondition TechCondition { get; set; }
        public DateTime RealeseDate { get; set; }
        public override string ToString()
        {
            return $"{Brand} {Model} {RealeseDate.Year}, {BodyType}";
        }
    }
}
