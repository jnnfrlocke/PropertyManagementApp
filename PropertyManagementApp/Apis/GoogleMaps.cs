using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Google.Apis;

namespace PropertyManagementApp.Apis
{
    public class GoogleMaps
    {
        public GoogleMaps()
        {
        }

        public string[] GetVacantFormattedUrl(string streetNumber, string streetName, string city, string state, int zip)
        {
            string baseUrl = "https://maps.googleapis.com/maps/api/geocode";
            string jsonQuery = $"/json?address={streetNumber}+{streetName}+{city}+{state}+{zip}&key={Credentials.GeoCodeApiKey}";
            string formattedUrl = baseUrl + jsonQuery;
            var results = ParseLatLong(formattedUrl);
            return results;
        }

       public string[] ParseLatLong(string formattedUrl)
        {
            Rootobject resObj = GetLatLong(formattedUrl);
            string lat = resObj.results[0].geometry.location.lat.ToString();
            string lng = resObj.results[0].geometry.location.lng.ToString();
            string[] resultStringArray = new string[] { lat, lng };
            return resultStringArray;
        }

        public Rootobject GetLatLong(string url)
        {
            List<string> resList = new List<string>();
            var client = new RestClient(url);
            
            var request = new RestRequest(Method.GET);
            
            IRestResponse response = client.Execute(request);
            
            string content = response.Content;
            Rootobject mapdata = JsonConvert.DeserializeObject<Rootobject>(content);
            return mapdata;
        }

        public void CreateMap()
        {

        }

        public class Rootobject
        {
            public Result[] results { get; set; }
            public string status { get; set; }
        }
        public class Result
        {
            public Address_Components[] address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string place_id { get; set; }
            public string[] types { get; set; }
        }

        public class Geometry
        {
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Location
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Northeast
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Southwest
        {
            public float lat { get; set; }
            public float lng { get; set; }
        }

        public class Address_Components
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public string[] types { get; set; }
        }
    }
}