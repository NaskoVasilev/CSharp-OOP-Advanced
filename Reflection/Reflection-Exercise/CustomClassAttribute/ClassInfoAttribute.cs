using System;
using System.Collections.Generic;
using System.Text;

namespace CustomClassAttribute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ClassInfoAttribute : Attribute
    {
        private List<string> reviewers;

        public ClassInfoAttribute(string author, int revision, string description, params string[] reviewers)
        {
            Author = author;
            Revision = revision;
            Description = description;
            this.reviewers = new List<string>(reviewers);
        }

        public string Author { get; }

        public int Revision { get; }

        public string Description { get; }

        public string Reviewers => string.Join(", ", reviewers);
    }
}
