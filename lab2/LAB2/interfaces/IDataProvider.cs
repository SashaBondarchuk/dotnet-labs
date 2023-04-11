using LAB2.classes;
using System.Collections.Generic;


namespace LAB2.interfaces
{
    interface IDataProvider
    {
        IEnumerable<Owner> Owners { get; set; }
        IEnumerable<Chauffeur> Chauffeurs { get; set; }
        IEnumerable<VehicleRegistration> VechileRegistrations { get; set; }
        IEnumerable<ChauffeurRegistration> ChauffeurRegistrations { get; set; }
        IEnumerable<Vechile> Vechiles { get; set; }
    }
}
