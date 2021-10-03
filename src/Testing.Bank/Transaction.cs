using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Bank
{
    public class Transaction
    {
        private string _description { get; set; }
        public string Description {
            get => _description;
            set => _description = !string.IsNullOrEmpty(value)
                ? value
                : throw new Exception($"{nameof(Description)} is required");
        }

        private int _amount { get; set; }
        public int Amount
        {
            get => _amount;
            set => _amount = value > 0 
                ? value 
                : throw new Exception($"{nameof(Amount)} should be greater than zero");
        }

        private TransactionType _type { get; set; }
        public TransactionType Type
        {
            get => _type;
            set => _type = Enum.IsDefined(typeof(TransactionType), value)
                ? value
                : throw new Exception($"{value} is not a valid value for {nameof(Type)}");
        }

        public Transaction(TransactionType type, int amount, string description)
        {
            Type = type;
            Amount = amount;
            Description = description;
        }
    }
}
