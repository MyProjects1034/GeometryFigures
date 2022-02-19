using System;
using NUnit.Framework;
using GeometryFigures;

namespace UnitTests
{
    [TestFixture]
    class ValidationClass_Tests
    {
        /// <summary>
        /// Тест проверки исключения при вводе некорректных значений
        /// </summary>
        /// <param name="value"></param>
        [Test]
        [Category("Проверка ошибок")]
        [TestCase("Number",TestName ="Проверка ввода нечислового значения")]
        [TestCase("", TestName = "Проверка ввода пустой строки")]
        public void TestTryParseError(string value)
        {
            Assert.Catch<ArgumentException>(() => ValidationClass.TryParse("Value", value));
        }
        /// <summary>
        /// Тест преобразования строки в число
        /// </summary>
        /// <param name="value"></param>
        [Test]
        [Category("Проверка методов")]
        [TestCase("-100", TestName = "Преобразование отрицательного целого числа")]
        [TestCase("-100,56", TestName = "Преобразование отрицательного дробного числа")]
        [TestCase("0", TestName = "Преобразование значения 0")]
        [TestCase("100", TestName = "Преобразование положительного целого числа")]
        [TestCase("100,56", TestName = "Преобразование положительного дробного числа")]
        public void TestTryParse(string value)
        {
            ValidationClass.TryParse("Value", value);
        }
    }
}
