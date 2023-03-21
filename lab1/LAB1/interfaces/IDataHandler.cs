using System.Collections.Generic;
using System.Linq;
using LAB1.classes;
using LAB1.enums;

namespace LAB1.interfaces
{
    internal interface IDataHandler
    {
        IEnumerable<Vechile> GetAllVehicles();
        IEnumerable<Vechile> GetVehiclesByType(BodyType type); 
        IEnumerable<VehicleXRegistration> GetRegistratedVehicles(); 
        IOrderedEnumerable<Chauffeur> SortChaffeurs();
        int GetAllDriversCount();
        IEnumerable<VehicleRegistration> GetAllOwnerRegistrations(int ownerID);
        IEnumerable<Chauffeur> GetChauffeursWithFistSurnameLetters(string letters);
        IEnumerable<Owner> GetOwnersWithRegCountMoreThan(int count);
        Chauffeur GetYoungestChauffeur(); 
        int GetChauffeursCount(int regID); 
        IEnumerable<string> ToUpperChauffeurSurnames();
        IEnumerable<Owner> TakeWhile(int year);
        IEnumerable<Vechile> VechilesWithoutRegistrations();
        IEnumerable<Owner> SkipOwners(int index);
        IEnumerable<IGrouping<Manufacturer, Vechile>> GroupByManufacturer();
        bool AllOwnersIsOlderThan21();
        int AverageBirthYearOfChauffeurs();
        IEnumerable<Driver> GetDrivers();
        Vechile GetLastRegistratedVehicle();
        IEnumerable<string> DeleteDublicateDriverLicences();
    }
}
