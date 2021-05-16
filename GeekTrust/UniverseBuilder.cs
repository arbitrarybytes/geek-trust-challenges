using GeekTrust.Contracts;
using GeekTrust.Models;
using System.Collections.Generic;

namespace GeekTrust
{
    public class UniverseBuilder : IUniverseBuilder
    {
        public Universe Universe { get; set; }

        public void Build(string name, string aspirationalKingdom)
        {
            Universe = new Universe(name, 
                                    GetParticipatingKingdoms(), 
                                    aspirationalKingdom);
        }

        private List<Kingdom> GetParticipatingKingdoms() => new List<Kingdom>
            {
                new Kingdom("SPACE", "Gorilla", new SeasarCipher()),
                new Kingdom("LAND", "Panda"),
                new Kingdom("WATER", "Octopus"),
                new Kingdom("ICE", "Mammoth"),
                new Kingdom("AIR", "Owl"),
                new Kingdom("FIRE", "Dragon")
            };
    
    }
}