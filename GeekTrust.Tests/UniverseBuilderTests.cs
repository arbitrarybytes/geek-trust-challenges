using Xunit;

namespace GeekTrust.Tests
{
    public class UniverseBuilderTests
    {
        [Fact]
        public void Test_Builder()
        {
            var builder = new UniverseBuilder();
            builder.Build("Southeros", "SPACE");

            Assert.True(builder.Universe.Name == "Southeros");
            Assert.True(builder.Universe.AspirationalRuler.Name == "SPACE");
            Assert.True(builder.ParticipatingKingdoms.Count > 0);
        }
    }

}