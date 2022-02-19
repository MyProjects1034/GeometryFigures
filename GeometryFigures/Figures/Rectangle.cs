using System;
using System.Runtime.Serialization;

namespace GeometryFigures.Figures
{
    //ПРЯМОУГОЛЬНИК
    [DataContract]
    public class Rectangle : ValidationClass, IFigure
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
            if (figure == null)
            {
                throw new ArgumentException("Отсутствует объект сравнения. Экземпляр класса равен null.");
            }
            if (this.Lenght == figure.Lenght &&
                this.Width == figure.Width)
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
            if (Square() == double.PositiveInfinity)
            {
                throw new ArgumentException("Радиус слишком большой. Выберите значение меньше");
            }
        }
    }
}
