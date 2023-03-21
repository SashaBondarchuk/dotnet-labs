using LAB1.classes;
using System.Collections.Generic;

namespace LAB1
{
    interface IDataProvider
    {
        IEnumerable<Owner> Owners { get; }
        IEnumerable<Chauffeur> Chauffeurs { get; }
        IEnumerable<VehicleRegistration> VechileRegistrations { get; }
        IEnumerable<ChauffeurRegistration> ChauffeurRegistrations { get; }
        IEnumerable<Vechile> Vechiles { get; }
    }
}
