using System.Collections.Generic;
using System;
using System.Linq;

namespace PeopleDatabase
{
    public class Database
    {
        private Dictionary<string, People> peopleByUsername;
        private Dictionary<long, People> peopleById;

        public Database()
        {
            peopleById = new Dictionary<long, People>();
            peopleByUsername = new Dictionary<string, People>();
        }

        public Database(IEnumerable<People> people) : this()
        {
            foreach (People person in people)
            {
                Add(person);
            }
        }

        public void Add(People people)
        {
            if (this.peopleByUsername.ContainsKey(people.Username) || peopleById.ContainsKey(people.Id))
            {
                throw new InvalidOperationException("Username or id already exists in the database!");
            }

            peopleById.Add(people.Id, people);
            peopleByUsername.Add(people.Username, people);
        }

        public void Remove()
        {
            if (peopleById.Count <= 0 || peopleByUsername.Count <= 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }


            long id = peopleById.Last().Key;
            peopleById.Remove(id);

            string username = peopleByUsername.Last().Key;
            peopleByUsername.Remove(username);
        }

        public People FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id cannot be negative!");
            }
            if (!this.peopleById.ContainsKey(id))
            {
                throw new InvalidOperationException("There is no people with such id in the database!");
            }

            return this.peopleById[id];
        }

        public People FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentException("Username is null!");
            }
            if (!this.peopleByUsername.ContainsKey(username))
            {
                throw new InvalidOperationException("There is no people with such username in the database!");
            }

            return this.peopleByUsername[username];
        }
    }
}
