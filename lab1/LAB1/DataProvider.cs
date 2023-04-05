using LAB1.classes;
using System.Collections.Generic;

namespace LAB1
{
    class DataProvider : IDataProvider
    {
        public IEnumerable<Vechile> Vechiles { get; set; }
        public IEnumerable<Owner> Owners { get; set; }
        public IEnumerable<Chauffeur> Chauffeurs { get; set; }
        public IEnumerable<VehicleRegistration> VechileRegistrations { get; set; }
        public IEnumerable<ChauffeurRegistration> ChauffeurRegistrations { get; set; }
    }
}
