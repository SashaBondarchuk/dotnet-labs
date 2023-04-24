using System;
using System.Xml.Schema;
using System.Xml;
using System.IO;

namespace LAB2.XmlLogic
{
    static class XmlValidator
    {
        private static XmlReaderSettings settings = new XmlReaderSettings();
        static XmlValidator ()
        {
            settings.ValidationType = ValidationType.Schema;
            string[] schemas = Directory.GetFiles($"{Directory.GetCurrentDirectory()}/XmlSchemas");
            foreach (var schemaPath in schemas)
            {
                settings.Schemas.Add("", schemaPath);
            }
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationEventHandler);
        }
        public static void Validate(string path)
        {
            using (XmlReader reader = XmlReader.Create(path, settings))
            {
                try
                {
                    while (reader.Read()) { }
                    //Console.WriteLine("Validated " + path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "\n");
                    throw;
                }
            };
        }
        private static void ValidationEventHandler(object sender, ValidationEventArgs args)
        {
            throw new Exception($"Файл не відповідає схемі валідації: {args.Message}");
        }
    }
}
