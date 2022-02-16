using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace GeometryFigures
{
    public enum TypeFigure
    {
        Circle,
        Rectangle,
        Triangle
    }
    public interface Figure
    {
        string Data { get; }
        string SquareString { get; }

        string Type { get; }
        double Square();//Рассчет площади
    }

    [DataContract]
    public abstract class ValidationClass
    {
        public abstract void Validation();//Проверка вводимых данных
        public void CheckPosValue(string name,double value)
        {
            if(value<0)
            {
                throw new ArgumentException(String.Format("Значение <{0}> должно быть больше нуля!", name));
            }
        }
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

        public string Data => "Радиус = " + Radius;

        public string SquareString => Square().ToString();

        public string Type => "Окружность";

        public bool Compare(Circle figure)
        {
            if (this.Radius == figure.Radius)
            {
                return true;
            }
            else { return false; }
        }

        public double Square()
        {
            return P * Radius * Radius;
        }

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

        public string Data => string.Format("Длина = {0}; Ширина: {1}", Lenght, Width);

        public string SquareString => Square().ToString();

        public string Type => "Прямоугольник";

        public bool Compare(Rectangle figure)
        {
            if (this.Lenght == figure.Lenght &&
                this.Width==figure.Width)
            {
                return true;
            }
            else { return false; }
        }
        public double Square()
        {
            return Lenght * Width;
        }
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

        public string Data => string.Format("Высота = {0}; Основание: {1}", Height, Base);

        public string SquareString => Square().ToString();

        public string Type => "Треугольник";

        public bool Compare(Triangle figure)
        {
            if (this.Base == figure.Base &&
                this.Height == figure.Height)
            {
                return true;
            }
            else { return false; }
        }
        public double Square()
        {
            return Height * Base / 2;
        }
        public override void Validation()
        {
            CheckPosValue("Высота", Height);
            CheckPosValue("Основание", Base);
        }
    }
    public class ListFigures
    {
        List<Figure> figures;
        Serializer serialization;
        public List<Figure> Figures => figures;
        public ListFigures()
        {
            figures = new List<Figure>();
            serialization = new Serializer();
        }
        public void Add(Figure value)
        {
            figures.Add(value);
        }
        public void Remove(int number)
        {
            figures.RemoveAt(number);
        }
        public void Save(string url)
        {
            serialization.Save(figures,url);
        }
        public void Load(string url)
        {
            figures = (List<Figure>)serialization.Load(url);
        }
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
        bool Compare(Figure figure1,Figure figure2)
        {
            bool result = false;
            if(figure1.GetType()==figure2.GetType())
            {
                switch (figure1)
                {
                    case Circle c:
                        result=c.Compare((Circle)figure2);
                        break;
                    case Rectangle r:
                        result=r.Compare((Rectangle)figure2);
                        break;
                    case Triangle t:
                        result=t.Compare((Triangle)figure2);
                        break;
                }
            }
            return result;
        }
    }
}
