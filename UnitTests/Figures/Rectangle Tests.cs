using NUnit;
using NUnit.Framework;
using GeometryFigures.Figures;
using System;

namespace UnitTests.Figures
{
    [TestFixture]
    class Rectangle_Tests
    {
        /// <summary>
        /// Тест обработки исключений при создании прямоугольника с некоррентными числовыми значениями
        /// </summary>
        /// <param name="Длина"></param>
        /// <param name="Ширина"></param>
        [Test]
        [Category("Проверка ошибок")]
        [TestCase(double.MinValue,10, TestName = "Обработка исключения при создании прямоугольника с длиной MinValue")]
        [TestCase(10, double.MinValue, TestName = "Обработка исключения при создании прямоугольника с шириной MinValue")]
        [TestCase(-10,45.5, TestName = "Обработка исключения при создании прямоугольника с длиной -10")]
        [TestCase(15.2, -10, TestName = "Обработка исключения при создании прямоугольника с шириной -10")]
        [TestCase(double.MaxValue,10, TestName = "Обработка исключения при создании прямоугольника с длиной MaxValue")]
        [TestCase(10, double.MaxValue, TestName = "Обработка исключения при создании прямоугольника с шириной MaxValue")]
        public void TestErrorCreate(double lenght,double width)
        {
            Assert.Catch<ArgumentException>(() => new Rectangle(lenght,width));
        }
        /// <summary>
        /// Тестирование создания объекта "Прямоугольник"
        /// </summary>
        /// <param name="Длина"></param>
        /// <param name="Ширина"></param>
        [Test]
        [Category("Создание объекта")]
        [TestCase(0,0, TestName = "Создание прямоугольника с длиной и шириной равными 0")]
        [TestCase(0, 45.6, TestName = "Создание прямоугольника с длиной 0 и шириной больше 0")]
        [TestCase(47.1, 0, TestName = "Создание прямоугольника с длиной больше 0 и шириной равной 0")]
        [TestCase(10.5,58.26, TestName = "Создание прямоугольника с длиной и шириной больше 0")]
        public void TestCreate(double lenght, double width)
        {
            new Rectangle(lenght,width);
        }
        /// <summary>
        /// Тестирование сравнения характеристик прямоугольников
        /// </summary>
        /// <param name="Длина 1-го прямоугольника"></param>
        /// <param name="Ширина 1-го прямоугольника"></param>
        /// <param name="Длина 2-го прямоугольника"></param>
        /// <param name="Ширина 2-го прямоугольника"></param>
        /// <returns></returns>
        [Test]
        [Category("Проверка методов")]
        [TestCase(0, 0,0,0, ExpectedResult = true, TestName = "Сравнение прямоугольников с нулевыми радиусами")]
        [TestCase(0, 10,0,10, ExpectedResult = true, TestName = "Сравнение прямоугольников, у которых длина равна 0")]
        [TestCase(10, 0, 10,0, ExpectedResult = true, TestName = "Сравнение прямоугольников, у которых ширина равна 0")]
        [TestCase(25.7, 54.45, 14.5, 78.62, ExpectedResult = false, TestName = "Сравнение разных прямоугольников")]
        [TestCase(25.7, 54.45, 25.7, 54.45, ExpectedResult = true, TestName = "Сравнение одинаковых прямоугольников")]
        public bool TestCompare(double lenght1, double width1, double lenght2, double width2)
        {
            Rectangle r1 = new Rectangle(lenght1, width1);
            Rectangle r2 = new Rectangle(lenght2, width2);
            return r1.Compare(r2);
        }
        /// <summary>
        /// Тест обработки исключения сравнения с объектом null
        /// </summary>
        [Test]
        [Category("Проверка ошибок")]
        [TestCase(TestName = "Тест обработки исключения сравнения с объектом null")]
        public void TestCompareNullArgument()
        {
            Rectangle r1 = new Rectangle(10,10);
            Rectangle r2 = null;
            Assert.Catch<ArgumentException>(() => r1.Compare(r2));
        }
        /// <summary>
        /// Тестирование вычисления площади прямоугольника
        /// </summary>
        /// <param name="Длина"></param>
        /// <param name="Ширина"></param>
        /// <returns></returns>
        [Test]
        [Category("Проверка методов")]
        [TestCase(0, 0,ExpectedResult =0, TestName = "Вычисление площади прямоугольника с длиной и шириной равными 0")]
        [TestCase(0, 45.6, ExpectedResult = 0, TestName = "Вычисление площади прямоугольника с длиной 0 и шириной больше 0")]
        [TestCase(47.1, 0, ExpectedResult = 0, TestName = "Вычисление площади прямоугольника с длиной больше 0 и шириной 0")]
        [TestCase(10.5, 58.26, ExpectedResult = 611.73, TestName = "Вычисление площади прямоугольника с длиной и шириной больше 0")]
        public double Square(double lenght, double width)
        {
            Rectangle rectangle = new Rectangle(lenght, width);
            return Math.Round(rectangle.Square(), 2);
        }
    }
}
