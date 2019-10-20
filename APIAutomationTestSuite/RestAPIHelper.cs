using RestSharp;

namespace APIAutomationTestSuite
{
    public static class RestAPIHelper
    {
        public static RestClient client;
        public static RestRequest restRequest;
        public static string baseUrl = $"https://reqres.in/api";

        public static RestClient SetUrl(string endpoint)
        {
            string url = baseUrl + endpoint;
            return client = new RestClient(url);

        }

        public static RestRequest CreateRequest()
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json"); // response will come in json format
            return restRequest;
        }

        public static RestRequest CreateRequest(string userId)
        {
            var resource = userId;
            restRequest = new RestRequest(resource, Method.GET);
            restRequest.AddHeader("Accept", "application/json");            
            return restRequest;
        }

        public static RestRequest CreateRequestWithBody(string email, string password)
        {
            
            restRequest = new RestRequest(Method.POST);
            
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Authorization", "Bearer[API KEY]"); // adding bearer token to request
            

            if(string.IsNullOrEmpty(password))
            {
                restRequest.AddJsonBody(new { email = email });
            }
            else
            {
                restRequest.AddJsonBody(new { email = email, password = password });
            }                     

            return restRequest;
        }

        public static IRestResponse GetResponse()
        {
            return client.Execute(restRequest);
        }
    }
}
