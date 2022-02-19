using System;
using System.Collections.Generic;
using GeometryFigures.Figures;

namespace GeometryFigures
{
    //Тип фигуры
    public enum TypeFigure
    {
        Circle,//Окружность
        Rectangle,//Прямоугольник
        Triangle//Треугольник
    }
    //Класс набора фигур
    public class ListFigures
    {
        List<IFigure> figures;//Список фигур
        Serializer serialization;//Объект управления сериализацией
        public List<IFigure> Figures => figures;
        public ListFigures()
        {
            figures = new List<IFigure>();
            serialization = new Serializer();
        }
        //Метод добавления фигур
        public void Add(IFigure value)
        {
            if(value==null)
            {
                throw new ArgumentException("Невозможно добавить в список фигур значение null!");
            }
            figures.Add(value);
        }
        //Метод удаления фигур по номеру
        public void Remove(int number)
        {
            if(number<0 || number>=figures.Count)
            {
                throw new ArgumentException("Номер удаляемой фигуры находится в недопустимом диапазоне!");
            }
            figures.RemoveAt(number);
        }
        //Метод сохранения набора фигур в файл
        public void Save(string url)
        {
            serialization.Save(figures, url);
        }
        //Метод загрузки набора фигур из файла
        public void Load(string url)
        {
            figures = serialization.Load(url);
        }
        //Метод поиска фигур по их типу
        public List<IFigure> Search(Type type_object)
        {
            List<IFigure> search_list = new List<IFigure>();
            foreach (var obj in figures)
            {
                if (obj.GetType() == type_object)
                {
                    search_list.Add(obj);
                }
            }
            return search_list;
        }
        //Метод поиска фигур по их характеристикам
        public List<IFigure> Search(IFigure figure)
        {
            List<IFigure> search_list = new List<IFigure>();
            if (figure != null)
            {
                foreach (var obj in figures)
                {
                    if (Compare(figure, obj))
                    {
                        search_list.Add(obj);
                    }
                }
            }
            return search_list;
        }
        //Метод поиска фигур по их площади
        public List<IFigure> Search(double square)
        {
            if (square<0)
            {
                throw new ArgumentException("Аргумент поиска меньше 0. Поиск невозможен.");
            }
            List<IFigure> search_list = new List<IFigure>();
            foreach (var obj in figures)
            {
                if (obj.Square() == square)
                {
                    search_list.Add(obj);
                }
            }
            return search_list;
        }
        //Метод сравнения характерик фигур
        bool Compare(IFigure figure1, IFigure figure2)
        {
            bool result = false;
            if (figure1.GetType() == figure2.GetType())
            {
                switch (figure1)
                {
                    case Circle c://Сравнение окружностей
                        result = c.Compare((Circle)figure2);
                        break;
                    case Rectangle r://Сравнение прямоугольников
                        result = r.Compare((Rectangle)figure2);
                        break;
                    case Triangle t://Сравнение треугольников
                        result = t.Compare((Triangle)figure2);
                        break;
                }
            }
            return result;
        }
    }
}
