using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooliNET.Examples
{
    class Program
    {
        const string CallerId = "yourbooliid"; // Supplied from booli, http://www.booli.se/api/key
        const string Key = "P9rfkeXvKOXgHIvXZ1npRXVGG2kHLmXpd5NIetHS"; // Supplied from booli, http://www.booli.se/api/key

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

            Console.WriteLine();
            examples.RunSimpleAreaExample();

            Console.WriteLine();
            examples.RunSimpleSoldIdExample();

            Console.ReadKey();
        }
    }
}
