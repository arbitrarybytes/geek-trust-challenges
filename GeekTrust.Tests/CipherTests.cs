using GeekTrust.Contracts;
using GeekTrust.Models;
using System;
using System.Linq;
using Xunit;

namespace GeekTrust.Tests
{

    public class CipherTests
    {
        public CipherTests()
        {
            _builder = new UniverseBuilder();
            _builder.Build("Southeros", "SPACE");
        }

        UniverseBuilder _builder;

        [Theory]
        [InlineData("AIR", "ROZO", true)]
        [InlineData("AIR", "RO", false)]
        [InlineData("LAND", "FAIJWJSOOFAMAU", true)]
        public void Test_IsAlly(string kingdom, string message, bool expected)
        {
            ICipher cipher = new SeasarCipher();
            var msg = new SecretMessage
            {
                Content = message,
                Recipient = _builder.ParticipatingKingdoms.SingleOrDefault(k => k.Name == kingdom)
            };

            Assert.Equal(cipher.IsAlly(msg), expected);
        }

        [Theory]
        [InlineData("LAND", "FAIJWJSOOFAMAU", "AVDERENJJAVHVP")]
        [InlineData("AIR", "ROZO", "OLWL")]
        public void Test_Decipher(string kingdom, string input, string output)
        {
            ICipher cipher = new SeasarCipher();
            var msg = new SecretMessage
            {
                Content = input,
                Recipient = _builder.ParticipatingKingdoms
                                    .SingleOrDefault(k => k.Name == kingdom)
            };

            Assert.Equal(cipher.Decipher(msg), output);
        }
    }
}
