using RestSharp;
using System;

namespace DL
{
    public class FilterImages
    {
        string apiKey = "acc_c282840c1b7255d";
        string apiSecret = "acc_c282840c1b7255d";
        string authorization = "Basic YWNjX2MyODI4NDBjMWI3MjU1ZDpkOGZiNmY3ZWYwZmYxM2Y5MThmNjFmOWZhN2NjODA1Mw==";
        RestClient client = new RestClient("https://api.imagga.com/v2/tags");
        string imageUrl = "https://docs.imagga.com/static/images/docs/sample/japan-605234_1280.jpg";

        public void getTag(string imageUrl)
        {

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddParameter("image_url", imageUrl);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Console.ReadLine();
        }
    }
}
