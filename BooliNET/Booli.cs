using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading;
using System.Globalization;

using Newtonsoft.Json;

namespace BooliNET
{
    public class Booli
    {
        string CallerId;
        string Key;

        public Booli(string callerId, string key)
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

        public ListingsResult GetResult(SearchCondition searchCondition)
        {
            string jsonString = BooliNET.BooliUtil.DoGetJson(BooliNET.BooliUtil.CreateCompleteUrl("/listings?"+searchCondition.CreateUrl(), CallerId, Key));
            return JsonConvert.DeserializeObject<ListingsResult>(jsonString);
        }

        public ListingsResult GetResultList(SearchCondition searchCondition, ExtendedSearchConditionList searchConditionList)
        {
            string jsonString = BooliNET.BooliUtil.DoGetJson(BooliNET.BooliUtil.CreateCompleteUrl("/listings?" + searchCondition.CreateUrl() + searchConditionList.CreateUrl(), CallerId, Key));
            return JsonConvert.DeserializeObject<ListingsResult>(jsonString);
        }

        public SoldResult GetResultSold(SearchCondition searchCondition, ExtendedSearchConditionSold searchConditionSold)
        {
            string jsonString = BooliNET.BooliUtil.DoGetJson(BooliNET.BooliUtil.CreateCompleteUrl("/sold?" + searchCondition.CreateUrl() + searchConditionSold.CreateUrl(), CallerId, Key));
            return JsonConvert.DeserializeObject<SoldResult>(jsonString);
        }

        public ListingsResult GetResultArea(AreaSearchCondition searchConditionArea)
        {
            string jsonString = BooliNET.BooliUtil.DoGetJson(BooliNET.BooliUtil.CreateCompleteUrl("/areas?" + searchConditionArea.CreateUrl(), CallerId, Key));
            return JsonConvert.DeserializeObject<ListingsResult>(jsonString);
        }

        public ListingsResult GetResultId(IdSearchCondition searchConditionId)
        {
            string jsonString = BooliNET.BooliUtil.DoGetJson(BooliNET.BooliUtil.CreateCompleteUrl(searchConditionId.CreateUrl(), CallerId, Key));
            return JsonConvert.DeserializeObject<ListingsResult>(jsonString);
        }
    }

    // Extended Search Conditions to fetch lists
    public class ExtendedSearchConditionList
    {
        int minListPrice;
        int maxListPrice;
        bool priceDecrease;

        StringBuilder urlConstructorString;

        public ExtendedSearchConditionList()
        {
            urlConstructorString = new StringBuilder();
            ClearSearch();
        }

        public void ClearSearch()
        {
            minListPrice = -1;
            maxListPrice = -1;
            priceDecrease = false;
        }

        public int MinListPrice
        {
            get { return minListPrice; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "MinListPrice");
                minListPrice = value;
            }
        }

