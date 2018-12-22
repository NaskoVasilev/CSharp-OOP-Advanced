using IntegersDatabase;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace DatabseTests
{
    [TestFixture]
    public class IntegerDatabaseTests
    {
        [Test]
        public void EmptyConstructorShouldInitializeInnerArray()
        {
            Database db = new Database();
            Type type = typeof(Database);

            int[] innerData = (int[])this.GetFieldInfo("data").GetValue(db);

            Assert.AreEqual(innerData.Length, 16);
        }

        [Test]
        [TestCase(new int[2] { 12, 15 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldAddElementsToInnerArray(int[] elements)
        {
            Database db = new Database(elements);

            int[] actualValue = db.Fetch();

            Assert.That(actualValue, Is.EquivalentTo(elements));
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchMethodShouldRetunInnerElements(int[] elements)
        {
            Database db = new Database(elements);

            Assert.That(db.Fetch(), Is.EquivalentTo(elements));
        }

        [Test]
        public void FetchMethodShouldRetunInnerElementsWithInitialEmptyDatabase()
        {
            Database db = new Database();

            for (int i = 0; i < 5; i++)
            {
                db.Add(i);
            }

            Assert.That(db.Fetch(), Is.EquivalentTo(new int[] { 0, 1, 2, 3, 4 }));
        }

        [Test]
        public void ConstructorShouldThrowInvalidOperationExceptionWithMoreElements()
        {
            int[] elements = Enumerable.Range(1, 17).ToArray();

            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 15, 15, 25 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddMethodShouldWorkCorrectly(int[] elements)
        {
            Database db = new Database();

            for (int i = 0; i < elements.Length; i++)
            {
                db.Add(elements[i]);
            }

            int[] actualValue = db.Fetch();

            Assert.That(actualValue, Is.EquivalentTo(elements));
        }

        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionWhenDatbaseIsFull()
        {
            int[] array = Enumerable.Range(1, 15).ToArray();
            Database db = new Database(array);
            db.Add(15);

            Assert.Throws<InvalidOperationException>(() => db.Add(152));
        }

        [Test]
        [TestCase(2)]
        [TestCase(1)]
        [TestCase(5)]
        public void RemoveMethodShouldWorkCorrectly(int count)
        {
            int[] elements = Enumerable.Range(1, 5).ToArray();
            Database db = new Database(elements);

            for (int i = 0; i < count; i++)
            {
                db.Remove();
            }

            int[] actualValue = db.Fetch();
            int[] expectedValue = elements.Take(elements.Length - count).ToArray();

            Assert.That(actualValue, Is.EquivalentTo(expectedValue));
        }

        [Test]
        public void RemoveMethodShouldThrowInvalidOperationExceptionWhenDatbaseIsEmpty()
        {
            Database db = new Database();
            db.Add(15);
            db.Remove();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void AddAndRemoveUsedTogetherMethodsShouldWorkCorrect()
        {
            Database database = new Database();

            for (int i = 1; i <= 10; i++)
            {
                database.Add(i);
            }

            for (int i = 0; i < 5; i++)
            {
                database.Remove();
            }

            Assert.That(database.Fetch(), Is.EquivalentTo(new int[] { 1, 2, 3, 4, 5 }));
        }

        private FieldInfo GetFieldInfo(string fieldName)
        {
            Type type = typeof(Database);

            return type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        }
    }
}
