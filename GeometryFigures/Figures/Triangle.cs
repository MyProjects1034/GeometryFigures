using System;
using System.Runtime.Serialization;

namespace GeometryFigures.Figures
{
    //ТРЕУГОЛЬНИК
    [DataContract]
    public class Triangle : ValidationClass, IFigure
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
            if (figure == null)
            {
                throw new ArgumentException("Отсутствует объект сравнения. Экземпляр класса равен null.");
            }
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
            if (Square() == double.PositiveInfinity)
            {
                throw new ArgumentException("Радиус слишком большой. Выберите значение меньше");
            }
        }
    }
}
