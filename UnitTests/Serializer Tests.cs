using System;
using NUnit.Framework;
using System.Collections.Generic;
using UnitTests.TestData;
using GeometryFigures.Figures;
using GeometryFigures;
using System.IO;

namespace UnitTests
{
    [TestFixture]
    class Serializer_Tests
    {
        Serializer serializer = new Serializer();
        string url = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.fig");
        /// <summary>
        /// Сохранение списка фигур
        /// </summary>
        [Test]
        [Order(1)]
        [Category("Сохранение списка фигур")]
        public void TestSave()
        {
            serializer.Save(new List<IFigure>(Data.figures), url);
        }
        /// <summary>
        /// Сохранение пустого списка фигур
        /// </summary>
        [Test]
        [Category("Сохранение списка фигур")]
        public void TestSaveEmpty()
        {
            Assert.Catch<ArgumentException>(() => serializer.Save(new List<IFigure>(), url));
        }
        /// <summary>
        /// Попытка сохранения значения null
        /// </summary>
        [Test]
        [Category("Сохранение списка фигур")]
        public void TestSaveNull()
        {
            Assert.Catch<ArgumentException>(() => serializer.Save(null, url));
        }
        /// <summary>
        /// Попытка сохранения списка фигур с некорректным url
        /// </summary>
        [Test]
        [Category("Сохранение списка фигур")]
        public void TestSaveIncorrectUrl()
        {
            Assert.Catch<Exception>(() => serializer.Save(new List<IFigure>(Data.figures), @"/\nothing/\"));
        }
        /// <summary>
        /// Загрузка списка фигур
        /// </summary>
        [Test]
        [Order(2)]
        [Category("Загрузка списка фигур")]
        public void TestLoadSuccess()
        {
            Assert.IsNotNull(serializer.Load(url));
        }
        /// <summary>
        /// Попытка загрузки списка фигур с некорректным url
        /// </summary>
        [Test(Description ="123")]
        [Order(2)]
        [Category("Загрузка списка фигур")]
        public void TestLoadFail()
        {
            Assert.Catch<Exception>(() => serializer.Load(@"/\nothing/\"));
        }
    }
}
