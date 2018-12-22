using CustomLinkedList;
using NUnit.Framework;
using System;

namespace CustomLinkedListTests
{
    [TestFixture]
    public class CustomLinkedListTests
    {
        private DynamicList<int> list;

        [SetUp]
        public void InitializeDynamicList()
        {
            list = new DynamicList<int>();
        }

        [Test]
        public void InitailCountMustBeZero()
        {
            Assert.AreEqual(0, list.Count, "Initial count is not zero!");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        public void GetElementAtSpecificPositionWithInvalidIndexShouldThrowArgumentOutOfRangeException(int index)
        {
            list.Add(10);
            int element = 0;
            Assert.Throws<ArgumentOutOfRangeException>(() => element = list[index]);
        }

        [Test]
        [TestCase(0, 10)]
        [TestCase(1, 20)]
        [TestCase(2, 30)]
        public void GetElementByIndexShouldReturnTheElemenet(int index, int value)
        {
            AddElements();
            Assert.AreEqual(list[index], value, "Does not get correctly values!");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        public void SetElementAtSpecificPositionWithInvalidIndexShouldThrowArgumentOutOfRangeException(int index)
        {
            list.Add(10);
            int value = 20;
            Assert.Throws<ArgumentOutOfRangeException>(() => list[index] = value, "Does not get correctly values!");
        }

        [Test]
        [TestCase(0, 100)]
        [TestCase(1, 200)]
        [TestCase(2, 300)]
        public void ShouldSetElementAtSpecificIndex(int index, int value)
        {
            AddElements();
            list[index] = value;
            Assert.AreEqual(list[index], value, "Does not set correctly values!");
        }

        [Test]
        [TestCase(new int[] { 12 })]
        [TestCase(new int[] { 12, 15, 55, 5, 45 })]
        public void AddCorrectOneElementWhenListIsEmpty(int[] elements)
        {
            AddElements(elements);

            Assert.That(this.HaveEqualElements(elements), "Does not add correct elements!");
        }

        [Test]
        [TestCase(new int[] { 12 })]
        [TestCase(new int[] { 12, 1, 28, 9, 1, 11, 12 })]
        public void CountShouldIncreaseAfterAddingElements(int[] elements)
        {
            AddElements(elements);
            Assert.AreEqual(list.Count, elements.Length, "Count does not increase after adding elements!");
        }

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        public void RemoveAtShouldThrowArgumentOutOfRangeExceptionWithInvalidIndex(int index)
        {
            list.Add(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(index), "Does not throw error when index is out if range!");
        }

        [Test]
        [TestCase(0)]
        [TestCase(9)]
        [TestCase(5)]
        public void RemoveAddShouldReturnremovedElements(int index)
        {
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            int expectedValue = list[index];
            int actualValue = list.RemoveAt(index);
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void ElementsDoNotChangeTheirOrderAfterRemove()
        {
            for (int i = 1; i <= 7; i++)
            {
                list.Add(i);
            }

            list.RemoveAt(0);
            list.RemoveAt(2);
            list.RemoveAt(4);

            int[] expectedResult = new int[] { 2, 3, 5, 6 };
            Assert.That(HaveEqualElements(expectedResult));
        }

        [Test]
        [TestCase(20)]
        public void RerurnMinusOneWhenListDoesNotContansTheElement(int elemnet)
        {
            list.Add(10);
            int actualValue = list.Remove(elemnet);
            int expectedValue = -1;
            Assert.AreEqual(actualValue, expectedValue);
        }

        [Test]
        [TestCase(10, 0)]
        [TestCase(20, 1)]
        [TestCase(30, 2)]
        public void RemoveShouldReturnIndexOfReturnedElement(int element, int expectedIndex)
        {
            AddElements();
            Assert.AreEqual(list.Remove(element), expectedIndex);
        }

        [Test]
        public void RemoveMethodWotkCorrectlyForInvokes()
        {
            for (int i = 1; i <= 7; i++)
            {
                list.Add(i);
            }

            list.Remove(1);
            list.Remove(4);
            list.Remove(7);

            int[] expectedResult = new int[] { 2, 3, 5, 6 };
            Assert.That(HaveEqualElements(expectedResult));
        }

        [Test]
        public void CountShouldDecreaseWhenRemoveElements()
        {
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            list.Remove(7);
            list.Remove(8);
            list.RemoveAt(5);
            list.RemoveAt(0);

            Assert.AreEqual(list.Count, 6);
        }

        [Test]
        public void IndexOfShouldReturnMinusOneWhenListDoesNotContainsTheElement()
        {
            AddElements();
            Assert.AreEqual(list.IndexOf(100), -1);
        }

        [Test]
        [TestCase(10, 0)]
        [TestCase(20, 1)]
        [TestCase(30, 2)]
        public void IndexOfShouldReturnIndexWhenListContainsTheElement(int element, int expectedIndex)
        {
            AddElements();
            Assert.AreEqual(list.IndexOf(element), expectedIndex);
        }

        [Test]
        public void ContainsShouldReturnFalseWhenListDoesNotContainsTheElement()
        {
            AddElements();
            Assert.AreEqual(list.Contains(100), false);
        }

        [Test]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void ContainsShouldReturnTrueWhenListContainsTheElement(int element)
        {
            AddElements();
            Assert.AreEqual(list.Contains(element), true);
        }

        private void AddElements(int[] elements)
        {
            foreach (var element in elements)
            {
                list.Add(element);
            }
        }

        private bool HaveEqualElements(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != list[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void AddElements()
        {
            list.Add(10);
            list.Add(20);
            list.Add(30);
        }
    }
}
