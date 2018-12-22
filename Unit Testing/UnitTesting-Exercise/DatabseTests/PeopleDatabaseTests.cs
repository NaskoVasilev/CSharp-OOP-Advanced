using NUnit.Framework;
using PeopleDatabase;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DatabseTests
{
    [TestFixture]
    public class PeopleDatabaseTests
    {
        private Database db;

        [Test]
        public void PeoplePassedToConstructorShouldBeAdd()
        {
            People[] people = GetPeople();
            db = new Database(people);

            bool expectedResult = DatabaseContainsAllPeople(people);

            Assert.That(expectedResult);
        }


        [Test]
        public void AddMethodShouldWorkCorrect()
        {
            People[] data = GetPeople();
            db = new Database();

            foreach (var person in data)
            {
                db.Add(person);
            }

            Assert.That(this.DatabaseContainsAllPeople(data));
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhithPeopleWithSameId()
        {
            db = new Database();
            db.Add(new People(100, "pesho"));

            Assert.Throws<InvalidOperationException>(() => db.Add(new People(100, "atanas")));
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhithPeopleWithSameUsername()
        {
            db = new Database();
            db.Add(new People(100, "pesho"));

            Assert.Throws<InvalidOperationException>(() => db.Add(new People(200, "pesho")));
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhithSamePeople()
        {
            db = new Database();
            db.Add(new People(100, "pesho"));

            Assert.Throws<InvalidOperationException>(() => db.Add(new People(100, "pesho")));
        }

        [Test]
        public void RemoveMethodShouldRemoveLastElemenet()
        {
            db = new Database();
            long id = 100;
            string username = "atanas";
            db.Add(new People(id, username));
            db.Remove();

            var peopleById = (Dictionary<long, People>)GetField("peopleById").GetValue(db);
            Assert.That(!peopleById.ContainsKey(id));

            var peopleByUsername = (Dictionary<string, People>)GetField("peopleByUsername").GetValue(db);
            Assert.That(!peopleByUsername.ContainsKey(username));
        }

        [Test]
        public void RemoveShouldThrowInvalidOperatonExceptionWhenDatbaseIsEmpty()
        {
            db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void FindByIdShouldThrowsArgumentExceptionWithNegativeValue()
        {
            db = new Database();

            Assert.Throws<ArgumentException>(() => db.FindById(-200));
        }

        [Test]
        public void FindByIdShouldThrowsInvalidOperatonExceptionWithIdDatabaseDoesNotContains()
        {
            db = new Database();
            db.Add(new People(201, "atanas"));
            Assert.Throws<InvalidOperationException>(() => db.FindById(200));
        }

        [Test]
        public void FindByIdWithValidIdShouldReturnPerson()
        {
            db = new Database();
            int id = 200;
            var expectedPerson = new People(id, "Goosho");
            db.Add(expectedPerson);
            People person = db.FindById(id);
            Assert.AreSame(expectedPerson, person);
        }

        [Test]
        public void FindByUsrenameShouldThrowsArgumentExceptionWithNullAsParamter()
        {
            db = new Database();

            Assert.Throws<ArgumentException>(() => db.FindByUsername(null));
        }

        [Test]
        public void FindByUsrenameShouldThrowsInvalidOperationExceptionWithinvalidUsername()
        {
            db = new Database();
            db.Add(new People(200, "Atanas"));
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("atanas"));
        }

        [Test]
        public void FindByUsernameWithValidUsernameShouldReturnPerson()
        {
            db = new Database();
            string username = "nasko";
            var expectedPerson = new People(200, username);
            db.Add(expectedPerson);
            People person = db.FindByUsername(username);
            Assert.AreSame(person, expectedPerson);
        }

        private bool DatabaseContainsAllPeople(People[] people)
        {
            var peopleById = (Dictionary<long, People>)GetField("peopleById").GetValue(db);
            var peopleByUsername = (Dictionary<string, People>)GetField("peopleByUsername").GetValue(db);

            foreach (People person in people)
            {
                if (!peopleById.ContainsKey(person.Id) || !peopleByUsername.ContainsKey(person.Username))
                {
                    return false;
                }
            }

            return true;
        }

        private FieldInfo GetField(string fieldName)
        {
            Type type = typeof(Database);

            return type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        }

        private People[] GetPeople()
        {
            return new People[]
            {
                new People(150,"nasko"),
                new People(200,"atanas"),
                new People(250,"pesho")
            };
        }
    }
}
