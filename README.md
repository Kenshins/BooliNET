BooliNET
=======

A wrapper written in C# to connect to the Booli.se API.

Install
=======

With Nuget:

Install-Package BooliNet

For more info on Nuget please visit http://nuget.org/

Example
=======
<pre>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BooliNET;

namespace NugetTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Listings example
            var booli = new BooliNET.Booli("yuorbooliid", "P8OfkdJvKOXgHj--your--booli-key--PmXpd5KZetHS");
            
            var sc = new BooliNET.BooliSearchCondition();
            var esc = new BooliNET.ExtendedSearchConditionList(); //Extended search condition, empty here
            sc.Center = "59.334972,18.065504";
            sc.Dim = "400,500";
            sc.MinPlotArea = 100;
            sc.MaxPlotArea = 5000;
            sc.Limit = 5;

            var result = booli.GetResultList(sc, esc);
            Console.WriteLine("Center and Dim Example!\n");
            Console.WriteLine(result.ToString());
            Console.ReadKey();
            
            // Sold example
            var sc = new BooliNET.SearchCondition();
            var esc = new BooliNET.ExtendedSearchConditionSold(); //Extended search condition, empty here
            sc.Q = "Helsingborg";
            sc.MinRooms = 2;
            sc.Limit = 5;
            esc.MinSoldPrice = 2000000;
            esc.MaxSoldPrice = 3000000;
            esc.MinSoldDate = "20130101";
            esc.MaxSoldDate = "20130601";

            var result = booli.GetResultSold(sc, esc);
            Console.WriteLine("Price Sold Example!\n");
            Console.WriteLine(result.ToString());
            Console.ReadKey();
        }
    }
}
</pre>
License
=======
This Booli C# wrapper is released under the MIT License (MIT).

Copyright (c) 2014 Martin Kleberger

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
