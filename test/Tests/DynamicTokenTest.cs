using Xunit;
using System.IO;
using Carable.AssemblyPayments.Abstractions;

namespace Carable.AssemblyPayments.Tests
{

    public class DynamicTokenTest : AbstractTest
    {
        [Fact]
        public void GenerateCardToken()
        {
            var content = Files.ReadAllText("./Fixtures/generate_card_token.json");

            var client = GetMockClient(content);
            var repo = Get<ITokenRepository>(client.Object);
            var result = repo.GenerateCardToken("card", "064d6800-fff3-11e5-86aa-5e5517507c66");
            Assert.Equal("card", result.TokenType);
            Assert.Equal("6e37598a3b33582b1dfcf13d5e2e45e3", result.Token);
            Assert.Equal("064d6800-fff3-11e5-86aa-5e5517507c66", result.UserId);
        }
    }
}