        public int MaxListPrice
        {
            get { return maxListPrice; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "MaxListPrice");
                maxListPrice = value;
            }
        }

        public bool PriceDecrese
        {
            get { return priceDecrease; }
            set
            {
                priceDecrease = value;
            }
        }

        public string CreateUrl()
        {
            if (minListPrice != -1)
            {
                urlConstructorString.Append("&minListPrice=" + minListPrice.ToString());
            }

            if (maxListPrice != -1)
            {
                urlConstructorString.Append("&maxListPrice=" + maxListPrice.ToString());
            }

            if (priceDecrease != false)
            {
                urlConstructorString.Append("&priceDecrease=1");
            }

            string retStr = urlConstructorString.ToString();
            urlConstructorString.Clear();
            return retStr;
        }
    }

    // Extended Search Conditions to fetch sold
    public class ExtendedSearchConditionSold
    {
        int minSoldPrice;
        int maxSoldPrice;
        string minSoldDate;
        string maxSoldDate;

        StringBuilder urlConstructorString;

        public ExtendedSearchConditionSold()
        {
            urlConstructorString = new StringBuilder();
            ClearSearch();
        }

        public void ClearSearch()
        {
            minSoldPrice = -1;
            maxSoldPrice = -1;
            minSoldDate = "";
            maxSoldDate = "";
        }

        public int MinSoldPrice
        {
            get { return minSoldPrice; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "MinSoldPrice");
                minSoldPrice = value;
            }
        }

        public int MaxSoldPrice
        {
            get { return maxSoldPrice; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "MaxSoldPrice");
                maxSoldPrice = value;
            }
        }

        public string MinSoldDate
        {
            get { return minSoldDate; }
            set
            {
                BooliUtil.CheckCorrectDate(value, "MinSoldDate");
                minSoldDate = value;
            }
        }

        public string MaxSoldDate
        {
            get { return maxSoldDate; }
            set
            {
                BooliUtil.CheckCorrectDate(value, "MaxSoldDate");
                maxSoldDate = value;
            }
        }

        public string CreateUrl()
        {

            if (minSoldPrice != -1)
            {
                urlConstructorString.Append("&minSoldPrice=" + minSoldPrice.ToString());
            }

            if (maxSoldPrice != -1)
            {
                urlConstructorString.Append("&maxSoldPrice=" + maxSoldPrice.ToString());
            }

            if (minSoldDate != "")
            {
                urlConstructorString.Append("&minSoldDate=" + minSoldDate);
            }

            if (MaxSoldDate != "")
            {
                urlConstructorString.Append("&maxSoldDate=" + maxSoldDate);
            }

            string retStr = urlConstructorString.ToString();
            urlConstructorString.Clear();
            return retStr;
        }
    }

    public class AreaSearchCondition
    {
        string q;
        string latitude;
        string longitude;

        StringBuilder urlConstructorString;

        public AreaSearchCondition()
        {
            urlConstructorString = new StringBuilder();
            ClearSearch();
        }

        public void ClearSearch()
        {
            q = "";
            latitude = "";
            longitude = "";
        }

        public string Q
        {
            get { return q; }
            set { q = value; }
        }

        public string Latitude
        {
            get { return latitude; }
            set
            {
                BooliUtil.LatCheck(value, "Latitude");
                latitude = value;
            }
        }

        public string Longitude
        {
            get { return longitude; }
            set
            {
                BooliUtil.LongCheck(value, "Longitude");
                longitude = value;
            }
        }

        private void Validate()
        {
            if (q == "" && latitude == "" && longitude == "")
            {
                throw new ArgumentException("Q or Latitude and Longitude must be set to do a Area search!", "Q, Latitude, Longitude");
            }

            if (q != "" && (latitude != "" || longitude != ""))
            {
                throw new ArgumentException("Must set Q or Latitude and Longitude to do a Area search!", "Q, Latitude, Longitude");
            }

            if ((latitude != "" && longitude == "") || (longitude != "" && longitude == ""))
            {
                throw new ArgumentException("Must set Latitude and Longitude!", "Latitude, Longitude");
            }
        }

        public string CreateUrl()
        {
            Validate();

            if (q != "")
            {
                urlConstructorString.Append("q=" + q);    
            }
            else if (latitude != "" && longitude != "")
            {
                urlConstructorString.Append("lat=" + latitude + "&lng=" + longitude);
            }

            string retStr = urlConstructorString.ToString();
            urlConstructorString.Clear();
            return retStr;
        }
    }

    // Todo
    public class IdSearchCondition
    {
        int booliId;
        BooliUtil.IdType idType;

        StringBuilder urlConstructorString;

        public IdSearchCondition()
        {
            urlConstructorString = new StringBuilder();
            ClearSearch();
        }

        public void ClearSearch()
        {
            booliId = -1;
            idType = BooliUtil.IdType.Listings;
        }

        public int BooliId
        {
            get { return booliId; }
            set 
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "BooliId");   
                booliId = value; 
             }
        }

        public BooliUtil.IdType IdType
        {
            get { return idType; }
            set { idType = value; }
        }

        private void Validate()
        {
            if (booliId == -1)
            {
                throw new ArgumentException("Must set BooliId to make Id search!", "BooliId");
            }
        }

        public string CreateUrl()
        {
            Validate();

            if (idType == BooliUtil.IdType.Listings)
            {
                urlConstructorString.Append("/listings/");
            }
            else if (idType == BooliUtil.IdType.Sold)
            {
                urlConstructorString.Append("/sold/");
            }

            if (booliId != -1)
            {
                urlConstructorString.Append(booliId.ToString());
            }

            string retStr = urlConstructorString.ToString();
            urlConstructorString.Clear();
            return retStr;
        }
    }

    public class SearchCondition
    {
        string q;
        string center;
        string dim;
        string bbox;
        string areaId;
        int minPrice;
        int maxPrice;
        int minRooms;
        int maxRooms;
        int maxRent;
        int minLivingArea;
        int maxLivingArea;
        int minPlotArea;
        int maxPlotArea;
        string objectType;
        string minCreated;
        string maxCreated;
        int limit;
        int offset;

        StringBuilder urlConstructorString;

        public SearchCondition()
        {
            urlConstructorString = new StringBuilder();
            ClearSearch();
        }

        public void ClearSearch()
        {
            q = "";
            center = "";
            dim = "";
            bbox = "";
            areaId = "";
            minPrice = -1;
            maxPrice = -1;
            minRooms = -1;
            maxRooms = -1;
            maxRent = -1;
            minLivingArea = -1;
            maxLivingArea = -1;
            minPlotArea = -1;
            maxPlotArea = -1;
            objectType = "";
            minCreated = "";
            maxCreated = "";
            limit = -1;
            offset = -1;
        }

        public string Q
        {
            get { return q; }
            set { q = value; }
        }

        public string Center
        {
            get { return center; }
            set
            {
                BooliUtil.LatLongCheck(value, "Center");
                center = value;
            }
        }

        public string Dim
        {
            get { return dim; }
            set
            {
                this.DimCheck(value, "Dim");
                dim = value;
            }
        }

        public string Bbox
        {
            get { return bbox; }
            set
            {
                this.BboxCheck(value, "Bbox");
                bbox = value;
            }
        }

        public string AreaId
        {
            get { return areaId; }
            set
            {
                this.AreaIdCheck(value, "AreaId");
                areaId = value;
            }
        }

        public int MinPrice
        {
            get { return minPrice; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "MinPrice");
                minPrice = value;
            }
        }

        public int MaxPrice
        {
            get { return maxPrice; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "MaxPrice");
                maxPrice = value;
            }
        }

        public int MinRooms
        {
            get { return minRooms; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "MinRooms");
                minRooms = value;
            }
        }

        public int MaxRooms
        {
            get { return maxRooms; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "MaxRooms");
                maxRooms = value;
            }
        }

        public int MaxRent
        {
            get { return maxRent; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "MaxRent");
                maxRent = value;
            }
        }

        public int MinLivingArea
        {
            get { return minLivingArea; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "MinLivingArea");
                minLivingArea = value;
            }
        }

        public int MaxLivingArea
        {
            get { return maxLivingArea; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "MaxLivingArea");
                maxLivingArea = value;
            }
        }


        public int MinPlotArea
        {
            get { return minPlotArea; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "MinPlotArea");
                minPlotArea = value;
            }
        }

        public int MaxPlotArea
        {
            get { return maxPlotArea; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "MaxPlotArea");
                maxPlotArea = value;
            }
        }

        public string ObjectType
        {
            get { return objectType; }
            set
            {
                this.CheckObjectType(value, "ObjectType");
                objectType = value;
            }
        }

        public string MinCreated
        {
            get { return minCreated; }
            set
            {
                BooliUtil.CheckCorrectDate(value, "MinCreated");
                minCreated = value;
            }
        }

        public string MaxCreated
        {
            get { return maxCreated; }
            set
            {
                BooliUtil.CheckCorrectDate(value, "MaxCreated");
                maxCreated = value;
            }
        }

        public int Limit
        {
            get { return limit; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "Limit");
                limit = value;
            }
        }

        public int Offset
        {
            get { return offset; }
            set
            {
                BooliUtil.CheckPositiveOrZeroInt(value, "Offset");
                offset = value;
            }
        }

        public string CreateUrl()
        {
            Validate();

            if (offset != -1)
            {
                urlConstructorString.Append("offset=" + offset.ToString());
            }
            else
            {
                urlConstructorString.Append("offset=0");
            }

            if (limit != -1)
            {
                urlConstructorString.Append("&limit=" + limit.ToString());
            }
            else
            {
                urlConstructorString.Append("&limit=3");
            }

            if (maxCreated != "")
            {
                urlConstructorString.Append("&maxCreated=" + maxCreated);
            }

            if (minCreated != "")
            {
                urlConstructorString.Append("&minCreated=" + minCreated);
            }

            if (objectType != "")
            {
                urlConstructorString.Append("&objectType=" + objectType);
            }

            if (maxPlotArea != -1)
            {
                urlConstructorString.Append("&maxPlotArea=" + maxPlotArea.ToString());
            }

            if (minPlotArea != -1)
            {
                urlConstructorString.Append("&minPlotArea=" + minPlotArea.ToString());
            }

            if (maxLivingArea != -1)
            {
                urlConstructorString.Append("&maxLivingArea=" + maxLivingArea.ToString());
            }

            if (minLivingArea != -1)
            {
                urlConstructorString.Append("&minLivingArea=" + minLivingArea.ToString());
            }

            if (maxRent != -1)
            {
                urlConstructorString.Append("&maxRent=" + maxRent.ToString());
            }

            if (maxRooms != -1)
            {
                urlConstructorString.Append("&maxRooms=" + maxRooms.ToString());
            }

            if (minRooms != -1)
            {
                urlConstructorString.Append("&minRooms=" + minRooms.ToString());
            }

            if (maxPrice != -1)
            {
                urlConstructorString.Append("&maxPrice=" + maxPrice.ToString());
            }

            if (minPrice != -1)
            {
                urlConstructorString.Append("&minPrice=" + minPrice.ToString());
            }

            if (areaId != "")
            {
                urlConstructorString.Append("&areaId=" + areaId);
            }

            if (bbox != "")
            {
                urlConstructorString.Append("&bbox=" + bbox);
            }

            if (dim != "")
            {
                urlConstructorString.Append("&dim=" + dim);
            }

            if (center != "")
            {
                urlConstructorString.Append("&center=" + center);
            }

            if (q != "")
            {
                urlConstructorString.Append("&q=" + q);
            }

            string retStr = urlConstructorString.ToString();
            urlConstructorString.Clear();
            return retStr;
        }

        private void DimCheck(string inString, string paramName)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            string[] splitString = inString.Split(',');
            if (splitString.Length != 2)
            {
                throw new ArgumentException("Dimension must be between two positive numbers in the format 100,100!", paramName);
            }

            double dim1 = double.Parse(splitString[0], NumberStyles.Float);
            double dim2 = double.Parse(splitString[1], NumberStyles.Float);

            if (dim1 < 0 || dim2 < 0)
            {
                throw new ArgumentException("Dimension must be between two positive numbers in the format 100,100!", paramName);
            }
        }

        private void BboxCheck(string inString, string paramName)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            string[] splitString = inString.Split(',');
            if (splitString.Length != 4)
            {
                throw new ArgumentException("Bbox must be two lat-long pairs, on the form lat_lo,long_lo,lat_hi,long_hi where lo is south west and hi is north east!", paramName);
            }


            double bbox1 = double.Parse(splitString[0], NumberStyles.Float);
            double bbox2 = double.Parse(splitString[1], NumberStyles.Float);
            double bbox3 = double.Parse(splitString[2], NumberStyles.Float);
            double bbox4 = double.Parse(splitString[3], NumberStyles.Float);

            if (bbox1 < -90 || bbox3 < -90 || bbox1 > 90 || bbox3 > 90)
            {
                throw new ArgumentException("Bbox must be two lat-long pairs, on the form lat_lo,long_lo,lat_hi,long_hi where lo is south west and hi is north east!", paramName);
            }

            if (bbox2 < -180 || bbox4 < -180 || bbox2 > 180 || bbox4 > 180)
            {
                throw new ArgumentException("Bbox must be two lat-long pairs, on the form lat_lo,long_lo,lat_hi,long_hi where lo is south west and hi is north east!", paramName);
            }
        }

        private void AreaIdCheck(string inString, string paramName)
        {
            string[] splitString = inString.Split(',');
            int i;

            foreach (string id in splitString)
            {
                try
                {
                    i = int.Parse(id);
                    if (i < 0)
                    {
                        throw new ArgumentException("AreaId must be a list of positive integers 1,2,3,4!", paramName);
                    }
                }
                catch (FormatException)
                {
                    throw new FormatException("AreaId must be a list of positive integers 1,2,3,4!");
                }
            }
        }

        private void CheckObjectType(string inString, string paramName)
        {
            string[] splitString = inString.Split(',');
            Dictionary<string, string> checkUnique = new Dictionary<string, string>();

            foreach (string objType in splitString)
            {
                try
                {
                    switch (objType.Trim())
                    {
                        case "villa":
                            checkUnique.Add("villa", "villa");
                            break;
                        case "lägenhet":
                            checkUnique.Add("lägenhet", "lägenhet");
                            break;
                        case "gård":
                            checkUnique.Add("gård", "gård");
                            break;
                        case "tomt-mark":
                            checkUnique.Add("tomt-mark", "tomt-mark");
                            break;
                        case "fritidshus":
                            checkUnique.Add("fritidshus", "fritidshus");
                            break;
                        case "parhus":
                            checkUnique.Add("parhus", "parhus");
                            break;
                        case "radhus":
                            checkUnique.Add("radhus", "radhus");
                            break;
                        case "kedjehus":
                            checkUnique.Add("kedjehus", "kedjehus");
                            break;
                        default:
                            throw new ArgumentException("Unknown object type " + objectType + " !", paramName);
                    }
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("Duplicate object type " + objectType + " !", paramName);
                }
            }
        }

        private void Validate()
        {
            if (q == "" && (center == "" || dim == "") && bbox == "" && areaId == "")
            {
                throw new ArgumentException("Q, Center and Dim, Bbox or AreaId must be set to do a search!", "Q, Center, Dim, BBox, AreaId");
            }
        }
    }

    // Result class and friends

    public class ListingsResult
    {
        public int totalCount { get; set; }
        public int count { get; set; }
        public List<Listing> listings { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public SearchParams searchParams { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Total count: " + totalCount.ToString() + "\n");
            sb.Append("Count: " + count.ToString() + "\n");
            sb.Append("Limit: " + limit.ToString() + "\n");
            sb.Append("Offset: " + offset.ToString() + "\n\n");
            sb.Append("Listings: \n");

            foreach (Listing item in listings)
            {
                sb.Append("=============================================\n"); 
                sb.Append("Booli Id: " + item.booliId.ToString() + "\n");
                sb.Append("List Price: " + item.listPrice.ToString() + "\n");
                sb.Append("Published: " + item.published + "\n\n");
                sb.Append("Location: \n");
                sb.Append("Named Areas: ");
                foreach (string s in item.location.namedAreas)
                {
                    sb.Append(s + " ");
                }
                sb.Append("\n");
                sb.Append("Region, Municipality Name: " + item.location.region.municipalityName + " ,County Name: " + item.location.region.countyName + "\n");
                sb.Append("Address, City: " + item.location.address.city + " ,Street address: " + item.location.address.streetAddress + "\n");
                sb.Append("Position, Latitude: " + item.location.position.latitude.ToString() + " ,Longitude: " + item.location.position.longitude.ToString() + "\n\n");
                sb.Append("Object type: " + item.objectType + "\n");
                sb.Append("Source, Name: " + item.source.name + " ,Type: " + item.source.type + " ,Url: " + item.source.url + "\n");
                sb.Append("Rooms: " + item.rooms.ToString() + "\n");
                sb.Append("Living Area: " + item.livingArea.ToString() + "\n");
                sb.Append("Plot Area: " + item.plotArea + "\n");
                sb.Append("Is new construction: " + item.isNewConstruction.ToString() + "\n");
                sb.Append("Url: " + item.url + "\n");
                sb.Append("Floor: " + item.floor + "\n");
                sb.Append("Rent: " + item.rent + "\n");
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public void SetStringsToEmptyIfNull()
        {
            foreach (Listing item in listings)
            {
                if (item.published == null)
                    item.published = "";

                if (item.location == null)
                {
                    item.location.namedAreas = new List<string>();

                    item.location = new Location();
                    item.location.region = new Region();
                    item.location.region.municipalityName = "";
                    item.location.region.countyName = "";

                    item.location.address = new Address();
                    item.location.address.city = "";
                    item.location.address.streetAddress = "";

                    item.location.position = new Position();
                    item.location.position.latitude = 0.0;
                    item.location.position.longitude = 0.0;
                }

                if (item.location.region == null)
                {
                    item.location.region = new Region();
                    item.location.region.municipalityName = "";
                    item.location.region.countyName = "";
                }
                else
                {
                    if (item.location.region.municipalityName == null)
                        item.location.region.municipalityName = "";

                    if (item.location.region.countyName == null)
                        item.location.region.countyName = "";
                }

                if (item.location.address == null)
                {
                    item.location.address = new Address();
                    item.location.address.city = "";
                    item.location.address.streetAddress = "";
                }
                else
                {
                    if (item.location.address.city == null)
                        item.location.address.city = "";

                    if (item.location.address.streetAddress == null)
                        item.location.address.streetAddress = "";
                }

                if (item.location.position == null)
                {
                    item.location.position = new Position();
                    item.location.position.latitude = 0.0;
                    item.location.position.longitude = 0.0;
                }

                if (item.objectType == null)
                    item.objectType = "";

                if (item.source == null)
                {
                    item.source = new Source();
                    item.source.name = "";
                    item.source.type = "";
                    item.source.url = "";
                }

                if (item.source.name == null)
                    item.source.name = "";

                if (item.source.type == null)
                    item.source.type = "";

                if (item.source.url == null)
                    item.source.url = "";

                if (item.plotArea == null)
                    item.plotArea = "";

                if (item.url == null)
                    item.url = "";
            }
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            SetStringsToEmptyIfNull();
        }
    }

    public class SoldResult
    {
        public int totalCount { get; set; }
        public int count { get; set; }
        public List<Sold> sold { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public SearchParams searchParams { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Total count: " + totalCount.ToString() + "\n");
            sb.Append("Count: " + count.ToString() + "\n");
            sb.Append("Limit: " + limit.ToString() + "\n");
            sb.Append("Offset: " + offset.ToString() + "\n\n");
            sb.Append("Listings: \n");

            foreach (Sold item in sold)
            {
                sb.Append("=============================================\n");
                sb.Append("Booli Id: " + item.booliId.ToString() + "\n");
                sb.Append("Sold Price: " + item.soldPrice.ToString() + "\n");
                sb.Append("Sold Date: " + item.soldDate + "\n\n");
                sb.Append("Location: \n");
                sb.Append("Named Areas: ");
                foreach (string s in item.location.namedAreas)
                {
                    sb.Append(s + " ");
                }
                sb.Append("\n");
                sb.Append("Region, Municipality Name: " + item.location.region.municipalityName + " ,County Name: " + item.location.region.countyName + "\n");
                sb.Append("Address, City: " + item.location.address.city + " ,Street address: " + item.location.address.streetAddress + "\n");
                sb.Append("Position, Latitude: " + item.location.position.latitude.ToString() + " ,Longitude: " + item.location.position.longitude.ToString() + "\n\n");
                sb.Append("Object type: " + item.objectType + "\n");
                sb.Append("Source, Name: " + item.source.name + " ,Type: " + item.source.type + " ,Url: " + item.source.url + "\n");
                sb.Append("Rooms: " + item.rooms.ToString() + "\n");
                sb.Append("Living Area: " + item.livingArea.ToString() + "\n");
                sb.Append("Plot Area: " + item.plotArea + "\n");
                sb.Append("Is new construction: " + item.isNewConstruction.ToString() + "\n");
                sb.Append("Url: " + item.url + "\n");
                sb.Append("Floor: " + item.floor + "\n");
                sb.Append("Rent: " + item.rent + "\n");
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public void SetStringsToEmptyIfNull()
        {
            foreach (Sold item in sold)
            {
                if (item.soldDate == null)
                    item.soldDate = "";

                if (item.location == null)
                {
                    item.location.namedAreas = new List<string>();

                    item.location = new Location();
                    item.location.region = new Region();
                    item.location.region.municipalityName = "";
                    item.location.region.countyName = "";

                    item.location.address = new Address();
                    item.location.address.city = "";
                    item.location.address.streetAddress = "";

                    item.location.position = new Position();
                    item.location.position.latitude = 0.0;
                    item.location.position.longitude = 0.0;
                }

                if (item.location.region == null)
                {
                    item.location.region = new Region();
                    item.location.region.municipalityName = "";
                    item.location.region.countyName = "";
                }
                else
                {
                    if (item.location.region.municipalityName == null)
                        item.location.region.municipalityName = "";

                    if (item.location.region.countyName == null)
                        item.location.region.countyName = "";
                }

                if (item.location.address == null)
                {
                    item.location.address = new Address();
                    item.location.address.city = "";
                    item.location.address.streetAddress = "";
                }
                else
                {
                    if (item.location.address.city == null)
                        item.location.address.city = "";

                    if (item.location.address.streetAddress == null)
                        item.location.address.streetAddress = "";
                }

                if (item.location.position == null)
                {
                    item.location.position = new Position();
                    item.location.position.latitude = 0.0;
                    item.location.position.longitude = 0.0;
                }

                if (item.objectType == null)
                    item.objectType = "";

                if (item.source == null)
                {
                    item.source = new Source();
                    item.source.name = "";
                    item.source.type = "";
                    item.source.url = "";
                }

                if (item.source.name == null)
                    item.source.name = "";

                if (item.source.type == null)
                    item.source.type = "";

                if (item.source.url == null)
                    item.source.url = "";

                if (item.plotArea == null)
                    item.plotArea = "";

                if (item.url == null)
                    item.url = "";
            }
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            SetStringsToEmptyIfNull();
        }
    }

    public class Region
    {
        public string municipalityName { get; set; }
        public string countyName { get; set; }
    }

    public class Address
    {
        public string city { get; set; }
        public string streetAddress { get; set; }
    }

    public class Position
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Location
    {
        public List<string> namedAreas { get; set; }
        public Region region { get; set; }
        public Address address { get; set; }
        public Position position { get; set; }
    }

    public class Source
    {
        public string name { get; set; }
        public string url { get; set; }
        public string type { get; set; }
    }

    public class Listing
    {
        public int booliId { get; set; }
        public double listPrice { get; set; }
        public string published { get; set; }
        public Location location { get; set; }
        public string objectType { get; set; }
        public Source source { get; set; }
        public double rooms { get; set; }
        public double livingArea { get; set; }
        public string plotArea { get; set; }
        public int isNewConstruction { get; set; }
        public string url { get; set; }
        public double floor { get; set; }
        public double rent { get; set; }
    }

    public class Sold
    {
        public int booliId { get; set; }
        public double soldPrice { get; set; }
        public string soldDate { get; set; }
        public Location location { get; set; }
        public string objectType { get; set; }
        public Source source { get; set; }
        public double rooms { get; set; }
        public double livingArea { get; set; }
        public string plotArea { get; set; }
        public int isNewConstruction { get; set; }
        public string url { get; set; }
        public double floor { get; set; }
        public double rent { get; set; }
    }

    public class SearchParams
    {
        // As this can be both int and a array of strings it is currently not parsed
        //public int areaId { get; set; }
    }
}

    

