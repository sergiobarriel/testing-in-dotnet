using System;

namespace Testing.Bank.Tests.Assertions
{
    public class SingletonFactory : ISingletonFactory
    {
        private static SingletonFactory _instance { get; set; }

        private Guid _id { get; set; }
        public Guid Id
        {
            get => _id;
            set => _id = value;
        }
        private SingletonFactory()
        {
            Id = Guid.NewGuid();
        }

        public static SingletonFactory GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SingletonFactory();
            }

            return _instance;
        }

        public static SingletonFactory GetNewInstance()
        {
            return new SingletonFactory();
        }
    }
}
