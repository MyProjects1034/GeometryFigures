using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace GeometryFigures
{
    public class Serializer
    {
        NetDataContractSerializer serializer;
        public Serializer()
        {
            serializer = new NetDataContractSerializer();
        }
        public void Save(List<Figure> obj, string url)
        {
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;
            XmlWriter writer = XmlWriter.Create(url, setting);
            serializer.WriteObject(writer, obj);
            writer.Close();
        }
        public List<Figure> Load(string url)
        {
            XmlReader reader = XmlReader.Create(url);
            List<Figure> obj = (List<Figure>)serializer.ReadObject(reader);
            reader.Close();
            return obj;
        }
    }
}
