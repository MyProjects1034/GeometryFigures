using System;
using NUnit.Framework;
using GeometryFigures;
using GeometryFigures.Figures;
using System.Collections.Generic;
using UnitTests.TestData;

namespace UnitTests
{
    [TestFixture]
    class ListFigures_Tests
    {
        //Объект проверки
        ListFigures list = new ListFigures();

        //Набор фигур для поиска
        static IFigure[] search_figures =
{
            new Rectangle(10,20),new Triangle(50.5,12),new Circle(30)
        };
        /// <summary>
        /// Тест неудачного добавления фигуры (При значении null)
        /// </summary>
        /// <param name="figure"></param>
        [Test]
        [Category("Проверка ошибок")]
        [TestCase(null, TestName = "Добавление null в список фигур")]
        public void TestAddFail(IFigure figure)
        {
            Assert.Catch<ArgumentException>(() => list.Add(figure));
        }
        /// <summary>
        /// Тест добавления фигур
        /// </summary>
        /// <param name="figure"></param>
        [Test]
        [Order(2)]
        [Category("Добавление фигур")]
        [TestCaseSource(typeof(Data), nameof(Data.figures))]
        public void TestAdd(IFigure figure)
        {
            list.Add(figure);
        }
        /// <summary>
        /// Тест удаления фигуры
        /// </summary>
        /// <param name="number"></param>
        [Test]
        [Order(4)]
        [Category("Удаление фигур")]
        [TestCase(0, TestName = "Удаление фигуры по номеру 0")]
        [TestCase(2, TestName = "Удаление фигуры по номеру 2")]
        public void TestRemove(int number)
        {
            list.Remove(number);
        }
        /// <summary>
        /// Тест неудачного удаления фигуры
        /// </summary>
        /// <param name="number"></param>
        [Test]
        [Order(4)]
        [Category("Проверка ошибок")]
        [TestCase(int.MinValue, TestName = "Удаление фигуры по номеру MinValue")]
        [TestCase(-10, TestName = "Удаление фигуры по номеру -10")]
        [TestCase(int.MaxValue, TestName = "Удаление фигуры по номеру MaxValue")]
        [TestCase(5, TestName = "Удаление фигуры по номеру 5")]
        public void TestRemoveFail(int number)
        {
            Assert.Catch<ArgumentException>(() => list.Remove(number));
        }
        /// <summary>
        /// Тест удачного поиска фигур по типу
        /// </summary>
        /// <param name="type"></param>
        [Test]
        [Order(3)]
        [Category("Удачный поиск фигур по типу")]
        public void TestSearchTypeSuccess([Values(typeof(Circle), typeof(Rectangle), typeof(Triangle))] Type type)
        {
            List<IFigure> search_value = list.Search(type);
            Assert.IsNotNull(search_value);
            Assert.Greater(search_value.Count, 0);
        }
        /// <summary>
        /// Тест неудачного поиска фигур по типу
        /// </summary>
        /// <param name="type"></param>
        [Test]
        [Order(1)]
        [Category("Неудачный поиск фигур по типу")]
        public void TestSearchTypeFail([Values(typeof(Circle), typeof(Rectangle), typeof(Triangle))] Type type)
        {
            List<IFigure> search_value = list.Search(type);
            Assert.IsNotNull(search_value);
            Assert.AreEqual(search_value.Count, 0);
        }
        /// <summary>
        /// Тест удачного поиска фигур по значениям
        /// </summary>
        /// <param name="figure"></param>
        [Test]
        [Order(3)]
        [Category("Удачный поиск фигур по значениям")]
        [TestCaseSource(nameof(search_figures))]
        public void SearchValueSuccess(IFigure figure)
        {
            List<IFigure> search_value = list.Search(figure);
            Assert.IsNotNull(search_value);
            Assert.Greater(search_value.Count, 0);
        }
        /// <summary>
        /// Тест неудачного поиска фигур по значениям
        /// </summary>
        /// <param name="figure"></param>
        [Test]
        [Order(1)]
        [Category("Неудачный поиск фигур по значениям")]
        [TestCaseSource(nameof(search_figures))]
        public void SearchValueFail(IFigure figure)
        {
            List<IFigure> search_value = list.Search(figure);
            Assert.IsNotNull(search_value);
            Assert.AreEqual(search_value.Count, 0);
        }
        /// <summary>
        /// Тест удачного поиска фигур по площади
        /// </summary>
        /// <param name="square"></param>
        [Test]
        [Order(3)]
        [Category("Удачный поиск фигур по площади")]
        public void SearchValueSuccess([Values(2827.4328, 200, 303)] double square)
        {
            List<IFigure> search_value = list.Search(square);
            Assert.IsNotNull(search_value);
            Assert.Greater(search_value.Count, 0);
        }
        /// <summary>
        /// Тест неудачного поиска фигур по площади
        /// </summary>
        /// <param name="square"></param>
        [Test]
        [Order(1)]
        [Category("Неудачный поиск фигур по площади")]
        public void SearchValueFail([Values(2827.43, 200, 303)] double square)
        {
            List<IFigure> search_value = list.Search(square);
            Assert.IsNotNull(search_value);
            Assert.AreEqual(search_value.Count, 0);
        }
        /// <summary>
        /// Тест поиска фигур по площади c вводом некорректных данных
        /// </summary>
        /// <param name="square"></param>
        [Test]
        [Category("Проверка ошибок")]
        [TestCase(int.MinValue, TestName = "Поиск по отрицательной площади MinValue")]
        [TestCase(-1000, TestName = "Поиск по отрицательной площади -1000")]
        [TestCase(-10, TestName = "Поиск по отрицательной площади -10")]
        public void SearchValueError(double square)
        {
            Assert.Catch<ArgumentException>(() => list.Search(square));
        }
    }
}
