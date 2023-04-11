using LAB2.classes;
using LAB2.interfaces;
using System.Collections.Generic;


namespace LAB2
{
    public class DataProvider : IDataProvider
    {
        public IEnumerable<Owner> Owners { get; set; }
        public IEnumerable<Vechile> Vechiles { get; set; }
        public IEnumerable<Chauffeur> Chauffeurs { get; set; }
        public IEnumerable<VehicleRegistration> VechileRegistrations { get; set; }
        public IEnumerable<ChauffeurRegistration> ChauffeurRegistrations { get; set; }
    }
}
