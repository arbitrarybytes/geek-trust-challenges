using GeekTrust.Contracts;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace GeekTrust
{

    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            var filename = args[0];
            var fileStream = new FileStream(filename, FileMode.Open);
            string line;

            IUniverseBuilder universeBuilder = new UniverseBuilder();
            universeBuilder.Build("Southeros", "SPACE");

            var universe = universeBuilder.Universe;

            using (var reader = new StreamReader(fileStream))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    universe.SendMessage(line);
                }

                Console.WriteLine(universe.DetermineRuler());
            }
        }
    }
}