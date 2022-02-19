using System;
using System.Runtime.Serialization;

namespace GeometryFigures
{
    [DataContract]
    public abstract class ValidationClass
    {
        //Метод проверки вводимых данных
        public abstract void Validation();
        //Метод проверки пложительных значений
        public void CheckPosValue(string name, double value)
        {
            if (value < 0)
            {
                throw new ArgumentException(String.Format("Значение <{0}> должно быть больше нуля!", name));
            }
        }
        //Метод преобразования строки в число
        public static double TryParse(string name, string value)
        {
            if (value == "")
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
}
