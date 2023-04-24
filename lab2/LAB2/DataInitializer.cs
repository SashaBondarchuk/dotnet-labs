using System;
using System.IO;
using LAB2.classes;
using LAB2.enums;
using LAB2.interfaces;


namespace LAB2
{
    class DataInitializer
    {
        private readonly IDataProvider dataProvider;
        public DataInitializer(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        public void Initialize(InitializeType initializeType)
        {
            switch (initializeType)
            {
                case InitializeType.XmlFileComplex:
                    InitializeFromXml(SerializeType.XmlWriter);
                    break;
                case InitializeType.XmlFileDefault:
                    InitializeFromXml(SerializeType.DefaultXmlSerializer);
                    break;
                case InitializeType.Console:
                    InitializeFromConsole();
                    break;
            }
        }
        private void InitializeFromXml(SerializeType serializeType)
        {
            try
            {
                dataProvider.Owners = XmlDataLoader.LoadData<Owner>(serializeType);
                dataProvider.Chauffeurs = XmlDataLoader.LoadData<Chauffeur>(serializeType);
                dataProvider.Vechiles = XmlDataLoader.LoadData<Vechile>(serializeType);
                dataProvider.VechileRegistrations = XmlDataLoader.LoadData<VehicleRegistration>(serializeType);
                dataProvider.ChauffeurRegistrations = XmlDataLoader.LoadData<ChauffeurRegistration>(serializeType);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void InitializeFromConsole()
        {
            dataProvider.Owners = ConsoleDataInitializer.CreateCollection<Owner>();
            dataProvider.Chauffeurs = ConsoleDataInitializer.CreateCollection<Chauffeur>();
            dataProvider.Vechiles = ConsoleDataInitializer.CreateCollection<Vechile>();
            dataProvider.VechileRegistrations = ConsoleDataInitializer.CreateCollection<VehicleRegistration>();
            dataProvider.ChauffeurRegistrations = ConsoleDataInitializer.CreateCollection<ChauffeurRegistration>();
        }
    }
}
