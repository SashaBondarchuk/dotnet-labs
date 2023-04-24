using LAB2.enums;
using System.IO;

namespace LAB2
{
    static class XmlFilePathCreator
    {
        public static string DirectoryName { get; } = "XML_FILES";
        public static string GetPath<T>(SerializeType serializeType)
        {
            string collectionName = SerializeType.DefaultXmlSerializer == serializeType
                ? $"ser_{typeof(T).Name}s"
                : $"{typeof(T).Name}s";
            if(!Directory.Exists(DirectoryName))
            {
                Directory.CreateDirectory(DirectoryName);
            }
            string path = $"{DirectoryName}/{collectionName}.xml";
            return path;
        }
        public static string GetPath(string directoryName, string fileName)
        {
            return $"{directoryName}/{fileName}.xml";
        }
    }
}
