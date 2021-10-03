using System;

namespace Testing.Bank
{
    public class User
    {
        private string _name { get; set; }
        public string Name
        { 
            get => _name;
            set => _name = !string.IsNullOrEmpty(value) 
                ? value 
                : throw new Exception($"{nameof(Name)} is required");
        }

        private int _age { get; set; }

        public int Age
        {
            get => _age;
            set => _age = value >= 18 
                ? value 
                : throw new Exception($"{nameof(Age)} should be equal or greater than 18");
        }

        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
