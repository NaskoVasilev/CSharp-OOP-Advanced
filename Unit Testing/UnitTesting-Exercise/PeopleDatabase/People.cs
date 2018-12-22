using System;

namespace PeopleDatabase
{
    public class People 
    {
        public People(long id, string username)
        {
            Id = id;
            Username = username;
        }

        public long Id { get; private set; }

        public string Username { get; private set; }

    }
}
