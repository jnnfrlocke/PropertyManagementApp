using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PropertyManagementApp.Apis
{
    public class GoogleMaps
    {
        public GoogleMaps()
        {
        }

        private string _geocodeApiKey = Properties.Settings.Default.GeoCodeApiKey;

        public string GeocodeApiKey => _geocodeApiKey;
        
        public object GetQueryUrl()
        {
            string baseUrl = "https://maps.googleapis.com/maps/api/geocode";
            string jsonQuery = $"/json?address=2221+W+Kendall+Ave,+Glendale,+WI&key={GeocodeApiKey}";
            string formattedUrl = baseUrl + jsonQuery;
            string coordinates = GetLatLong(formattedUrl);
            // TODO: This should be a new method - doin something new
            var jsonCoordinates = JsonConvert.DeserializeObject(coordinates);

            return jsonCoordinates;
        }

        public string GetLatLong(string url)
        {
            // Create Rest client
            var client = new RestClient(url);

            // define request method/type
            var request = new RestRequest(Method.GET);

            // add headers

            // build body if not get type

            //execute request
            IRestResponse response = client.Execute(request);

            //return response
            string content = response.Content;

            return content;
        }
        

        //public 

    }
}