using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace LAB2.XmlLogic
{
    static class XmlExtentions
    {
        public static IEnumerable<XElement> GetRootElements(this XDocument xDocument)
        {
            return xDocument?.Root?.Elements();
        }
    }
}
