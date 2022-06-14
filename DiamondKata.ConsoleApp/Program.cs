using System;
using System.Text.RegularExpressions;

namespace DiamondKata.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var character = args?.Length > 0 ? args[0] : null;
            var isValid = character != null && Regex.IsMatch(character, "^[a-z]{1}$", RegexOptions.IgnoreCase);
            if (!isValid)
            {
                Console.WriteLine("Invalid character was supplied.");
                return;
            }
            
            var factory = new DiamondFactory();
            var diamond = factory.Create(character!.ToUpper()[0]);
            foreach (var line in diamond)
            {
                Console.WriteLine(line);
            }
        }
    }
}
