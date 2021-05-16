using GeekTrust.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace GeekTrust.Models
{
    public class Universe : IUniverse
    {
        public Universe(string name, IList<Kingdom> participatingKingdoms, string aspirationalRuler)
        {
            Name = name;
            Kingdoms = participatingKingdoms;
            AspirationalRuler = FindKingdomByName(aspirationalRuler?.ToUpper());
            _cipher = new SeasarCipher();
        }
        public string Name { get; }
        public IList<Kingdom> Kingdoms { get; }
        public Kingdom AspirationalRuler { get; }

        public void SendMessage(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                var parts = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    var message = new SecretMessage
                    {
                        Recipient = FindKingdomByName(parts[0]),
                        Content = parts[1]
                    };

                    AspirationalRuler.ProcessMessage(message);
                }
            }
        }

        public string DetermineRuler()
        {
            if (AspirationalRuler.Allies.Value.Count >= _minimumAlliesToRule)
            {
                var output = AspirationalRuler.Name + " ";
                output += string.Join(' ', AspirationalRuler.Allies.Value.Select(a => a.Name).ToArray());
                return output;
            }

            return "NONE";
        }
        private Kingdom FindKingdomByName(string name) => Kingdoms.SingleOrDefault(k => k.Name == name);
        private const int _minimumAlliesToRule = 3;
        private ICipher _cipher;
    }
}