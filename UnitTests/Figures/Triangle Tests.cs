using NUnit;
using NUnit.Framework;
using GeometryFigures.Figures;
using System;

namespace UnitTests.Figures
{
    [TestFixture]
    class Triangle_Tests
    {
        /// <summary>
        /// Тест обработки исключений при создании треугольника с некоррентными числовыми значениями
        /// </summary>
        /// <param name="Высота"></param>
        /// <param name="Основание"></param>
        [Test]
        [Category("Проверка ошибок")]
        [TestCase(double.MinValue, 10, TestName = "Обработка исключения при создании треугольника с высотой MinValue")]
        [TestCase(10, double.MinValue, TestName = "Обработка исключения при создании треугольника с основанием MinValue")]
        [TestCase(-10, 45.5, TestName = "Обработка исключения при создании треугольника с высотой -10")]
        [TestCase(15.2, -10, TestName = "Обработка исключения при создании треугольника с основанием -10")]
        [TestCase(double.MaxValue, 10, TestName = "Обработка исключения при создании треугольника с высотой MaxValue")]
        [TestCase(10, double.MaxValue, TestName = "Обработка исключения при создании треугольника с основанием MaxValue")]
        public void TestErrorCreate(double height, double base_value)
        {
            Assert.Catch<ArgumentException>(() => new Triangle(height, base_value));
        }
        /// <summary>
        /// Тестирование создания объекта "треугольник"
        /// </summary>
        /// <param name="Высота"></param>
        /// <param name="Основание"></param>
        [Test]
        [Category("Создание объекта")]
        [TestCase(0, 0, TestName = "Создание треугольника с высотой и основанием равными 0")]
        [TestCase(0, 45.6, TestName = "Создание треугольника с высотой 0 и основанием больше 0")]
        [TestCase(47.1, 0, TestName = "Создание треугольника с высотой больше 0 и основанием равной 0")]
        [TestCase(10.5, 58.26, TestName = "Создание треугольника с высотой и основанием больше 0")]
        public void TestCreate(double height, double base_value)
        {
            new Triangle(height, base_value);
        }
        /// <summary>
        /// Тестирование сравнения характеристик треугольников
        /// </summary>
        /// <param name="Высота 1-го треугольника"></param>
        /// <param name="Основание 1-го треугольника"></param>
        /// <param name="Высота 2-го треугольника"></param>
        /// <param name="Основание 2-го треугольника"></param>
        /// <returns></returns>
        [Test]
        [Category("Проверка методов")]
        [TestCase(0, 0, 0, 0, ExpectedResult = true, TestName = "Сравнение треугольников с нулевыми радиусами")]
        [TestCase(0, 10, 0, 10, ExpectedResult = true, TestName = "Сравнение треугольников, у которых длина равна 0")]
        [TestCase(10, 0, 10, 0, ExpectedResult = true, TestName = "Сравнение треугольников, у которых ширина равна 0")]
        [TestCase(25.7, 54.45, 14.5, 78.62, ExpectedResult = false, TestName = "Сравнение разных треугольников")]
        [TestCase(25.7, 54.45, 25.7, 54.45, ExpectedResult = true, TestName = "Сравнение одинаковых треугольников")]
        public bool TestCompare(double height1, double base_value1, double height2, double base_value2)
        {
            Triangle r1 = new Triangle(height1, base_value1);
            Triangle r2 = new Triangle(height2, base_value2);
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
            Triangle r1 = new Triangle(10, 10);
            Triangle r2 = null;
            Assert.Catch<ArgumentException>(() => r1.Compare(r2));
        }
        /// <summary>
        /// Тестирование вычисления площади треугольника
        /// </summary>
        /// <param name="Высота"></param>
        /// <param name="Основание"></param>
        /// <returns></returns>
        [Test]
        [Category("Проверка методов")]
        [TestCase(0, 0, ExpectedResult = 0, TestName = "Вычисление площади треугольника с высотой и основанием равными 0")]
        [TestCase(0, 45.6, ExpectedResult = 0, TestName = "Вычисление площади треугольника с высотой 0 и основанием больше 0")]
        [TestCase(47.1, 0, ExpectedResult = 0, TestName = "Вычисление площади треугольника с высотой больше 0 и основанием 0")]
        [TestCase(10.5, 58.26, ExpectedResult = 305.86, TestName = "Вычисление площади треугольника с высотой и основанием больше 0")]
        public double Square(double height, double base_value)
        {
            Triangle rectangle = new Triangle(height, base_value);
            return Math.Round(rectangle.Square(), 2);
        }
    }
}
