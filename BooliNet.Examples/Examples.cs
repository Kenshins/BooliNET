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

        // Listings examples
        public void RunSimpleListingsExample()
        {
            var booli = new BooliNET.Booli(CallerId, Key);

            var sc = new BooliNET.BooliSearchCondition();
            var esc = new BooliNET.ExtendedSearchConditionList(); //Extended search condition for lists, only used as argument here
            sc.Q = "Nacka";
            sc.Limit = 5;

            var result = booli.GetResultList(sc, esc);
            Console.WriteLine("Simple Listings Example\n");
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

        public void CenterDimListingsExample()
        {
            var booli = new BooliNET.Booli(CallerId, Key);
            
            var sc = new BooliNET.BooliSearchCondition();
            var esc = new BooliNET.ExtendedSearchConditionList(); 
            sc.Center = "59.334972,18.065504";
            sc.Dim = "400,500";
            sc.MinPlotArea = 100;
            sc.MaxPlotArea = 5000;
            sc.Limit = 5;

            var result = booli.GetResultList(sc, esc);
            Console.WriteLine("Center and Dim Example!\n");
            Console.WriteLine(result.ToString());
        }


        public void BboxListingsExample()
        {
            var booli = new BooliNET.Booli(CallerId, Key);

            var sc = new BooliNET.BooliSearchCondition();
            var esc = new BooliNET.ExtendedSearchConditionList(); 
            sc.Bbox = "57.69330,11.96522,57.73896,12.03320";
            sc.MinPrice = 1000000;
            sc.MaxPrice = 3000000;
            sc.Limit = 5;

            var result = booli.GetResultList(sc, esc);
            Console.WriteLine("Bbox Example!\n");
            Console.WriteLine(result.ToString());
        }

        public void AreaIdListingsExample()
        {
            var booli = new BooliNET.Booli(CallerId, Key);
            
            var sc = new BooliNET.BooliSearchCondition();
            var esc = new BooliNET.ExtendedSearchConditionList(); 
            sc.AreaId = "76,16";
            sc.MinRooms = 3;
            sc.Limit = 5;

            var result = booli.GetResultList(sc, esc);
            Console.WriteLine("Area Id Example!\n");
            Console.WriteLine(result.ToString());
        }

        // Sold examples
        public void RunSimpleSoldExample()
        {
            var booli = new BooliNET.Booli(CallerId, Key);

            var sc = new BooliNET.BooliSearchCondition();
            var esc = new BooliNET.ExtendedSearchConditionSold(); //Extended search condition for sold, only used as argument here
            sc.Q = "Nacka";
            sc.Limit = 5;

            var result = booli.GetResultSold(sc, esc);
            Console.WriteLine("Simple Sold Example\n");
            Console.WriteLine("Result:\n");
            Console.WriteLine("Count: " + result.count.ToString());
            Console.WriteLine("Total count: " + result.totalCount.ToString());

            foreach (Sold listing in result.sold)
            {
                Console.WriteLine("\n===========");
                Console.WriteLine("BooliId: " + listing.booliId.ToString());
                Console.WriteLine("Sold price: " + listing.soldPrice.ToString());
                Console.WriteLine("Living Area: " + listing.livingArea.ToString());
                Console.WriteLine("City: " + listing.location.address.city.ToString());
                Console.WriteLine("Street Adress: " + listing.location.address.streetAddress.ToString());
            }
        }

        public void PriceSoldExample()
        {
            var booli = new BooliNET.Booli(CallerId, Key);

            var sc = new BooliNET.BooliSearchCondition();
            var esc = new BooliNET.ExtendedSearchConditionSold();
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
        }

        // Area examples

        public void RunSimpleAreaExample()
        {
            var booli = new BooliNET.Booli(CallerId, Key);

            var sc = new BooliNET.AreaSearchCondition();
            sc.Latitude = "59.334979";
            sc.Longitude = "18.065579";
            // Limit can be set if Q is used instead of Lat/Long

            var result = booli.GetResultArea(sc);
            Console.WriteLine("Simple Area Example\n");
            Console.WriteLine("Result:\n");
            Console.WriteLine("Count: " + result.count.ToString());
            Console.WriteLine("Total count: " + result.totalCount.ToString());

            foreach (Areas area in result.areas)
            {
                Console.WriteLine("\n===========");
                Console.WriteLine("BooliId: " + area.booliId.ToString());
                Console.WriteLine("Name: " + area.name.ToString());
                foreach (string t in area.types)
                {
                    Console.WriteLine("\tType: " + t.ToString());
                }
                Console.WriteLine("Parent BooliId: " + area.parentBooliId.ToString());
                Console.WriteLine("Parent name: " + area.parentName.ToString());
                foreach (string t in area.parentTypes)
                {
                    Console.WriteLine("\tParent type: " + t.ToString());
                }
                Console.WriteLine("Size: " + area.size.ToString());
            }
        }

        // Sold Id examples

        public void RunSimpleSoldIdExample()
        {
            var booli = new BooliNET.Booli(CallerId, Key);

            var result = booli.GetResultIdSold(1528339);
            Console.WriteLine("Simple Sold Example\n");
            Console.WriteLine("Result:\n");
            Console.WriteLine("Count: " + result.count.ToString());
            Console.WriteLine("Total count: " + result.totalCount.ToString());

            foreach (Sold listing in result.sold)
            {
                Console.WriteLine("\n===========");
                Console.WriteLine("BooliId: " + listing.booliId.ToString());
                Console.WriteLine("Sold price: " + listing.soldPrice.ToString());
                Console.WriteLine("Living Area: " + listing.livingArea.ToString());
                Console.WriteLine("City: " + listing.location.address.city.ToString());
                Console.WriteLine("Street Adress: " + listing.location.address.streetAddress.ToString());
            }
        }

        // Listings Id example is excluded as this is almost the same as Sold Id example above
    }
}
