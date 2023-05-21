using System.Runtime.Serialization.Formatters.Binary;

namespace LAB4.helpers
{
    public static class BinarySerializer
    {
        private static readonly string path = "data.dat";
        public static void WriteIntoFile(string data)
        {
            BinaryFormatter binaryFormatter = new();
            using (FileStream fileStream = new(path, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fileStream, data);
            }
        }
    }
}
