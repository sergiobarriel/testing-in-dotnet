using Xunit;

namespace Testing.Bank.Tests.Theories.Factories
{
    public class UserTheoryData : TheoryData<string, int, string>
    {
        public UserTheoryData()
        {
            Add("", 18, $"{nameof(User.Name)} is required");
            Add("Morty Smith", 14, $"{nameof(User.Age)} should be equal or greater than 18");
        }
    }
}