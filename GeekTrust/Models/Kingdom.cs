using System;
using System.Collections.Generic;
using GeekTrust.Contracts;

namespace GeekTrust.Models
{
    public class Kingdom
    {

        ///<summary>The name of the Kingdom</summary>
        public string Name { get; }

        ///<summary>The Emblem of the Kingdom</summary>
        public string Emblem { get; }

        private readonly ICipher _cipher;

        public Kingdom(string name, string emblem, ICipher cipher = null)
        {
            Name = name;
            Emblem = emblem;
            _cipher = cipher;
            Allies = new Lazy<List<Kingdom>>();
        }

        public Lazy<List<Kingdom>> Allies { get; private set; }

        public void ProcessMessage(SecretMessage message)
        {
            var isRecipientAlly = _cipher?.Decipher(message);

            if (isRecipientAlly.GetValueOrDefault())
            {
                Allies.Value.Add(message.Recipient);
            }
        }

    }
}
