using LAB2.enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace LAB2
{
    class XmlSerialiser 
    {
        private static Type instanceType; 
        private static PropertyInfo[] instanceProps; 

        public static void SerializeCollection<T>(SerializeType serializeType, IEnumerable<T> collection)
        {
            instanceType = typeof(T);
            instanceProps = instanceType.GetProperties();

            if (collection == null) { return; } 

            if (serializeType == SerializeType.DefaultXmlSerializer)
            {
                DefaultSerializer(collection);
                return;
            }
            if (serializeType == SerializeType.XmlWriter)
            {
                WriterSerializer(collection);
                return;
            }
        }
        private static void DefaultSerializer<T>(IEnumerable<T> collection)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream($@"../../XML/{instanceType.Name}s.xml", FileMode.OpenOrCreate)) //implement path
            {
                xmlSerializer.Serialize(fs, collection.ToList());
            }
        }
        private static void WriterSerializer<T>(IEnumerable<T> collection)
        {
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter xmlWriter = XmlWriter.Create($@"../../XML/__{instanceType.Name}s.xml", settings)) //implement path
            {
                xmlWriter.WriteStartElement($"{instanceType.Name}s");
                foreach (var item in collection)
                {
                    xmlWriter.WriteStartElement($"{instanceType.Name}");
                    foreach (var prop in instanceProps)
                        xmlWriter.WriteElementString(prop.Name, prop.GetValue(item).ToString());
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
            }
        }
    }
}
