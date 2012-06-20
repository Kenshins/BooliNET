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
            var sc = new BooliNET.BooliSearchCondition();
            sc.Q = "nacka";
            sc.Limit = 5;

            var booli = new BooliNET.Booli(sc, CallerId, Key);
            var result = booli.GetResult();

            Console.WriteLine("Result:\n");
            Console.WriteLine("Count: " + result.count.ToString());
            Console.WriteLine("Total count: " + result.totalCount.ToString());

            foreach (Listing listing in result.listings)
            {
                Console.WriteLine("\n===========");
                Console.WriteLine("BooliId: " + listing.booliId.ToString());
                Console.WriteLine("List price: " + listing.listPrice.ToString());
                Console.WriteLine("Living Area: " + listing.livingArea.ToString());
                
                if (listing.location.address.city != null)
                    Console.WriteLine("City: " + listing.location.address.city.ToString());

                if (listing.location.address.streetAddress != null)
                    Console.WriteLine("Street Adress: " + listing.location.address.streetAddress.ToString());
            }

            Console.ReadKey();
        }
    }
}
