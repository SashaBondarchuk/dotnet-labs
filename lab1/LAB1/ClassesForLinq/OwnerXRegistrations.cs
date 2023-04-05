using LAB1.classes;
using System.Collections.Generic;


namespace LAB1.ClassesForLinq
{
    class OwnerXRegistrations
    {
        public Owner Owner { get; set; }
        public IEnumerable<VehicleRegistration> VehicleRegistrations { get; set; }
    }
}
