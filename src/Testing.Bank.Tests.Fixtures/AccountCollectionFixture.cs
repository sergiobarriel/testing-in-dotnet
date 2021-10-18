using System;
using System.Collections.Generic;
using Xunit;

namespace Testing.Bank.Tests.Fixtures
{
    [CollectionDefinition("account-collection-fixture-should")]
    public class AccountCollectionFixture : ICollectionFixture<AccountFixture>
    {
      
    }
}