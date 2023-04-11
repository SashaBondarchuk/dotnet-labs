using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace LAB2
{
    static class XmlDataLoader 
    {
        private static Type instanceType;
        private static string path; 
        public static List<T> DefaultDeserialize<T>()
        {
            instanceType = typeof(T);
            path = $"../../XML/{instanceType.Name}s.xml";
            //if (!File.Exists(path))
            //    throw new FileNotFoundException(); ??
            var xmlSerializer = new XmlSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate)) 
            {
                return (List<T>)xmlSerializer.Deserialize(fs);
            }
        }
        public static List<T> XmlDocumentDeserialize<T>() where T : new()
        {
            instanceType = typeof(T);
            path = $"../../XML/__{instanceType.Name}s.xml"; //change
            //if (!File.Exists(path))
            //    throw new FileNotFoundException(); ??

            var xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            XmlElement rootEl = xmlDocument.DocumentElement;
            List<T> instanceList = new List<T>();

            foreach (XmlNode xNode in rootEl)
            {
                T instance = new T();
                instance = GetChildNodes(instance, xNode);
                instanceList.Add(instance);
            }
            return instanceList;
        }
        public static List<T> XmlDocumentDeserialize<T>(string fileName) where T : new()
        {
            path = $"../../XML/{fileName}.xml";
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            XmlElement rootEl = xmlDocument?.DocumentElement;
            if (rootEl == null)
                throw new FileNotFoundException();

            List<T> instanceList = new List<T>();

            foreach (XmlNode xNode in rootEl)
            {
                T instance = new T();
                instance = GetChildNodes(instance, xNode);
                instanceList.Add(instance);
            }

            return instanceList;
        }
        private static T GetChildNodes<T>(T instance, XmlNode xNode)
        {
            instanceType = typeof(T);
            foreach (XmlNode childNode in xNode.ChildNodes)
            {
                var property = instanceType.GetProperty(childNode.Name);
                if (property != null)
                {                   
                    object value = property.PropertyType.IsEnum
                        ? Enum.Parse(property.PropertyType, childNode.InnerText, true)
                        : Convert.ChangeType(childNode.InnerText, property.PropertyType);
                    property.SetValue(instance, value);
                }
            }
            return instance;
        }
        public static XDocument LoadDocument(string fileName) 
        {
            path = $"../../XML/{fileName.ToLower()}.xml";
            if (!File.Exists(path))
                return null;
            return XDocument.Load(path);
        }
    }
}
