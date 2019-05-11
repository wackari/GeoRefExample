using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft;
using Newtonsoft.Json;

namespace GeoRefLocation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create("https://nominatim.openstreetmap.org/reverse?format=json&lon=-78.70896&lat=33.81632");
            objRequest.Method = "GET";
            objRequest.UserAgent = @"AppName";
            WebResponse response = (WebResponse)objRequest.GetResponse();
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            string result = "";
            using (StreamReader responseStream = new StreamReader(objResponse.GetResponseStream()))
            {
                result = responseStream.ReadToEnd();
                responseStream.Close();
            }

            var GeoRef = JsonConvert.DeserializeObject<RootObject>(result);
            Console.WriteLine(GeoRef.display_name);

            Console.ReadLine();



        }
    }
}
