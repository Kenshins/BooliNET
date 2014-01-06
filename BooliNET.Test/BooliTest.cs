using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using NUnit.Framework;

namespace BooliNET.Test
{
    [TestFixture]
    public class BooliSearchConditionTest
    {
        [Test]
        public void SetQ()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.Q = "Nacka";
            Assert.That(sc.Q == "Nacka");
        }

        [Test]
        public void SetCenter()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.Center = "-50.5,120.5";
            Assert.That(sc.Center == "-50.5,120.5");
        }

        [Test]
        public void CenterLenException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.Center = "1.0";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void CenterLatOutOfBoundException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.Center = "-91.2,160.4";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void CenterLongOutOfBoundException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.Center = "-81.2,191.4";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetDim()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.Dim = "1.0,1.0";
            Assert.That(sc.Dim == "1.0,1.0");
        }

        [Test]
        public void DimLenException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.Dim = "1.0";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void DimArg1OutOfBoundException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.Dim = "-91.2,160.4";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void DimArg2OutOfBoundException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.Dim = "91,-160.4";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetBbox()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.Bbox = "1.0,-2,1.0,1";
            Assert.That(sc.Bbox == "1.0,-2,1.0,1");
        }

        [Test]
        public void BboxLenException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.Bbox = "1.0,1.0,1.0";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void BboxArg1OutOfBoundException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.Bbox= "-91.2,160.4,1.0,1.0";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void BboxArg2OutOfBoundException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.Bbox = "91,-160.4,1.0,1.0";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void BboxArg3OutOfBoundException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.Bbox = "-81.2,160.4,190,1";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void BboxArg4OutOfBoundException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.Bbox = "90,-160.4,5,-181";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetAreaId()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.AreaId = "1,2,3";
            Assert.That(sc.AreaId == "1,2,3");
        }

        [Test]
        public void AreaIdFormatException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.AreaId = "1,2,3,G"; ;
            Assert.Throws<FormatException>(throwingCode);
        }


        [Test]
        public void AreaIdNegativeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.AreaId = "1,2,3,-11"; ;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetMinPrice()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.MinPrice = 120;
            Assert.That(sc.MinPrice == 120);
        }

        [Test]
        public void MinPriceNegativeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.MinPrice = -12;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetMaxPrice()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.MaxPrice = 140;
            Assert.That(sc.MaxPrice == 140);
        }

        [Test]
        public void MaxPriceNegativeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.MaxPrice = -3;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetMinRooms()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.MinRooms = 0;
            Assert.That(sc.MinRooms == 0);
        }

        [Test]
        public void MinRoomsNegativeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.MinRooms = -1;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetMaxRooms()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.MaxRooms = 7;
            Assert.That(sc.MaxRooms == 7);
        }

        [Test]
        public void MaxRoomsNegativeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.MaxRooms = -2;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetMaxRent()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.MaxRent = 7;
            Assert.That(sc.MaxRent == 7);
        }

        [Test]
        public void MaxRentNegativeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.MaxRent = -222;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetMinLivingArea()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.MinLivingArea = 85;
            Assert.That(sc.MinLivingArea == 85);
        }

        [Test]
        public void MinLivingAreaNegativeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.MinLivingArea = -20;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetMaxLivingArea()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.MaxLivingArea = 250;
            Assert.That(sc.MaxLivingArea == 250);
        }

        [Test]
        public void MaxLivingAreaNegativeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.MaxLivingArea = -180;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetMinPlotArea()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.MinPlotArea = 500;
            Assert.That(sc.MinPlotArea == 500);
        }

        [Test]
        public void MinPlotAreaNegativeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.MinPlotArea = -700;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetMaxPlotArea()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.MaxPlotArea = 5500;
            Assert.That(sc.MaxPlotArea == 5500);
        }

        [Test]
        public void MaxPlotAreaNegativeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.MaxPlotArea = -6500;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetObjectType()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.ObjectType = "villa,lägenhet";
            Assert.That(sc.ObjectType == "villa,lägenhet");
        }

        [Test]
        public void DuplicateObjectTypeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.ObjectType = "villa,villa";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void UnknownObjectTypeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.ObjectType = "villa,lägenhet,banan";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetMinCreated()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.MinCreated = "20100102";
            Assert.That(sc.MinCreated == "20100102");
        }

        [Test]
        public void MinCreatedLenArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.MinCreated = "2011010101";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void MinCreatedFormatException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.MinCreated = "20111301";
            Assert.Throws<FormatException>(throwingCode);
        }

        [Test]
        public void SetMaxCreated()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.MaxCreated = "20110102";
            Assert.That(sc.MaxCreated == "20110102");
        }

        [Test]
        public void MaxCreatedLenArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.MaxCreated = "2012010101";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void MaxCreatedFormatException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.MinCreated = "20121301";
            Assert.Throws<FormatException>(throwingCode);
        }

        [Test]
        public void SetLimit()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.Limit = 13;
            Assert.That(sc.Limit == 13);
        }

        [Test]
        public void LimitNegativeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.Limit = -18;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void SetOffset()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.Offset = 5;
            Assert.That(sc.Offset == 5);
        }

        [Test]
        public void OffsetNegativeArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => sc.Offset = -7;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void CreateUrlArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => { sc.Offset = 5; sc.CreateUrl(); };
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void CreateUrlMissingDimArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => { sc.Center = "50.0,14.1"; sc.CreateUrl(); };
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void CreateUrlMissingCenterArgumentException()
        {
            var sc = new BooliNET.BooliSearchCondition();
            TestDelegate throwingCode = () => { sc.Center = "50.0,14.1"; sc.CreateUrl(); };
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void CreateUrl()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.MaxCreated = "20100115";
            sc.MinCreated = "20100101";
            sc.ObjectType = "villa, radhus";
            sc.MaxPlotArea = 6000;
            sc.MinPlotArea = 200;
            sc.MaxLivingArea = 500;
            sc.MinLivingArea = 10;
            sc.MaxRent = 500;
            sc.MaxRooms = 4;
            sc.MinRooms = 2;
            sc.MaxPrice = 2000000;
            sc.MinPrice = 200000;
            sc.AreaId = "1,2,3";
            sc.Bbox = "-1,1,1,-1";
            sc.Dim = "1,1";
            sc.Center = "1,1";
            sc.Q = "nacka";



            Assert.That(sc.CreateUrl() == "offset=0&limit=3&maxCreated=20100115&minCreated=20100101&objectType=villa, radhus&maxPlotArea=6000&minPlotArea=200&maxLivingArea=500&minLivingArea=10&maxRent=500&maxRooms=4&minRooms=2&maxPrice=2000000&minPrice=200000&areaId=1,2,3&bbox=-1,1,1,-1&dim=1,1&center=1,1&q=nacka");
        }

        [Test]
        public void SearchConditionsClear()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.MaxCreated = "20100115";
            sc.MinCreated = "20100101";
            sc.ObjectType = "villa, radhus";
            sc.MaxPlotArea = 6000;
            sc.MinPlotArea = 200;
            sc.MaxLivingArea = 500;
            sc.MinLivingArea = 10;
            sc.MaxRent = 500;
            sc.MaxRooms = 4;
            sc.MinRooms = 2;
            sc.MaxPrice = 2000000;
            sc.MinPrice = 200000;
            sc.AreaId = "1,2,3";
            sc.Bbox = "-1,1,1,-1";
            sc.Dim = "1,1";
            sc.Center = "1,1";
            sc.Q = "nacka";

            sc.CreateUrl();
            sc.ClearSearch();

            sc.Q = "angered";
            sc.Limit = 5;

            Assert.That(sc.CreateUrl() == "offset=0&limit=5&q=angered");
        }

    }

    [TestFixture]
    public class BooliSearchConditionListTest
    {
        [Test]
        public void SetMinListPrice()
        {
            var sc = new BooliNET.ExtendedSearchConditionList();
            sc.MinListPrice = 20000;
            Assert.That(sc.MinListPrice == 20000);
        }

        [Test]
        public void SetMaxListPrice()
        {
            var sc = new BooliNET.ExtendedSearchConditionList();
            sc.MaxListPrice = 30000;
            Assert.That(sc.MaxListPrice == 30000);
        }

        [Test]
        public void SetPriceDecrease()
        {
            var sc = new BooliNET.ExtendedSearchConditionList();
            sc.PriceDecrese = true;
            Assert.That(sc.PriceDecrese == true);
        }

        [Test]
        public void MinListPriceNegativeArgumentException()
        {
            var sc = new BooliNET.ExtendedSearchConditionList();
            TestDelegate throwingCode = () => sc.MinListPrice = -3;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void MaxListPriceNegativeArgumentException()
        {
            var sc = new BooliNET.ExtendedSearchConditionList();
            TestDelegate throwingCode = () => sc.MaxListPrice = -4;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void CreateUrl()
        {
            var sc = new BooliNET.ExtendedSearchConditionList();
            sc.MinListPrice = 20000;
            sc.MaxListPrice = 30000;
            sc.PriceDecrese = true;

            Assert.That(sc.CreateUrl() == "&minListPrice=20000&maxListPrice=30000&priceDecrease=1");
        }

        [Test]
        public void SearchConditionClear()
        {
            var sc = new BooliNET.ExtendedSearchConditionList();
            sc.MinListPrice = 20000;
            sc.MaxListPrice = 30000;
            sc.PriceDecrese = true;
            sc.CreateUrl();
            sc.ClearSearch();

            sc.MinListPrice = 12000;
            sc.MaxListPrice = 40000;


            Assert.That(sc.CreateUrl() == "&minListPrice=12000&maxListPrice=40000");
        }

    }

    [TestFixture]
    public class BooliSearchConditionSoldTest
    {
        [Test]
        public void SetMinSoldPrice()
        {
            var sc = new BooliNET.ExtendedSearchConditionSold();
            sc.MinSoldPrice = 21000;
            Assert.That(sc.MinSoldPrice == 21000);
        }

        [Test]
        public void SetMaxSoldPrice()
        {
            var sc = new BooliNET.ExtendedSearchConditionSold();
            sc.MaxSoldPrice = 31000;
            Assert.That(sc.MaxSoldPrice == 31000);
        }

        [Test]
        public void SetMinSoldCreated()
        {
            var sc = new BooliNET.ExtendedSearchConditionSold();
            sc.MinSoldDate = "20110102";
            Assert.That(sc.MinSoldDate == "20110102");
        }

        [Test]
        public void MinCreatedLenArgumentException()
        {
            var sc = new BooliNET.ExtendedSearchConditionSold();
            TestDelegate throwingCode = () => sc.MinSoldDate = "2011010101";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void MinCreatedFormatException()
        {
            var sc = new BooliNET.ExtendedSearchConditionSold();
            TestDelegate throwingCode = () => sc.MinSoldDate = "20111301";
            Assert.Throws<FormatException>(throwingCode);
        }

        [Test]
        public void SetMaxSoldCreated()
        {
            var sc = new BooliNET.ExtendedSearchConditionSold();
            sc.MaxSoldDate = "20120102";
            Assert.That(sc.MaxSoldDate == "20120102");
        }

        [Test]
        public void MaxCreatedLenArgumentException()
        {
            var sc = new BooliNET.ExtendedSearchConditionSold();
            TestDelegate throwingCode = () => sc.MaxSoldDate = "2012010101";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void MaxCreatedFormatException()
        {
            var sc = new BooliNET.ExtendedSearchConditionSold();
            TestDelegate throwingCode = () => sc.MaxSoldDate = "20121301";
            Assert.Throws<FormatException>(throwingCode);
        }

        [Test]
        public void CreateUrl()
        {
            var sc = new BooliNET.ExtendedSearchConditionSold();
            sc.MinSoldPrice = 21000;
            sc.MaxSoldPrice = 31000;
            sc.MinSoldDate = "20110102";
            sc.MaxSoldDate = "20120102";

            Assert.That(sc.CreateUrl() == "&minSoldPrice=21000&maxSoldPrice=31000&minSoldDate=20110102&maxSoldDate=20120102");
        }

        [Test]
        public void SearchConditionClear()
        {
            var sc = new BooliNET.ExtendedSearchConditionSold();
            sc.MinSoldPrice = 21000;
            sc.MaxSoldPrice = 31000;
            sc.MinSoldDate = "20110102";
            sc.MaxSoldDate = "20120102";
            sc.CreateUrl();
            sc.ClearSearch();

            sc.MinSoldPrice = 8000;
            sc.MaxSoldPrice = 80000;

            Assert.That(sc.CreateUrl() == "&minSoldPrice=8000&maxSoldPrice=80000");
        }
    }

    [TestFixture]
    public class BooliSearchConditionAreaTest
    {
        [Test]
        public void SetQ()
        {
            var sc = new BooliNET.AreaSearchCondition();
            sc.Q = "Nacka";
            Assert.That(sc.Q == "Nacka");
        }

        [Test]
        public void SetLatitude()
        {
            var sc = new BooliNET.AreaSearchCondition();
            sc.Latitude = "20.7";
            Assert.That(sc.Latitude == "20.7");
        }

        [Test]
        public void SetLongitude()
        {
            var sc = new BooliNET.AreaSearchCondition();
            sc.Longitude = "40.9";
            Assert.That(sc.Longitude == "40.9");
        }

        [Test]
        public void LatitudeException()
        {
            var sc = new BooliNET.AreaSearchCondition();
            TestDelegate throwingCode = () => sc.Latitude = "120.7";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void LongitudeException()
        {
            var sc = new BooliNET.AreaSearchCondition();
            TestDelegate throwingCode = () => sc.Longitude = "220";
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void LimitNegativeException()
        {
            var sc = new BooliNET.AreaSearchCondition();
            TestDelegate throwingCode = () => sc.Limit = -5;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void CreateUrl()
        {
            var sc = new BooliNET.AreaSearchCondition();
            sc.Latitude = "-20.7";
            sc.Longitude = "40.9";

            Console.WriteLine(sc.CreateUrl());

            Assert.That(sc.CreateUrl() == "limit=3&lat=-20.7&lng=40.9");
        }

        [Test]
        public void SearchConditionClear()
        {
            var sc = new BooliNET.AreaSearchCondition();
            sc.Latitude = "20.7";
            sc.Longitude = "-40.9";
            sc.CreateUrl();
            sc.ClearSearch();

            sc.Q = "Nacka";
            sc.Limit = 20;

            Console.WriteLine(sc.CreateUrl());

            Assert.That(sc.CreateUrl() == "limit=20&q=Nacka");
        }
    }

    [TestFixture]
    public class BooliSearchConditionIdTest
    {
        [Test]
        public void SetBooliId()
        {
            var sc = new BooliNET.IdSearchCondition();
            sc.BooliId = 123;
            Assert.That(sc.BooliId == 123);
        }

        [Test]
        public void NegativeBooliIdException()
        {
            var sc = new BooliNET.IdSearchCondition();
            TestDelegate throwingCode = () => sc.BooliId = -5;
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void NoBooliIdSetException()
        {
            var sc = new BooliNET.IdSearchCondition();
            sc.IdType = BooliUtil.IdType.Listings;
            TestDelegate throwingCode = () => sc.CreateUrl();
            Assert.Throws<ArgumentException>(throwingCode);
        }

        [Test]
        public void CreateUrl()
        {
            var sc = new BooliNET.IdSearchCondition();
            sc.BooliId = 1452;
            sc.IdType = BooliUtil.IdType.Listings;

            Assert.That(sc.CreateUrl() == "/listings/1452");
        }

        [Test]
        public void SearchConditionClear()
        {
            var sc = new BooliNET.IdSearchCondition();
            sc.BooliId = 1457;
            sc.IdType = BooliUtil.IdType.Listings;
            sc.CreateUrl();
            sc.ClearSearch();

            sc.BooliId = 1600;
            sc.IdType = BooliUtil.IdType.Sold;

            Assert.That(sc.CreateUrl() == "/sold/1600");
        }
    }


    [TestFixture]
    public class BooliUtilTest
    {

        [Test]
        public void CreateUniqeTest()
        {
            // Need to implement a better function for creating unique response
            string unique1 = BooliNET.BooliUtil.CreateUnique();
            Thread.Sleep(25);
            string unique2 = BooliNET.BooliUtil.CreateUnique();
            Assert.That(unique1 != unique2);
        }

        [Test]
        public void CreateCompleteUrlTest()
        {
            var sc = new BooliNET.BooliSearchCondition();
            sc.Q = "angered";

            string url = BooliNET.BooliUtil.CreateCompleteUrl("/listings?"+sc.CreateUrl(), "bomano", "P3tfkeJvKOXgHjvXZ1xpRXVGG2kHPmFpd7BZetHY");
            string pattern = "http://api.booli.se/listings\\?offset=0&limit=3&q=angered&callerId=bomano&time=.{10}&unique=.{16}&hash=.{40}";
            Assert.That(System.Text.RegularExpressions.Regex.IsMatch(url, pattern) == true);
        }

        [Test]
        public void Sha1Test()
        {
            Assert.That(BooliNET.BooliUtil.CreateSha1("") == "da39a3ee5e6b4b0d3255bfef95601890afd80709");
        }
    }
}
