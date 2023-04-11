using System;
using System.Collections.Generic;
using System.Reflection;


namespace LAB2
{
    static class ConsoleDataInitializer
    {
        static public List<T> CreateCollection<T>() where T : new()
        {
            Console.Write($"Введість кількість об'єктів типу {typeof(T).Name}: ");
            int instanceCount;
            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out instanceCount);
                if (!flag)
                {
                    Console.WriteLine("Введіть число\n");
                    continue;
                }
                break;
            }
            List<T> list = new List<T>();
            for (int i = 0; i < instanceCount; i++)
            {
                Console.WriteLine($"{typeof(T).Name} {i + 1}:");
                T instance = CreateInstance<T>();
                list.Add(instance);
            }
            return list;
        }

        static private T CreateInstance<T>() where T : new() 
        {
            PropertyInfo[] publicProps = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            T instance = new T();
            foreach (var prop in publicProps)
            {
                Console.Write($"{prop.Name}:");

                object value = prop.PropertyType.IsEnum
                    ? Enum.Parse(prop.PropertyType, Console.ReadLine(), true)
                    : Convert.ChangeType(Console.ReadLine(), prop.PropertyType);

                prop.SetValue(instance, value);
            }
            return instance;
        }
    }
}
