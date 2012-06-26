using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooliNET.Examples.Examples
{
    class BooliExamples
    {

        string CallerId;
        string Key;

        public BooliExamples(string callerId, string key)
        {
            init(callerId, key);
        }

        private void init(string callerId, string key)
        {

            if (callerId == "")
                throw new ArgumentException("CallerId can not be empty!", "CallerId");

            if (key == "")
                throw new ArgumentException("Key can not be empty!", "Key");

            CallerId = callerId;
            Key = key;
        }

        public void RunSimpleExample()
        {
            var booli = new BooliNET.Booli(CallerId, Key);

            var sc = new BooliNET.BooliSearchCondition();
            sc.Q = "nacka";
            sc.Limit = 5;

            var result = booli.GetResult(sc);
            Console.WriteLine("Simple Example\n");
            Console.WriteLine("Result:\n");
            Console.WriteLine("Count: " + result.count.ToString());
            Console.WriteLine("Total count: " + result.totalCount.ToString());

            foreach (Listing listing in result.listings)
            {
                Console.WriteLine("\n===========");
                Console.WriteLine("BooliId: " + listing.booliId.ToString());
                Console.WriteLine("List price: " + listing.listPrice.ToString());
                Console.WriteLine("Living Area: " + listing.livingArea.ToString());
                Console.WriteLine("City: " + listing.location.address.city.ToString());
                Console.WriteLine("Street Adress: " + listing.location.address.streetAddress.ToString());
            }
        }

        public void CenterDimExample()
        {
            var booli = new BooliNET.Booli(CallerId, Key);
            
            var sc = new BooliNET.BooliSearchCondition();
            sc.Center = "59.334972,18.065504";
            sc.Dim = "400,500";
            sc.MinPlotArea = 100;
            sc.MaxPlotArea = 5000;
            sc.Limit = 5;

            var result = booli.GetResult(sc);
            Console.WriteLine("Center and Dim Example!\n");
            Console.WriteLine(result.ToString());
        }


        public void BboxExample()
        {
            var booli = new BooliNET.Booli(CallerId, Key);

            var sc = new BooliNET.BooliSearchCondition();
            sc.Bbox = "57.69330,11.96522,57.73896,12.03320";
            sc.MinPrice = 1000000;
            sc.MaxPrice = 3000000;
            sc.Limit = 5;

            var result = booli.GetResult(sc);
            Console.WriteLine("Bbox Example!\n");
            Console.WriteLine(result.ToString());
        }

        public void AreaIdExample()
        {
            var booli = new BooliNET.Booli(CallerId, Key);
            
            var sc = new BooliNET.BooliSearchCondition();
            sc.AreaId = "76,16";
            sc.MinRooms = 3;
            sc.Limit = 5;

            var result = booli.GetResult(sc);
            Console.WriteLine("Area Id Example!\n");
            Console.WriteLine(result.ToString());
        }
    }
}
