using System.Runtime.Serialization.Formatters.Binary;

namespace LAB4.helpers
{
    public static class BinaryParser
    {
        private static readonly string path = "data.dat";
        public static string ReadFromFile()
        {
            BinaryFormatter binaryFormatter = new();
            using (FileStream fileStream = new(path, FileMode.OpenOrCreate))
            {
                return (string)binaryFormatter.Deserialize(fileStream);
            }
        }
    }
}
