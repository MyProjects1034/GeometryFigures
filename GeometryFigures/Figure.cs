using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GeometryFigures
{
    //Тип фигуры
    public enum TypeFigure
    {
        Circle,//Окружность
        Rectangle,//Прямоугольник
        Triangle//Треугольник
    }
    //Интерфейс фигуры
    public interface Figure
    {
        string Data { get; }//Строковое представление данных
        string SquareString { get; }//Строковое представление площади
        string Type { get; }//Строковое представление типа фигуры
        double Square();//Рассчет площади
    }

    //Абстрактный класс валидации
    [DataContract]
    public abstract class ValidationClass
    {
        //Метод проверки вводимых данных
        public abstract void Validation();
        //Метод проверки пложительных значений
        public void CheckPosValue(string name,double value)
        {
            if(value<0)
            {
                throw new ArgumentException(String.Format("Значение <{0}> должно быть больше нуля!", name));
            }
        }
        //Метод преобразования строки в число
        public static double TryParse(string name, string value)
        {
            if(value=="")
            {
                throw new ArgumentException(String.Format("Введите значение <{0}> !", name));
            }
            double result;
            if (!double.TryParse(value, out result))
            {
                throw new ArgumentException(String.Format("Значение <{0}> введено некорректно!", name));
            }
            return result;
        }
    }

    //ОКРУЖНОСТЬ
    [DataContract]
    public class Circle: ValidationClass, Figure
    {
        const double P = 3.141592;//Число ПИ
        [DataMember] double Radius;//Радиус
        public Circle(double radius)
        {
            this.Radius = radius;
            Validation();
        }
        //Строковое представление данных
        public string Data => "Радиус = " + Radius;
        //Строковое представление площади
        public string SquareString => Square().ToString();
        //Строковое представление типа фигуры
        public string Type => "Окружность";

        //Метод сравнения характеристик фигур (окружностей)
        public bool Compare(Circle figure)
        {
            if (this.Radius == figure.Radius)
            {
                return true;
            }
            else { return false; }
        }
        //Метод вычисления площади
        public double Square()
        {
            return P * Radius * Radius;
        }
        //Метод проверки значения характеристик фигур
        public override void Validation()
        {
            CheckPosValue("Радиус", Radius);
        }
    }
    //ПРЯМОУГОЛЬНИК
    [DataContract]
    public class Rectangle: ValidationClass,Figure
    {
        [DataMember] double Lenght;//Длина
        [DataMember] double Width;//Ширина
        public Rectangle(double lenght, double width)
        {
            this.Lenght = lenght;
            this.Width = width;
            Validation();
        }
        //Строковое представление данных
        public string Data => string.Format("Длина = {0}; Ширина: {1}", Lenght, Width);
        //Строковое представление площади
        public string SquareString => Square().ToString();
        //Строковое представление типа фигуры
        public string Type => "Прямоугольник";
        //Метод сравнения характеристик фигур (прямоугольников)
        public bool Compare(Rectangle figure)
        {
            if (this.Lenght == figure.Lenght &&
                this.Width==figure.Width)
            {
                return true;
            }
            else { return false; }
        }
        //Метод вычисления площади
        public double Square()
        {
            return Lenght * Width;
        }
        //Метод проверки значения характеристик фигур
        public override void Validation()
        {
            CheckPosValue("Ширина", Lenght);
            CheckPosValue("Высота", Width);
        }
    }
    //ТРЕУГОЛЬНИК
    [DataContract]
    public class Triangle: ValidationClass, Figure
    {
        [DataMember] double Height;//Высота
        [DataMember] double Base;//Основание
        public Triangle(double height, double Base)
        {
            this.Height = height;
            this.Base = Base;
            Validation();
        }
        //Строковое представление данных
        public string Data => string.Format("Высота = {0}; Основание: {1}", Height, Base);
        //Строковое представление площади
        public string SquareString => Square().ToString();
        //Строковое представление типа фигуры
        public string Type => "Треугольник";
        //Метод сравнения характеристик фигур (треугольников)
        public bool Compare(Triangle figure)
        {
            if (this.Base == figure.Base &&
                this.Height == figure.Height)
            {
                return true;
            }
            else { return false; }
        }
        //Метод вычисления площади
        public double Square()
        {
            return Height * Base / 2;
        }
        //Метод проверки значения характеристик фигур
        public override void Validation()
        {
            CheckPosValue("Высота", Height);
            CheckPosValue("Основание", Base);
        }
    }
    //Класс набора фигур
    public class ListFigures
    {
        List<Figure> figures;//Список фигур
        Serializer serialization;//Объект управления сериализацией
        public List<Figure> Figures => figures;
        public ListFigures()
        {
            figures = new List<Figure>();
            serialization = new Serializer();
        }
        //Метод добавления фигур
        public void Add(Figure value)
        {
            figures.Add(value);
        }
        //Метод удаления фигур по номеру
        public void Remove(int number)
        {
            figures.RemoveAt(number);
        }
        //Метод сохранения набора фигур в файл
        public void Save(string url)
        {
            serialization.Save(figures,url);
        }
        //Метод загрузки набора фигур из файла
        public void Load(string url)
        {
            figures = serialization.Load(url);
        }
        //Метод поиска фигур по их типу
        public List<Figure> Search(Type type_object)
        {
            List<Figure> search_list = new List<Figure>();
            foreach (var obj in figures)
            {
                if(obj.GetType()==type_object)
                {
                    search_list.Add(obj);
                }
            }
            return search_list;
        }
        //Метод поиска фигур по их характеристикам
        public List<Figure> Search(Figure figure)
        {
            List<Figure> search_list = new List<Figure>();
            foreach (var obj in figures)
            {
                if (Compare(figure,obj))
                {
                    search_list.Add(obj);
                }
            }
            return search_list;
        }
        //Метод поиска фигур по их площади
        public List<Figure> Search(double square)
        {
            List<Figure> search_list = new List<Figure>();
            foreach (var obj in figures)
            {
                if (obj.Square()== square)
                {
                    search_list.Add(obj);
                }
            }
            return search_list;
        }
        //Метод сравнения характерик фигур
        bool Compare(Figure figure1,Figure figure2)
        {
            bool result = false;
            if(figure1.GetType()==figure2.GetType())
            {
                switch (figure1)
                {
                    case Circle c://Сравнение окружностей
                        result=c.Compare((Circle)figure2);
                        break;
                    case Rectangle r://Сравнение прямоугольников
                        result=r.Compare((Rectangle)figure2);
                        break;
                    case Triangle t://Сравнение треугольников
                        result=t.Compare((Triangle)figure2);
                        break;
                }
            }
            return result;
        }
    }
}
