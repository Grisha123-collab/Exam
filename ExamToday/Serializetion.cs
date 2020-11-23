using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExamToday
{
    public class Serializetion
    {
        public T Deserialize<T>() where T : class
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream stream = File.Open("To-do.xml", FileMode.Open))
            {
                return (T)xmlSerializer.Deserialize(stream);
            }
        } 
        public void Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer formatter = new XmlSerializer(ObjectToSerialize.GetType());
            if (!File.Exists("To-do.xml"))
                File.Create("To-do.xml").Dispose();
            using (FileStream fs = new FileStream("To-do.xml", FileMode.Truncate))
            {
                formatter.Serialize(fs, ObjectToSerialize);
            }
        }

    }
}
