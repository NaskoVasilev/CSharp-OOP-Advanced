using System;

namespace CustomEvent
{
    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

    public class Dispetcher
    {
        private string name;

        public Dispetcher(string name)
        {
            this.name = name;
        }

        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                OnNameChange(this, new NameChangeEventArgs(this.Name));
            }
        }

        protected void OnNameChange(object sender,NameChangeEventArgs args)
        {
            if(this.NameChange is NameChangeEventHandler nameChangeHandler)
            {
                nameChangeHandler(this, args);
            }
        }
    }

    public class NameChangeEventArgs : EventArgs
    {
        public NameChangeEventArgs(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
