using System.Linq;
using Xunit;

namespace GeekTrust.Tests
{
    public class RulerKingdomTests
    {
        UniverseBuilder _builder;

        public RulerKingdomTests()
        {
            _builder = new UniverseBuilder();
            _builder.Build("Southeros", "SPACE");
        }

        [Theory]
        [InlineData("AIR ROZO", "AIR", true)]
        [InlineData("LAND FAIJWJSOOFAMAU", "LAND", true)]
        [InlineData("ICE STHSTSTVSASOS", "ICE", true)]
        [InlineData("ICE STS", "ICE", false)]
        public void Test_SendMessage(string inputLine, string allyName, bool expected)
        {
            _builder.Universe.SendMessage(inputLine);
            Assert.Equal(expected, _builder.Universe
                                           .AspirationalRuler
                                           .Allies
                                           .Value
                                           .SingleOrDefault(k => k.Name == allyName) != null);
        }

        [Fact]
        public void Test_DetermineRuler_Success()
        {
            _builder.Universe.SendMessage("LAND FAIJWJSOOFAMAU");
            _builder.Universe.SendMessage("ICE STHSTSTVSASOS");
            _builder.Universe.SendMessage("AIR ROZO");

            Assert.True(_builder.Universe.DetermineRuler() == "SPACE LAND ICE AIR");
        }

        [Fact]
        public void Test_DetermineRuler_None()
        {
            _builder.Universe.SendMessage("LAND FAIJWJSOOFAMAU");
            _builder.Universe.SendMessage("ICE STHSTSTVSASOS");
            _builder.Universe.SendMessage("AIR ROO");

            Assert.True(_builder.Universe.DetermineRuler() == "NONE");
        }

        [Fact]
        public void Test_DetermineRuler_DuplicateAlly_None()
        {
            _builder.Universe.SendMessage("AIR ROZO");
            _builder.Universe.SendMessage("AIR ROZO");
            _builder.Universe.SendMessage("AIR ROZO");

            Assert.True(_builder.Universe.DetermineRuler() == "NONE");
        }

    }

}