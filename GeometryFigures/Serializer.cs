using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;
using GeometryFigures.Figures;

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
        public void Save(List<IFigure> obj, string url)
        {
            if(obj==null)
            {
                throw new ArgumentException("Аргумент списка фигур имеет null!");
            }
            if (obj.Count == 0)
            {
                throw new ArgumentException("Отсутствует список фигур для сохранения.");
            }
            try
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
            catch(Exception error)
            {
                throw new Exception("Ошибка при сохранении файла");
            }
        }
        //Метод десериализации данных
        public List<IFigure> Load(string url)
        {
            if (!File.Exists(url))
            {
                throw new ArgumentException(string.Format("Файла {0} не существует", url));
            }
            try
            {
                //Окрытие .xml файла
                XmlReader reader = XmlReader.Create(url);
                //Десериализация
                List<IFigure> obj = (List<IFigure>)serializer.ReadObject(reader);
                reader.Close();
                return obj;
            }
            catch
            {
                throw new Exception("Ошибка при открытии файла");
            }
        }
    }
}
