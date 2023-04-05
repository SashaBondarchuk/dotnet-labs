using LAB1.classes;
using LAB1.enums;
using System;
using System.Collections.Generic;


namespace LAB1
{
    class DataInitializer
    {
        private IDataProvider dataProvider;
        public DataInitializer(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        public void Initialize()
        {
            dataProvider.Vechiles = new List<Vechile>
            {
                new Vechile()
                {
                    Vin = "JN8AF5MR9CT040822",
                    Brand = Brand.Audi,
                    Manufacturer = Manufacturer.Volkswagen_AG,
                    Model = "a3",
                    LicensePlate = "BX3253AO",
                    BodyType = BodyType.Sedan,
                    Color = CarColor.White,
                    TechCondition = TechCondition.FactoryNew,
                    RealeseDate = new DateTime(2016, 1, 18),
                },
                new Vechile()
                {
                    Vin = "YV126MFK3F1509424",
                    Brand = Brand.Audi,
                    Manufacturer = Manufacturer.Volkswagen_AG,
                    Model = "r8",
                    LicensePlate = "BX0053AB",
                    BodyType = BodyType.Coupe,
                    Color = CarColor.White,
                    TechCondition = TechCondition.Used,
                    RealeseDate = new DateTime(2018, 11, 15)
                },
                new Vechile()
                {
                    Vin = "WA1VMBFP9EA660849",
                    Brand = Brand.Porsche,
                    Manufacturer = Manufacturer.Volkswagen_AG,
                    Model = "911",
                    LicensePlate = "BB1233CB",
                    BodyType = BodyType.Coupe,
                    Color = CarColor.Black,
                    TechCondition = TechCondition.FactoryNew,
                    RealeseDate = new DateTime(2021, 7, 5)
                },
                new Vechile()
                {
                    Vin = "2G4WN58C281314820",
                    Brand = Brand.Volkswagen,
                    Manufacturer = Manufacturer.Volkswagen_AG,
                    Model = "Golf",
                    LicensePlate = "BM7324CC",
                    BodyType = BodyType.Hatchback,
                    Color = CarColor.Yellow,
                    TechCondition = TechCondition.Damaged,
                    RealeseDate = new DateTime(2017, 4, 28)
                },
                new Vechile()
                {
                    Vin = "WA1VMAFE1BD413165",
                    Brand = Brand.Volkswagen,
                    Manufacturer = Manufacturer.Volkswagen_AG,
                    Model = "Passat",
                    LicensePlate = "OB8883JC",
                    BodyType = BodyType.Wagon,
                    Color = CarColor.Green,
                    TechCondition = TechCondition.FactoryNew,
                    RealeseDate = new DateTime(2011, 7, 15)
                },
                new Vechile()
                {
                    Vin = "WBA3B5G56DN456225",
                    Brand = Brand.Mercedes_Benz,
                    Manufacturer = Manufacturer.Daimler_AG,
                    Model = "W638",
                    LicensePlate = "BB7283CC",
                    BodyType = BodyType.Van,
                    Color = CarColor.Green,
                    TechCondition = TechCondition.Used,
                    RealeseDate = new DateTime(2014, 3, 17)
                },
                new Vechile()
                {
                    Vin = "2LMHJ5AR3BB270190",
                    Brand = Brand.Mercedes_Maybach,
                    Manufacturer = Manufacturer.Daimler_AG,
                    Model = "62S",
                    LicensePlate = "BT7788AO",
                    BodyType = BodyType.Sedan,
                    Color = CarColor.White,
                    TechCondition = TechCondition.Salvage,
                    RealeseDate = new DateTime(2017, 10, 1)
                },
            };
            dataProvider.Owners = new List<Owner>
            {
                new Owner()
                {
                    Id = 1,
                    Name = "Свястислав",
                    Surname = "Шпак",
                    MiddleName = "Златович",
                    Adress = "Хмельницький, пл. М. Коцюбинського, 15",
                    BirthDate = new DateTime(2001, 1, 4),
                    DriverLicense = "СВІ2402150",
                },
                new Owner()
                {
                    Id = 2,
                    Name = "Йосеф",
                    Surname = "Шепітько",
                    MiddleName = "Глібович",
                    Adress = "Запоріжжя, просп. Тараса Шевченка, 48",
                    BirthDate = new DateTime(1995, 1, 7),
                    DriverLicense = "ЛЩД6337274",
                },
                new Owner()
                {
                    Id = 3,
                    Name = "Микита",
                    Surname = "Цебровський",
                    MiddleName = "Левович",
                    Adress = "Миколаїв, пров. Інститутська, 09",
                    BirthDate = new DateTime(2000, 11, 8),
                    DriverLicense = "ГГО9221609",
                },
                new Owner()
                {
                    Id = 4,
                    Name = "Назар",
                    Surname = "Старченко",
                    MiddleName = "Яромирович",
                    Adress = "Ужгород, вул. Лук’янівська, 61",
                    BirthDate = new DateTime(2004, 11, 15),
                    DriverLicense = "РПІ9032227"
                },
            };
            dataProvider.Chauffeurs = new List<Chauffeur>
            {
                new Chauffeur()
                {
                    Id = 1,
                    Name = "Давид",
                    Surname = "Пригода",
                    MiddleName = "Милославович",
                    Adress = "Кропивницький, пл. Урицького, 44",
                    BirthDate = new DateTime(2001, 12, 4),
                    DriverLicense = "ДЛО9181901",
                },
                new Chauffeur()
                {
                    Id = 2,
                    Name = "Олександр",
                    Surname = "Пероганич",
                    MiddleName = "Максимович",
                    Adress = "Дніпро, пров. П. Орлика, 86",
                    BirthDate = new DateTime(2003, 8, 20),
                    DriverLicense = "АПІ3961127",
                },
                new Chauffeur()
                {
                    Id = 3,
                    Name = "Микита",
                    Surname = "Цебровський",
                    MiddleName = "Левович",
                    Adress = "Миколаїв, пров. Інститутська, 09",
                    BirthDate = new DateTime(2000, 11, 8),
                    DriverLicense = "ГГО9221609",
                },
                new Chauffeur()
                {
                    Id = 4,
                    Name = "Назар",
                    Surname = "Старченко",
                    MiddleName = "Яромирович",
                    Adress = "Ужгород, вул. Лук’янівська, 61",
                    BirthDate = new DateTime(2004, 11, 15),
                    DriverLicense = "РПІ9032227",
                },
                new Chauffeur()
                {
                    Id = 5,
                    Name = "Юрій",
                    Surname = "Танцюра",
                    MiddleName = "Омелянович",
                    Adress = "Одеса, просп. Тараса Шевченка, 76",
                    BirthDate = new DateTime(1971, 8, 14),
                    DriverLicense = "ПМВ9432584",
                },
                new Chauffeur()
                {
                    Id = 6,
                    Name = "Володимир",
                    Surname = "Стогній",
                    MiddleName = "Тихонович",
                    Adress = "Суми, пров. Володимирська, 38",
                    BirthDate = new DateTime(1984, 8, 27),
                    DriverLicense = "ЙЦЧ6079152",
                },
               };
            dataProvider.VechileRegistrations = new List<VehicleRegistration>
            {
                new VehicleRegistration()
                {
                    Id = 1,
                    OwnerID = 1,
                    VinId = "JN8AF5MR9CT040822",
                    RegistrationDate = new DateTime(2016, 2, 15),
                },
                new VehicleRegistration()
                {
                    Id = 2,
                    OwnerID = 1,
                    VinId = "YV126MFK3F1509424",
                    RegistrationDate = new DateTime(2018, 12, 15),
                },
                new VehicleRegistration()
                {
                    Id = 3,
                    OwnerID = 2,
                    VinId = "YV126MFK3F1509424",
                    RegistrationDate = new DateTime(2019, 2, 10),
                },
                new VehicleRegistration()
                {
                    Id = 4,
                    OwnerID = 2,
                    VinId = "JN8AF5MR9CT040822",
                    RegistrationDate = new DateTime(2018, 12, 1),
                },
                new VehicleRegistration()
                {
                    Id = 5,
                    OwnerID = 1,
                    VinId = "JN8AF5MR9CT040822",
                    RegistrationDate = new DateTime(2021, 4, 1),
                },
                new VehicleRegistration()
                {
                    Id = 6,
                    OwnerID = 2,
                    VinId = "WA1VMBFP9EA660849",
                    RegistrationDate = new DateTime(2022, 1, 12),
                },
                new VehicleRegistration()
                {
                    Id = 7,
                    OwnerID = 3,
                    VinId = "2G4WN58C281314820",
                    RegistrationDate = new DateTime(2018, 10, 4),
                },
                new VehicleRegistration()
                {
                    Id = 8,
                    OwnerID = 3,
                    VinId = "WA1VMAFE1BD413165",
                    RegistrationDate = new DateTime(2012, 3, 25),
                },
                new VehicleRegistration()
                {
                    Id = 9,
                    OwnerID = 4,
                    VinId = "WA1VMBFP9EA660849",
                    RegistrationDate = new DateTime(2023, 2, 17),
                },
            };
            dataProvider.ChauffeurRegistrations = new List<ChauffeurRegistration>
            {
                new ChauffeurRegistration()
                {
                    Id = 1,
                    VechileRegistrationID = 1,
                    ChauffeurID = 1,
                    Date = new DateTime(2016, 2, 16)
                },
                new ChauffeurRegistration()
                {
                    Id = 2,
                    VechileRegistrationID = 1,
                    ChauffeurID = 2,
                    Date = new DateTime(2016, 2, 16)
                },
                new ChauffeurRegistration()
                {
                    Id = 3,
                    VechileRegistrationID = 4,
                    ChauffeurID = 1,
                    Date = new DateTime(2018, 12, 1)
                },
                new ChauffeurRegistration()
                {
                    Id = 4,
                    VechileRegistrationID = 4,
                    ChauffeurID = 3,
                    Date = new DateTime(2018, 12, 1)
                },
                new ChauffeurRegistration()
                {
                    Id = 5,
                    VechileRegistrationID = 2,
                    ChauffeurID = 2,
                    Date = new DateTime(2018, 12, 15)
                },
                new ChauffeurRegistration()
                {
                    Id = 6,
                    VechileRegistrationID = 2,
                    ChauffeurID = 3,
                    Date = new DateTime(2018, 12, 15)
                },
                new ChauffeurRegistration()
                {
                    Id = 7,
                    VechileRegistrationID = 2,
                    ChauffeurID = 4,
                    Date = new DateTime(2018, 12, 19)
                },
                new ChauffeurRegistration()
                {
                    Id = 8,
                    VechileRegistrationID = 3,
                    ChauffeurID = 3,
                    Date = new DateTime(2019, 2, 10)
                },
                new ChauffeurRegistration()
                {
                    Id = 9,
                    VechileRegistrationID = 3,
                    ChauffeurID = 6,
                    Date = new DateTime(2018, 2, 10)
                },
                new ChauffeurRegistration()
                {
                    Id = 10,
                    VechileRegistrationID = 6,
                    ChauffeurID = 3,
                    Date = new DateTime(2022, 1, 15)
                },
                new ChauffeurRegistration()
                {
                    Id = 11,
                    VechileRegistrationID = 6,
                    ChauffeurID = 4,
                    Date = new DateTime(2022, 10, 20)
                },
                new ChauffeurRegistration()
                {
                    Id = 12,
                    VechileRegistrationID = 6,
                    ChauffeurID = 1,
                    Date = new DateTime(2022, 12, 12)
                },
                new ChauffeurRegistration()
                {
                    Id = 13,
                    VechileRegistrationID = 9,
                    ChauffeurID = 2,
                    Date = new DateTime(2023, 2, 17)
                },
            };
        }
    }
}
