using LAB2.classes;
using LAB2.enums;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace LAB2.interfaces
{
    interface IDataHandler
    {
        bool DocumentIsInitialized();
        void WriteDataToXml(int option);
        string GetFileContent(string fileName);
        IEnumerable<string> GetXmlFileNames();
        IEnumerable<XElement> GetVehicles();
        IEnumerable<XElement> GetSelectedDescendants();
        IEnumerable<string> GetBrandsAndSort();
        string GetElementWithSelectedText(string text);
        IEnumerable<Vechile> GetVehiclesWithLinq(string fileName);
        IEnumerable<XElement> XmlNodeDelete();
        IEnumerable<IGrouping<Manufacturer, Vechile>> GroupByManufacturer();
        IEnumerable<XElement> GetNewVehicles();
        bool AllVechilesIsSedan(BodyType body);
        IEnumerable<XElement> GetVechilesTillSelectedYear(int year);
        XElement ChangeColorByVin(string vin, CarColor carColor);
        int GetYearOfOldestCar();
        int GetCountOfSelectedBrand(Brand brand);
        IEnumerable<XElement> GetSelectedVechilesByPlate(string symbols);
        IEnumerable<XElement> TakeWhile(int year);
    }
}
