using System;
using System.ComponentModel;


namespace LAB2
{
    public static class ConvertHelper
    {
        public static object ChangeType(Type type, object value)
        {
            TypeConverter typeConverter = TypeDescriptor.GetConverter(type);
            if (type.IsEnum)
            {
                return Enum.Parse(type, (string)value, true);
            }
            return typeConverter.ConvertFrom(value);
        }
    }
}
