using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace real_time_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleClass exampleClass = new ExampleClass();
            exampleClass.property1 = "propertyValue";
            exampleClass.property2 = 30;
            XmlSeriliazer a = new XmlSeriliazer();
            XmlDocument xml = a.Seriliaze(exampleClass);
            xml.Save("test.xml");

        }
    }
}
