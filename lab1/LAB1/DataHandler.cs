using LAB1.classes;
using LAB1.ClassesForLinq;
using LAB1.enums;
using LAB1.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace LAB1.services
{
    class DataHandler : IDataHandler
    {
        private readonly IDataProvider dataProvider;
        public DataHandler(IDataProvider dataProvider) 
        {
            this.dataProvider = dataProvider;
        }

        public IEnumerable<Vechile> GetAllVehicles()
        {
            return from v in dataProvider.Vechiles 
                   select v;
        }

        public IEnumerable<Vechile> GetVehiclesByType(BodyType type)
        {
            return from sv in dataProvider.Vechiles 
                   where sv.BodyType == type
                   select sv;
        }

        public IEnumerable<VehicleXRegistration> GetRegistratedVehicles()
        {
            return dataProvider.Vechiles.GroupJoin(dataProvider.VechileRegistrations, v => v.Vin, r => r.VinId, (v, r) =>
            new VehicleXRegistration
            {
                Vechile = v,
                VehicleRegistrations = r
            }).Where(v => v.VehicleRegistrations.Count() > 0);
        }

        public IOrderedEnumerable<Chauffeur> SortChaffeurs()
        {
            return from ch in dataProvider.Chauffeurs 
                   orderby ch.Surname
                   select ch;
        }

        public int GetAllDriversCount()
        {
            return dataProvider.Chauffeurs.Count() + dataProvider.Owners.Count();
        }

        public IEnumerable<VehicleRegistration> GetAllOwnerRegistrations(int ownerID)
        {
            return from reg in dataProvider.VechileRegistrations
                   where reg.OwnerID == ownerID
                   select reg;
        }

        public IEnumerable<Chauffeur> GetChauffeursWithFistSurnameLetters(string letters)
        {
            return from ch in dataProvider.Chauffeurs
                   where ch.Surname.ToLower().StartsWith(letters)
                   select ch;
        }

        public IEnumerable<Owner> GetOwnersWithRegCountMoreThan(int count)
        {
            return dataProvider.Owners.GroupJoin(dataProvider.VechileRegistrations, owner => owner.Id, reg => reg.OwnerID, (owner, reg) =>
            new OwnerXRegistrations
            {
                Owner = owner,
                VehicleRegistrations = reg
            }).Where(o_reg => o_reg.VehicleRegistrations.Count() > count)
              .Select(o_reg => o_reg.Owner);
        }

        public Chauffeur GetYoungestChauffeur()
        {
            return dataProvider.Chauffeurs.OrderByDescending(ch => ch.BirthDate).First();
        }

        public int GetChauffeursCount(int regID)
        {
            return dataProvider.ChauffeurRegistrations.Join(dataProvider.VechileRegistrations, 
                chreg => chreg.VechileRegistrationID, vreg => vreg.Id, (chreg, vreg) => 
                new
                {
                    ChReg = chreg, 
                    VReg = vreg,
                }).Where(x => x.VReg.Id == regID)
                .Select(x => x.ChReg)
                .Count();
        }

        public IEnumerable<string> ToUpperChauffeurSurnames()
        {
            return dataProvider.Chauffeurs.Select(ch => ch.Surname.ToUpper());
        }

        public IEnumerable<Owner> TakeWhile(int year)
        {
            return dataProvider.Owners.TakeWhile(o => o.BirthDate.Year <= year);
        }

        public IEnumerable<Vechile> VechilesWithoutRegistrations()
        {
            var vechilesXregistrationLeft = from v in dataProvider.Vechiles
                                            join reg in dataProvider.VechileRegistrations
                                            on v.Vin equals reg.VinId into VechilesRegistrationsLeft
                                            from subReg in VechilesRegistrationsLeft.DefaultIfEmpty()
                                            select new { Vechile = v, registrationID = subReg?.Id };
            return from vXreg in vechilesXregistrationLeft
                   where vXreg.registrationID == null
                   select vXreg.Vechile;
        }

        public IEnumerable<Owner> SkipOwners(int index)
        {
            return dataProvider.Owners.Skip(index);
        }

        public IEnumerable<IGrouping<Manufacturer, Vechile>> GroupByManufacturer()
        {
            return from v in dataProvider.Vechiles
                   group v by v.Manufacturer;
        }

        public bool AllOwnersIsOlderThan21()
        {
            return dataProvider.Owners.All(o => DateTime.Now.Year - o.BirthDate.Year > 21);
        }

        public int AverageBirthYearOfChauffeurs()
        {
            return (int)dataProvider.Chauffeurs.Average(ch => ch.BirthDate.Year);
        }

        public IEnumerable<Driver> GetDrivers()
        {
            return dataProvider.Chauffeurs.Union((IEnumerable<Driver>)dataProvider.Owners);
        }

        public Vechile GetLastRegistratedVehicle()
        {
            var regV = GetRegistratedVehicles();
            return regV.Last().Vechile;
        }

        public IEnumerable<string> DeleteDublicateDriverLicences()
        {
            var drivers = GetDrivers();
            return drivers.Select(d => d.DriverLicense).Distinct();
        }
    }
}
