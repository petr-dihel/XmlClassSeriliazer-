using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClassLibrary1
{
    public class XmlSeriliazer
    {

        public XmlDocument Seriliaze(object obj)
        {
            XmlDocument xmlDocument = new XmlDocument();

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            XmlAttribute objectName = xmlDocument.CreateAttribute("name");
            objectName.InnerText = type.FullName;
            XmlNode root = xmlDocument.CreateElement("Objects");
            xmlDocument.AppendChild(xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null));

            XmlNode item = xmlDocument.CreateElement("Object");
            item.Attributes.Append(objectName);
            foreach (PropertyInfo propertyInfo in properties)
            {
                XmlNode field = xmlDocument.CreateElement("field");

                XmlAttribute fieldName = xmlDocument.CreateAttribute("fieldName");
                fieldName.InnerText = propertyInfo.Name;
                XmlAttribute fieldValue = xmlDocument.CreateAttribute("fieldValue");
                fieldValue.InnerText = propertyInfo.GetValue(obj).ToString();
                XmlAttribute fieldType = xmlDocument.CreateAttribute("fieldType");
                fieldType.InnerText = propertyInfo.DeclaringType.ToString();

                field.Attributes.Append(fieldName);
                field.Attributes.Append(fieldValue);
                field.Attributes.Append(fieldType);

                item.AppendChild(field);
            }
            root.AppendChild(item);
            xmlDocument.AppendChild(root);
            return xmlDocument;
        }

    }
}
