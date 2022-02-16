using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace GeometryFigures
{
    //Класс, осуществляющий сериализацию данных в формате .xml
    public class Serializer
    {
        NetDataContractSerializer serializer;
        public Serializer()
        {
            serializer = new NetDataContractSerializer();
        }
        //Метод сериализации данных
        public void Save(List<Figure> obj, string url)
        {
            //Определение настроек xml файла
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;
            //Создание .xml файла
            XmlWriter writer = XmlWriter.Create(url, setting);
            //Сериализация
            serializer.WriteObject(writer, obj);
            writer.Close();
        }
        //Метод десериализации данных
        public List<Figure> Load(string url)
        {
            //Окрытие .xml файла
            XmlReader reader = XmlReader.Create(url);
            //Десериализация
            List<Figure> obj = (List<Figure>)serializer.ReadObject(reader);
            reader.Close();
            return obj;
        }
    }
}
