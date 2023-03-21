using LAB1.classes;
using System.Collections.Generic;

namespace LAB1
{
    class VehicleXRegistration
    {
        public Vechile Vechile { get; set; }
        public IEnumerable<VehicleRegistration> VehicleRegistrations { get; set; }
    }
    class OwnerXRegistrations
    {
        public Owner Owner { get; set; }
        public IEnumerable<VehicleRegistration> VehicleRegistrations { get; set; }
    }
}
