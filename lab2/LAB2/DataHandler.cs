using LAB2.classes;
using LAB2.enums;
using LAB2.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace LAB2
{
    class DataHandler : IDataHandler
    {
        private readonly IDataProvider dataProvider;
        private XDocument VehicleDocument = XmlDataLoader.LoadDocument("Vechiles");
        public DataHandler(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        public bool DocumentIsInitialized()
        {
            if (VehicleDocument == null)
            {
                return false;
            }
            return true;
        }
        public void WriteDataToXml(int option)
        {
            DataInitializer.Initialize(InitializeType.Console, dataProvider);

            if (option == 1)
            {
                XmlSerialiser.SerializeCollection(SerializeType.DefaultXmlSerializer, dataProvider.Owners);
                XmlSerialiser.SerializeCollection(SerializeType.DefaultXmlSerializer, dataProvider.Chauffeurs);
                XmlSerialiser.SerializeCollection(SerializeType.DefaultXmlSerializer, dataProvider.Vechiles);
                XmlSerialiser.SerializeCollection(SerializeType.DefaultXmlSerializer, dataProvider.VechileRegistrations);
                XmlSerialiser.SerializeCollection(SerializeType.DefaultXmlSerializer, dataProvider.ChauffeurRegistrations);
            }
            else
            {
                XmlSerialiser.SerializeCollection(SerializeType.XmlWriter, dataProvider.Owners);
                XmlSerialiser.SerializeCollection(SerializeType.XmlWriter, dataProvider.Chauffeurs);
                XmlSerialiser.SerializeCollection(SerializeType.XmlWriter, dataProvider.Vechiles);
                XmlSerialiser.SerializeCollection(SerializeType.XmlWriter, dataProvider.VechileRegistrations);
                XmlSerialiser.SerializeCollection(SerializeType.XmlWriter, dataProvider.ChauffeurRegistrations);
            }
            VehicleDocument = XmlDataLoader.LoadDocument("Vechiles");
        } 
        public string GetFileContent(string fileName)
        {
            var xDocument = XmlDataLoader.LoadDocument(fileName);
            if(xDocument != null) 
                return xDocument.ToString();
            return "Файлу не існує.";
        } 
        public IEnumerable<string> GetXmlFileNames()
        {
            return Directory.EnumerateFiles("../../XML/");
        }
        public IEnumerable<XElement> GetVehicles()
        {
            return VehicleDocument?.Root.Elements();
        }
        public IEnumerable<XElement> GetSelectedDescendants()
        {
            return VehicleDocument?.Root.Descendants("Model");
        }
        public IEnumerable<string> GetBrandsAndSort()
        {
            return VehicleDocument?.Descendants("Vechile")
                .Select(node => node.Element("Brand").Value)
                .OrderBy(node => node);
        }
        public string GetElementWithSelectedText(string text)
        {
            var result = from node in VehicleDocument?.Root.Elements("Vechile")
                         where node.Element("LicensePlate").Value == text
                         select node;
            if(result.Count() == 0)
                return "Такої машини не знайдено";
            return result.First().ToString();
        }
        public IEnumerable<Vechile> GetVehiclesWithLinq(string fileName)
        {
            var vechiles = XmlDataLoader.XmlDocumentDeserialize<Vechile>(fileName);
            return vechiles;
        }
        public IEnumerable<XElement> XmlNodeDelete()
        {
            var vehiclesDoc = XmlDataLoader.LoadDocument("Vechiles");
            vehiclesDoc?.Root.Elements("Vechile").Elements("Color").Remove();
            return vehiclesDoc.Root.Elements("Vechile");
        }
        public IEnumerable<IGrouping<Manufacturer, Vechile>> GroupByManufacturer()
        {
            return VehicleDocument?.Descendants("Vechile").Select(v =>
                new Vechile
                {
                    Vin = v.Element("Vin").Value,
                    Brand = (Brand)Enum.Parse(typeof(Brand), v.Element("Brand").Value),
                    Manufacturer = (Manufacturer)Enum.Parse(typeof(Manufacturer), v.Element("Manufacturer").Value),
                    Model = v.Element("Model").Value,
                    LicensePlate = v.Element("LicensePlate").Value,
                    BodyType = (BodyType)Enum.Parse(typeof(BodyType), v.Element("BodyType").Value),
                    Color = (CarColor)Enum.Parse(typeof(CarColor), v.Element("Color").Value),
                    TechCondition = (TechCondition)Enum.Parse(typeof(TechCondition), v.Element("TechCondition").Value),
                    RealeseDate = DateTime.Parse(v.Element("RealeseDate").Value),
                }).GroupBy(v => v.Manufacturer);
        }
        public IEnumerable<XElement> GetNewVehicles()
        {
            return from v in VehicleDocument?.Root.Descendants("Vechile")
                where (TechCondition)Enum.Parse(typeof(TechCondition), v.Element("TechCondition").Value) == TechCondition.FactoryNew
                select v;
        }
        public bool AllVechilesIsSedan(BodyType body)
        {
            return (bool)VehicleDocument?.Root?.Descendants("Vechile")
                .All(v => (BodyType)Enum.Parse(typeof(BodyType), v.Element("BodyType").Value) == body);
        }
        public IEnumerable<XElement> GetVechilesTillSelectedYear(int year)
        {
            return VehicleDocument?.Root.Elements("Vechile")
                .Where(v => year > DateTime.Parse(v.Element("RealeseDate").Value).Year);
        }
        public XElement ChangeColorByVin(string vin, CarColor carColor)
        {
            var vechile = VehicleDocument?.Root.Elements("Vechile")
                .Where(v => v.Element("Vin").Value == vin).First();
            vechile.Element("Color").Value = carColor.ToString();
            return vechile;
        }
        public int GetYearOfOldestCar()
        {
            var year = VehicleDocument?.Root.Elements("Vechile")
                .Min(v => DateTime.Parse(v.Element("RealeseDate").Value).Year);
            return (int)year;
        }
        public int GetCountOfSelectedBrand(Brand brand)
        {
            return (int)VehicleDocument?.Root.Elements("Vechile")
                .Where(v => v.Element("Brand").Value == brand.ToString())
                .Count();
        }
        public IEnumerable<XElement> GetSelectedVechilesByPlate (string symbols)
        {
            return VehicleDocument?.Root.Elements("Vechile")
                .Where(v => v.Element("LicensePlate").Value.StartsWith(symbols));
        }
        public IEnumerable<XElement> TakeWhile(int year)
        {
            return VehicleDocument?.Root.Elements("Vechile")
                .TakeWhile(v => DateTime.Parse(v.Element("RealeseDate").Value).Year < year);
        }
    }
}
