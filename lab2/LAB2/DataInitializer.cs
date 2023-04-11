using LAB2.classes;
using LAB2.enums;
using LAB2.interfaces;


namespace LAB2
{
    static class DataInitializer
    {
        private static IDataProvider dataProvider;
        public static void Initialize(InitializeType initializeType, IDataProvider DataProvider)
        {
            dataProvider = DataProvider;
            switch (initializeType)
            {
                case InitializeType.XmlFileComplex:
                    ComplexInitializeFromXml();
                    break;
                case InitializeType.XmlFileDefault:
                    DefaultInitializeFromXml();
                    break;
                case InitializeType.Console:
                    InitializeFromConsole();
                    break;
            }
        }
        private static void DefaultInitializeFromXml()
        {
            dataProvider.Owners = XmlDataLoader.DefaultDeserialize<Owner>();
            dataProvider.Chauffeurs = XmlDataLoader.DefaultDeserialize<Chauffeur>();
            dataProvider.Vechiles = XmlDataLoader.DefaultDeserialize<Vechile>();
            dataProvider.VechileRegistrations = XmlDataLoader.DefaultDeserialize<VehicleRegistration>();
            dataProvider.ChauffeurRegistrations = XmlDataLoader.DefaultDeserialize<ChauffeurRegistration>();
        }
        private static void ComplexInitializeFromXml()
        {
            dataProvider.Owners = XmlDataLoader.XmlDocumentDeserialize<Owner>();
            dataProvider.Chauffeurs = XmlDataLoader.XmlDocumentDeserialize<Chauffeur>();
            dataProvider.Vechiles = XmlDataLoader.XmlDocumentDeserialize<Vechile>();
            dataProvider.VechileRegistrations = XmlDataLoader.XmlDocumentDeserialize<VehicleRegistration>();
            dataProvider.ChauffeurRegistrations = XmlDataLoader.XmlDocumentDeserialize<ChauffeurRegistration>();
        }
        private static void InitializeFromConsole()
        {
            dataProvider.Owners = ConsoleDataInitializer.CreateCollection<Owner>();
            dataProvider.Chauffeurs = ConsoleDataInitializer.CreateCollection<Chauffeur>();
            dataProvider.Vechiles = ConsoleDataInitializer.CreateCollection<Vechile>();
            dataProvider.VechileRegistrations = ConsoleDataInitializer.CreateCollection<VehicleRegistration>();
            dataProvider.ChauffeurRegistrations = ConsoleDataInitializer.CreateCollection<ChauffeurRegistration>();
        }
    }
}
