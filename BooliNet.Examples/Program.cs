using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooliNET.Examples
{
    class Program
    {
        const string CallerId = "bopren"; // Supplied from booli, http://www.booli.se/api/key
        const string Key = "P8rfkeJvKOXgHjvXZ1npRXVGG2kHPmXpd5NZetHS"; // Supplied from booli, http://www.booli.se/api/key

        static void Main(string[] args)
        {
            var examples = new Examples.BooliExamples(CallerId, Key);
            examples.RunSimpleListingsExample();
            
            Console.WriteLine();
            examples.CenterDimListingsExample();
            
            Console.WriteLine();
            examples.BboxListingsExample();

            Console.WriteLine();
            examples.AreaIdListingsExample();

            Console.WriteLine();
            examples.RunSimpleSoldExample();

            Console.WriteLine();
            examples.PriceSoldExample();

            Console.ReadKey();
        }
    }
}
