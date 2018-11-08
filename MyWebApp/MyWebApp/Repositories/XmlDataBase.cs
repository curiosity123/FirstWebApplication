using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MyWebApp.Repositories
{
    public static class XmlDataBase<T>
    {

        public static List<T> Load()
        {
            if (!File.Exists(typeof(T).Name + ".xml"))
                return new List<T>();
            using (var sr = new StreamReader(typeof(T).Name + ".xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<T>));
                return (List<T>)xs.Deserialize(sr);
            }
        }

        public static void Save(List<T> items)
        {

            XmlSerializer xs = new XmlSerializer(typeof(List<T>));
            TextWriter tw = new StreamWriter(typeof(T).Name + ".xml");
            xs.Serialize(tw, items);
            tw.Close();
        }
    }
}
