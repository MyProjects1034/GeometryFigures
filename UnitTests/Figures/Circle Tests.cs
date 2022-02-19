using NUnit.Framework;
using GeometryFigures.Figures;
using System;

namespace UnitTests.Figures
{
    [TestFixture]
    class Circle_Tests
    {
        /// <summary>
        /// Тест обработки исключений при создании окружности с некоррентными числовыми значениями
        /// </summary>
        /// <param name="radius"></param>
        [Test]
        [Category("Проверка ошибок")]
        [TestCase(double.MinValue, TestName = "Обработка исключения при создании окружности с радиусом MinValue")]
        [TestCase(-10, TestName = "Обработка исключения при создании окружности с радиусом -10")]
        [TestCase(double.MaxValue, TestName = "Обработка исключения при создании окружности с радиусом MaxValue")]
        public void TestErrorCreate(double radius)
        {
            Assert.Catch<ArgumentException>(() => new Circle(radius));
        }
        /// <summary>
        /// Тестирование создания объекта "Окружность"
        /// </summary>
        /// <param name="radius"></param>
        [Test]
        [Category("Создание объекта")]
        [TestCase(0, TestName = "Создание окружности с радиусом 0")]
        [TestCase(10.5, TestName = "Создание окружности с радиусом 10,5")]
        public void TestCreate(double radius)
        {
            new Circle(radius);
        }
        /// <summary>
        /// Тестирование сравнения характеристик окружностей
        /// </summary>
        /// <param name="Радиус первой окружности"></param>
        /// <param name="Радиус второй окружности"></param>
        /// <returns></returns>
        [Test]
        [Category("Проверка методов")]
        [TestCase(0,0, ExpectedResult =true,TestName ="Сравнение окружностей с нулевыми радиусами")]
        [TestCase(0, 10, ExpectedResult = false, TestName = "Сравнение окружностей, у одной из которых радиус 0")]
        [TestCase(25.7, 54.45, ExpectedResult = false, TestName = "Сравнение разных окружностей")]
        [TestCase(25.7, 25.7, ExpectedResult = true, TestName = "Сравнение одинаковых окружностей")]
        public bool TestCompare(double radius1,double radius2)
        {
            Circle c1 = new Circle(radius1);
            Circle c2 = new Circle(radius2);
            return c1.Compare(c2);
        }
        /// <summary>
        /// Тест обработки исключения сравнения с объектом null
        /// </summary>
        [Test]
        [Category("Проверка ошибок")]
        [TestCase(TestName ="Тест обработки исключения сравнения с объектом null")]
        public void TestCompareNullArgument()
        {
            Circle c1 = new Circle(10);
            Circle c2 = null;
            Assert.Catch<ArgumentException>(() => c1.Compare(c2));
        }
        /// <summary>
        /// Тестирование вычисления площади окружности
        /// </summary>
        /// <param name="Радиус"></param>
        /// <returns></returns>
        [Test]
        [Category("Проверка методов")]
        [TestCase(0, ExpectedResult = 0, TestName = "Вычисление площади окружности с нулевым радиусом")]
        [TestCase(25.7,  ExpectedResult = 2074.99, TestName = "Вычисление площади окружности с положительным радиусом")]
        public double Square(double radius)
        {
            Circle circle = new Circle(radius);
            return Math.Round(circle.Square(),2);
        }
    }
}
