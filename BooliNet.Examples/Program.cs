using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooliNET.Examples
{
    class Program
    {
        const string CallerId = "yourBooliId"; // Supplied from booli, http://www.booli.se/api/key
        const string Key = "P8rhkeJzKOXgHj3XZ1npRXVQG2kHPmXpd5NZetKJ"; // Supplied from booli, http://www.booli.se/api/key

        static void Main(string[] args)
        {
            var examples = new Examples.BooliExamples(CallerId, Key);
            examples.RunSimpleExample();
        }
    }
}
