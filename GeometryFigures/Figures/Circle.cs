using System;
using System.Runtime.Serialization;

namespace GeometryFigures.Figures
{
    //ОКРУЖНОСТЬ
    [DataContract]
    public class Circle : ValidationClass, IFigure
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
            if(figure==null)
            {
                throw new ArgumentException("Отсутствует объект сравнения. Экземпляр класса равен null.");
            }
            if (Math.Round(this.Radius,2) == Math.Round(figure.Radius,2))
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
            if (Square() == double.PositiveInfinity)
            {
                throw new ArgumentException("Радиус слишком большой. Выберите значение меньше");
            }
        }
    }
}
