using System.IO;

namespace GeekTrust
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = args[0];
            var fileStream = new FileStream(filename, FileMode.Open);
            string line;

            using (var reader = new StreamReader(fileStream))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    //TODO: Process input
                }
            }
        }
    }
}