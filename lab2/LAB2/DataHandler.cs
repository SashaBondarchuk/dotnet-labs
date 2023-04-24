using LAB2.classes;
using LAB2.enums;
using LAB2.interfaces;
using LAB2.XmlLogic;
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
        private XDocument VehicleDocument;
        public DataHandler(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
            try
            {
                ValidateXmlFiles();
                InitializeXDocument();
            }
            catch (Exception) {}
        }
        public bool DocumentIsInitialized()
        {
            return VehicleDocument != null;
        }
        public void ValidateXmlFiles() 
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string[] xmlFiles = Directory.GetFiles($"{currentDirectory}/XML_FILES");
            if(xmlFiles.Count() == 0)
            {
                return;
            }
            foreach (string xmlFile in xmlFiles)
            {
                XmlValidator.Validate(xmlFile);
            }
        }
        public void WriteDataToXml(int option)
        {
            DataInitializer dataInitializer = new DataInitializer(dataProvider); 
            dataInitializer.Initialize(InitializeType.Console);

            SerializeType serializeType = (SerializeType)option;
            switch (serializeType)
            {
                case SerializeType.DefaultXmlSerializer:
                    SerializeCollections(serializeType);
                    break;
                case SerializeType.XmlWriter:
                    SerializeCollections(serializeType);
                    break;
            }
            InitializeXDocument();
        }
        private void InitializeXDocument()
        {
            try
            {
                VehicleDocument = XmlDataLoader.LoadDocument("Vechiles", XmlFilePathCreator.DirectoryName);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                VehicleDocument = null;
            }
        }
        private void SerializeCollections(SerializeType serializeType)
        {
            XmlSerialiser.SerializeCollection(serializeType, dataProvider.Owners);
            XmlSerialiser.SerializeCollection(serializeType, dataProvider.Chauffeurs);
            XmlSerialiser.SerializeCollection(serializeType, dataProvider.Vechiles);
            XmlSerialiser.SerializeCollection(serializeType, dataProvider.VechileRegistrations);
            XmlSerialiser.SerializeCollection(serializeType, dataProvider.ChauffeurRegistrations);
        }
        public IEnumerable<XElement> GetVehicles()
        {
            return VehicleDocument.GetRootElements();
        }
        public IEnumerable<XElement> GetSelectedDescendants()
        {
            return VehicleDocument.GetRootElements().Descendants("Model");
        }
        public IEnumerable<string> GetBrandsAndSort()
        {
            return VehicleDocument.GetRootElements()
                .Select(node => node.Element("Brand").Value)
                .OrderBy(node => node);
        }
        public string GetElementWithSelectedText(string text)
        {
            var result = from node in VehicleDocument.GetRootElements()
                         where node.Element("LicensePlate").Value == text
                         select node;
            if(result.Count() == 0)
                return "Такої машини не знайдено";
            return result.First().ToString();
        }
        public IEnumerable<Vechile> GetVehiclesWithLinq()
        {
            var vechiles = XmlDataLoader.LoadData<Vechile>(SerializeType.XmlWriter);
            return vechiles;
        }
        public void XmlNodeDelete()
        {
            XDocument vehiclesDoc;
            try
            {
                vehiclesDoc = XmlDataLoader.LoadDocument("Vechiles", XmlFilePathCreator.DirectoryName);
                vehiclesDoc.GetRootElements().Elements("Color").Remove();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public IEnumerable<IGrouping<Manufacturer, Vechile>> GroupByManufacturer()
        {
            return VehicleDocument.GetRootElements().Select(v =>
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
            return from v in VehicleDocument.GetRootElements()
                where (TechCondition)Enum.Parse(typeof(TechCondition), v.Element("TechCondition").Value) == TechCondition.FactoryNew
                select v;
        }
        public bool AllVechilesIsSedan(BodyType body)
        {
            return VehicleDocument.GetRootElements()
                .All(v => (BodyType)Enum.Parse(typeof(BodyType), v.Element("BodyType").Value) == body);
        }
        public IEnumerable<XElement> GetVechilesTillSelectedYear(int year)
        {
            return VehicleDocument.GetRootElements()
                .Where(v => year > DateTime.Parse(v.Element("RealeseDate").Value).Year);
        }
        public XElement ChangeColorByVin(string vin, CarColor carColor)
        {
            var vechile = VehicleDocument.GetRootElements()
                .Where(v => v.Element("Vin").Value == vin).First();
            vechile.Element("Color").Value = carColor.ToString();
            return vechile;
        }
        public int GetYearOfOldestCar()
        {
            var year = VehicleDocument.GetRootElements()
                .Min(v => DateTime.Parse(v.Element("RealeseDate").Value).Year);
            return year;
        }
        public int GetCountOfSelectedBrand(Brand brand)
        {
            return VehicleDocument.GetRootElements()
                .Where(v => v.Element("Brand").Value == brand.ToString())
                .Count();
        }
        public IEnumerable<XElement> GetSelectedVechilesByPlate (string symbols)
        {
            return VehicleDocument.GetRootElements()
                .Where(v => v.Element("LicensePlate").Value.StartsWith(symbols));
        }
        public IEnumerable<XElement> TakeWhile(int year)
        {
            return VehicleDocument.GetRootElements()
                .TakeWhile(v => DateTime.Parse(v.Element("RealeseDate").Value).Year < year);
        }
    }
}
