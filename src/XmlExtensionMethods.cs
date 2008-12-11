using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace System.Xml
{
    public static class XmlExtensionMethods
    {
        public static XmlElement AddElement(this XmlNode element, string name)
        {

            XmlElement child = element.OwnerDocument.CreateElement(name);

            element.AppendChild(child);



            return child;

        }
        public static string GetAttributeString(this XmlNode element, string name)
        {
            return element.Attributes.GetNamedItem(name).InnerText;
        }    
    }
}
